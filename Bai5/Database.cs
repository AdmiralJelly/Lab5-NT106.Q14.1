using Microsoft.Data.Sqlite;
using MimeKit;
using MailKit;
using MailKit.Net.Imap;
using MailKit.Search;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Bai5
{
    public class Dish
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public byte[]? Image { get; set; }
        public string UserEmail { get; set; } = "";
        public string ContributorName { get; set; } = "Người ẩn danh";
        public string CreatedAt { get; set; } = "";
        public string? EmailMessageId { get; set; }
    }

    internal static class Database
    {
        private static readonly string DbPath =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CulinaryDB.sqlite");

        private static readonly string ConnStr = $"Data Source={DbPath}";

        public static void Init()
        {
            if (!File.Exists(DbPath))
            {
                using var _ = File.Create(DbPath);
            }

            using var conn = new SqliteConnection(ConnStr);
            conn.Open();

            const string createSql = @"
CREATE TABLE IF NOT EXISTS Dishes (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Name TEXT NOT NULL,
    Image BLOB,
    UserEmail TEXT,
    ContributorName TEXT,
    CreatedAt TEXT,
    EmailMessageId TEXT UNIQUE
);";
            using (var cmd = new SqliteCommand(createSql, conn))
                cmd.ExecuteNonQuery();

            EnsureColumn(conn, "Dishes", "ContributorName", "TEXT");
            EnsureColumn(conn, "Dishes", "EmailMessageId", "TEXT");

            // Dọn trùng tên cũ để tạo UNIQUE index không bị lỗi
            using (var cleanup = new SqliteCommand(@"
DELETE FROM Dishes
WHERE Id NOT IN (
    SELECT MIN(Id) FROM Dishes GROUP BY Name COLLATE NOCASE
);", conn))
            {
                cleanup.ExecuteNonQuery();
            }

            // Chặn trùng tên món (không phân biệt hoa/thường)
            using (var idx = new SqliteCommand(@"
CREATE UNIQUE INDEX IF NOT EXISTS UX_Dishes_Name
ON Dishes(Name COLLATE NOCASE);", conn))
            {
                idx.ExecuteNonQuery();
            }
        }

        private static void EnsureColumn(SqliteConnection conn, string table, string col, string type)
        {
            using var pragma = new SqliteCommand($"PRAGMA table_info({table});", conn);
            using var r = pragma.ExecuteReader();
            while (r.Read())
            {
                if (string.Equals(r["name"]?.ToString(), col, StringComparison.OrdinalIgnoreCase))
                    return;
            }

            using var alter = new SqliteCommand($"ALTER TABLE {table} ADD COLUMN {col} {type};", conn);
            alter.ExecuteNonQuery();
        }

        // true = insert thành công, false = bị ignore do trùng (Name hoặc EmailMessageId UNIQUE)
        public static bool InsertDish(
            string dishName,
            byte[]? imageBytes,
            string? userEmail,
            string contributorName = "Người ẩn danh",
            string? emailMessageId = null,
            string? createdAt = null)
        {
            using var conn = new SqliteConnection(ConnStr);
            conn.Open();

            const string sql = @"
INSERT OR IGNORE INTO Dishes (Name, Image, UserEmail, ContributorName, CreatedAt, EmailMessageId)
VALUES (@name, @img, @email, @cname, @created, @msgid);";

            using var cmd = new SqliteCommand(sql, conn);

            cmd.Parameters.AddWithValue("@name", dishName ?? string.Empty);

            var imgParam = cmd.CreateParameter();
            imgParam.ParameterName = "@img";
            imgParam.DbType = DbType.Binary;
            imgParam.Value = (object?)imageBytes ?? DBNull.Value;
            cmd.Parameters.Add(imgParam);

            cmd.Parameters.AddWithValue("@email",
                string.IsNullOrWhiteSpace(userEmail) ? (object)DBNull.Value : userEmail!);

            cmd.Parameters.AddWithValue("@cname",
                string.IsNullOrWhiteSpace(contributorName) ? "Người ẩn danh" : contributorName);

            cmd.Parameters.AddWithValue("@created",
                string.IsNullOrWhiteSpace(createdAt) ? DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") : createdAt!);

            cmd.Parameters.AddWithValue("@msgid",
                string.IsNullOrWhiteSpace(emailMessageId) ? (object)DBNull.Value : emailMessageId!);

            int affected = cmd.ExecuteNonQuery();
            return affected > 0;
        }

        public static bool EmailMessageExists(string emailMessageId)
        {
            if (string.IsNullOrWhiteSpace(emailMessageId)) return false;

            using var conn = new SqliteConnection(ConnStr);
            conn.Open();

            using var cmd = new SqliteCommand("SELECT 1 FROM Dishes WHERE EmailMessageId = @id LIMIT 1;", conn);
            cmd.Parameters.AddWithValue("@id", emailMessageId);
            var x = cmd.ExecuteScalar();
            return x != null;
        }

        public static Dish? GetOneRandomDish()
        {
            using var conn = new SqliteConnection(ConnStr);
            conn.Open();

            using var cmd = new SqliteCommand("SELECT * FROM Dishes ORDER BY RANDOM() LIMIT 1;", conn);
            using var r = cmd.ExecuteReader();

            if (!r.Read()) return null;

            byte[]? imageData = null;
            int imgIdx = r.GetOrdinal("Image");
            if (!r.IsDBNull(imgIdx))
                imageData = (byte[])r["Image"];

            return new Dish
            {
                Id = Convert.ToInt32(r["Id"]),
                Name = r["Name"]?.ToString() ?? "",
                UserEmail = r["UserEmail"]?.ToString() ?? "",
                ContributorName = r["ContributorName"]?.ToString() ?? "Người ẩn danh",
                CreatedAt = r["CreatedAt"]?.ToString() ?? "",
                EmailMessageId = r["EmailMessageId"]?.ToString(),
                Image = imageData
            };
        }

        public static byte[] ImageToBytes(Image img)
        {
            using var ms = new MemoryStream();
            img.Save(ms, ImageFormat.Png);
            return ms.ToArray();
        }

        public static Image BytesToImage(byte[] bytes)
        {
            using var ms = new MemoryStream(bytes);
            using var img = Image.FromStream(ms);
            return new Bitmap(img); // clone để tránh stream disposed
        }

        public static async Task<int> ImportEmailContributionsAsync(string inboxEmail, string appPassword)
        {
            int imported = 0;

            using var client = new ImapClient();
            await client.ConnectAsync("imap.gmail.com", 993, true);
            await client.AuthenticateAsync(inboxEmail, appPassword);

            var inbox = client.Inbox;
            await inbox.OpenAsync(FolderAccess.ReadWrite);

            var uids = await inbox.SearchAsync(SearchQuery.NotSeen); // chỉ lấy mail chưa đọc

            foreach (var uid in uids)
            {
                var msg = await inbox.GetMessageAsync(uid);

                var msgId = string.IsNullOrWhiteSpace(msg.MessageId) ? uid.Id.ToString() : msg.MessageId;

                if (EmailMessageExists(msgId))
                {
                    await inbox.AddFlagsAsync(uid, MessageFlags.Seen, true);
                    continue;
                }

                var fromMb = msg.From.Mailboxes.FirstOrDefault();
                string contributorName = string.IsNullOrWhiteSpace(fromMb?.Name) ? "Người ẩn danh" : fromMb!.Name;
                string contributorEmail = fromMb?.Address ?? "";

                string dishName = ExtractDishName(msg);
                byte[]? imgBytes = ExtractFirstImageAttachment(msg);

                if (imgBytes == null || string.IsNullOrWhiteSpace(dishName))
                {
                    await inbox.AddFlagsAsync(uid, MessageFlags.Seen, true);
                    continue;
                }

                string createdAt = msg.Date.ToLocalTime().ToString("dd/MM/yyyy HH:mm:ss");

                // nếu bị trùng tên => InsertDish trả false (và vẫn mark read để khỏi đọc lại)
                InsertDish(dishName, imgBytes, contributorEmail, contributorName, msgId, createdAt);
                imported++;

                await inbox.AddFlagsAsync(uid, MessageFlags.Seen, true);
            }

            await client.DisconnectAsync(true);
            return imported;
        }

        private static string ExtractDishName(MimeMessage msg)
        {
            string body = msg.TextBody ?? msg.HtmlBody ?? "";
            body = body.Trim();

            if (!string.IsNullOrWhiteSpace(body))
            {
                int idx = body.IndexOf(';');
                if (idx > 0) return body.Substring(0, idx).Trim();
                return body.Split('\n').FirstOrDefault()?.Trim() ?? "";
            }

            return (msg.Subject ?? "").Trim();
        }

        private static byte[]? ExtractFirstImageAttachment(MimeMessage msg)
        {
            foreach (var att in msg.Attachments)
            {
                if (att is MimePart part && part.ContentType?.MediaType == "image")
                {
                    using var ms = new MemoryStream();
                    part.Content.DecodeTo(ms);
                    return ms.ToArray();
                }
            }
            return null;
        }

        public static void ClearAllData()
        {
            using var conn = new SqliteConnection(ConnStr);
            conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"
DELETE FROM Dishes;
DELETE FROM sqlite_sequence WHERE name='Dishes';";

            cmd.ExecuteNonQuery();
        }
    }
}
