using System;
using Microsoft.Data.Sqlite;
using System.Windows.Forms;
using MailKit;
using MailKit.Net.Imap;
using MailKit.Search;
using MimeKit;
using System.Collections.Generic;

namespace Lab5_Bai5
{
    public partial class Form1 : Form
    {
        string dbPath = "Data Source=HomNayAnGi.db";

        public Form1()
        {
            InitializeComponent();
            SQLitePCL.Batteries.Init();
            InitDatabase();
            LoadListToUI(); // Tải danh sách hiện có lên ListView khi mở app 
        }

        private void InitDatabase()
        {
            using (var connection = new SqliteConnection(dbPath))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"CREATE TABLE IF NOT EXISTS MonAn (
                                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                        TenMonAn TEXT,
                                        HinhAnh TEXT,
                                        NguoiDongGop TEXT)";
                command.ExecuteNonQuery();
            }
        }
 
        private void LoadListToUI()
        {
            lvwContributions.Items.Clear();
            using (var connection = new SqliteConnection(dbPath))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT TenMonAn, HinhAnh, NguoiDongGop FROM MonAn";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var item = new ListViewItem(reader.GetString(2)); // Cột Người đóng góp
                        item.SubItems.Add(reader.GetString(0)); // Cột Tên món
                        item.Tag = reader.GetString(1); // Lưu link ảnh vào Tag để lấy lại khi click
                        lvwContributions.Items.Add(item);
                    }
                }
            }
        }

        private async void btnSync_Click(object sender, EventArgs e)
        {
            btnSync.Enabled = false;
            try
            {
                using (var client = new ImapClient())
                {
                    await client.ConnectAsync("imap.gmail.com", 993, true); // [cite: 89, 160]
                    await client.AuthenticateAsync(txtEmail.Text, txtPassword.Text); // [cite: 161]
                    var inbox = client.Inbox;
                    await inbox.OpenAsync(FolderAccess.ReadWrite);

                    var uids = await inbox.SearchAsync(SearchQuery.NotSeen.And(SearchQuery.SubjectContains("Đóng góp món ăn"))); // [cite: 183]

                    int count = 0;
                    foreach (var uid in uids)
                    {
                        var message = await inbox.GetMessageAsync(uid);
                        string body = message.TextBody?.Trim();

                        if (!string.IsNullOrEmpty(body) && body.Contains(";"))
                        {
                            string[] parts = body.Split(';'); // [cite: 185]
                            string tenMon = parts[0].Trim();
                            string hinhAnh = parts[1].Trim();

       
                            string nguoi = message.From.Count > 0 && !string.IsNullOrEmpty(message.From[0].Name)
                                                  ? message.From[0].Name : "Người ẩn danh";

                      
                            {
                                SaveToDB(tenMon, hinhAnh, nguoi);
                                count++;
                            }
                        }
                        await inbox.AddFlagsAsync(uid, MessageFlags.Seen, true); //  Đánh dấu đã đọc
                    }
                    if (count > 0) LoadListToUI(); // Cập nhật lại list sau khi tải thành công
                    MessageBox.Show($"Đã tải thành công {count} đóng góp mới!");
                    await client.DisconnectAsync(true);
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
            btnSync.Enabled = true;
        }


        private void lvwContributions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwContributions.SelectedItems.Count > 0)
            {
                var selectedItem = lvwContributions.SelectedItems[0];
                lblContributor.Text = "Người đóng góp: " + selectedItem.Text;
                lblFoodName.Text = selectedItem.SubItems[1].Text;
                pbFoodImage.ImageLocation = selectedItem.Tag.ToString(); // Lấy link ảnh từ Tag
            }
        }

        private void btnRandom_Click(object sender, EventArgs e)
        {
            using (var connection = new SqliteConnection(dbPath))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT TenMonAn, HinhAnh, NguoiDongGop FROM MonAn ORDER BY RANDOM() LIMIT 1"; // [cite: 839]

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        lblFoodName.Text = reader.GetString(0);
                        lblContributor.Text = "Đóng góp bởi: " + reader.GetString(2);
                        pbFoodImage.ImageLocation = reader.GetString(1);
                    }
                    else { MessageBox.Show("Dữ liệu trống!"); }
                }
            }
        }

        private void SaveToDB(string ten, string hinh, string nguoi)
        {
            using (var connection = new SqliteConnection(dbPath))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "INSERT INTO MonAn (TenMonAn, HinhAnh, NguoiDongGop) VALUES ($ten, $hinh, $nguoi)";
                command.Parameters.AddWithValue("$ten", ten);
                command.Parameters.AddWithValue("$hinh", hinh);
                command.Parameters.AddWithValue("$nguoi", nguoi);
                command.ExecuteNonQuery();
            }
        }

        private bool CheckExist(string ten)
        {
            using (var connection = new SqliteConnection(dbPath))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT COUNT(*) FROM MonAn WHERE TenMonAn = $ten";
                command.Parameters.AddWithValue("$ten", ten);
                return Convert.ToInt64(command.ExecuteScalar()) > 0;
            }
        }
    }
}