using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;
using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Utils;
using System.Net.Http;
using System.Text.Json;
using System.Net.Sockets;

namespace Bai4
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            imageListPoster = new ImageList();
            lvMovies.SmallImageList = imageListPoster;
            imageListPoster.ImageSize = new Size(64, 96);
        }

        private ImageList imageListPoster;


        private readonly List<MovieInfo> _movies = new List<MovieInfo>();

        private Support detailForm = null;

        // HttpClient dùng lại cho cả form
        private readonly HttpClient _http = new HttpClient
        {
            BaseAddress = new Uri("https://betacinemas.vn")
        };

        public class MovieInfo
        {
            public string Title { get; set; }
            public string DetailUrl { get; set; }
            public string PosterUrl { get; set; }
            public string LocalImagePath { get; set; }
        }

        private async void btnLoad_Click(object sender, EventArgs e)
        {
            await  LoadMoviesFromWebAsync();
        }

        private async void Main_Load(object sender, EventArgs e)
        {
            if (File.Exists("movies.json"))
            {
                try
                {
                    string json = File.ReadAllText("movies.json");
                    var list = JsonSerializer.Deserialize<List<MovieInfo>>(json);
                    if (list != null)
                    {
                        _movies.Clear();
                        _movies.AddRange(list);
                        FillListViewFromMovies();
                    }
                }
                catch
                {
                    // lỗi đọc file thì bỏ qua
                }
            }
        }

        private async void btnDatVe_Click(object sender, EventArgs e)
        {
            if (lvMovies.SelectedItems.Count == 0)
            {
                MessageBox.Show("Hãy chọn một bộ phim để đặt vé!");
                return;
            }

            if (string.IsNullOrWhiteSpace(tb_CustomerName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên khách hàng!");
                return;
            }

            var item = lvMovies.SelectedItems[0];
            var movie = (MovieInfo)item.Tag;


            List<string> selectedSeats = new List<string>();
            foreach (Control control in this.Controls)
            {
                if (control is CheckBox cb && cb.Checked && cb.Name.StartsWith("cb_seat_"))
                {
                    selectedSeats.Add(cb.Name.Substring(8));
                }
            }

            numSoVe.Value = selectedSeats.Count;

            int soVe = (int)numSoVe.Value;
            if (soVe <= 0)
            {
                MessageBox.Show("Số vé phải > 0!");
                return;
            }


            const decimal giaVe = 55000m;
            decimal thanhTien = giaVe * soVe;
            tb_TongTien.Text = thanhTien.ToString("N0") + " VNĐ";

            string imageToSend = movie.LocalImagePath;

            if (!File.Exists(imageToSend))
            {
                imageToSend = "";
            }

            string seatsString = string.Join(",", selectedSeats);
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Khách hàng: {tb_CustomerName.Text}");
            stringBuilder.AppendLine($"Phim: {movie.Title}");
            stringBuilder.AppendLine($"Số vé: {soVe}");
            stringBuilder.AppendLine($"Thành tiền: {thanhTien:N0} VNĐ");
            stringBuilder.Append($"Ghế đã chọn: {seatsString}");

            await MailSending(stringBuilder.ToString(), imageToSend);
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            File.Delete("movies.json");
        }

        private async void lvMovies_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvMovies.SelectedItems.Count == 0) return;

            var item = lvMovies.SelectedItems[0];
            var movie = item.Tag as MovieInfo;
            if (movie == null) return;

            tb_SelectedMovie.Text = movie.Title;

            // Hiện chi tiết trong WebBrowser
            try
            {
                if (detailForm == null)
                {
                    detailForm = new Support();
                    detailForm.Show();
                    detailForm.LoadMovie(movie.DetailUrl);
                    detailForm.BringToFront();
                }
                else
                {
                    detailForm.LoadMovie(movie.DetailUrl);
                }
            }
            catch
            {
                MessageBox.Show("Không mở được trang chi tiết phim!");
            }
        }

        private async Task LoadMoviesFromWebAsync()
        {
            try
            {
                btnLoad.Enabled = false;
                progressBar1.Style = ProgressBarStyle.Marquee;
                progressBar1.MarqueeAnimationSpeed = 30;
                lvMovies.Items.Clear();
                imageListPoster.Images.Clear();
                _movies.Clear();

                string folderPath = Path.Combine(Application.StartupPath, "Posters");
                if (!Directory.Exists(folderPath)) Directory.CreateDirectory(folderPath);

                string html = await _http.GetStringAsync("/phim.htm");

                // Parse HTML với HtmlAgilityPack
                var doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(html);


                var movieNodes = doc.DocumentNode
                    .SelectNodes("//div[contains(@class,'col-lg-4') and contains(@class,'padding-bottom-30')]");

                if (movieNodes == null)
                {
                    MessageBox.Show("Không tìm thấy danh sách phim! Kiểm tra lại selector.");
                    return;
                }

                int index = 0;

                foreach (var node in movieNodes)
                {
                    // Lấy hình poster
                    var imgNode = node.SelectSingleNode(".//div[contains(@class,'pi-img-wrapper')]//img");
                    string posterUrl = imgNode?.GetAttributeValue("src", "").Trim();

                    // Tên phim + Link
                    var aNode = node.SelectSingleNode(".//div[contains(@class,'film-info')]//h3//a");
                    string movieTitle = aNode?.InnerText.Trim();
                    string movieLink = aNode?.GetAttributeValue("href", "").Trim();


                    // Convert link relative → absolute
                    if (!string.IsNullOrEmpty(movieLink) && !movieLink.StartsWith("http"))
                        movieLink = new Uri(_http.BaseAddress, movieLink).ToString();

                    if (!string.IsNullOrEmpty(posterUrl) && !posterUrl.StartsWith("http"))
                        posterUrl = new Uri(_http.BaseAddress, posterUrl).ToString();

                    string localPath = "";
                    Image posterImage = null;

                    try
                    {
                        if (!string.IsNullOrEmpty(posterUrl))
                        {
                            byte[] imageBytes = await _http.GetByteArrayAsync(posterUrl);

                            // Tạo tên file an toàn (xóa các ký tự đặc biệt)
                            string safeTitle = string.Join("_", movieTitle.Split(Path.GetInvalidFileNameChars()));
                            localPath = Path.Combine(folderPath, $"{safeTitle}_{index}.jpg");

                            // 1. Lưu file gốc chất lượng cao xuống ổ cứng
                            File.WriteAllBytes(localPath, imageBytes);

                            // 2. Load hình từ file vừa lưu lên để đưa vào ImageList
                            // Dùng MemoryStream để tránh khóa file (file lock)
                            using (var ms = new MemoryStream(imageBytes))
                            {
                                posterImage = Image.FromStream(ms);
                            }
                        }
                    }
                    catch { /* Lỗi tải ảnh thì thôi */ }

                    // Tạo object
                    var movie = new MovieInfo
                    {
                        Title = movieTitle,
                        DetailUrl = movieLink,
                        PosterUrl = posterUrl,
                        LocalImagePath = localPath
                    };

                    _movies.Add(movie);

                    // Tải poster
                    Image poster = null;
                    try
                    {
                        if (!string.IsNullOrEmpty(posterUrl))
                        {
                            var bytes = await _http.GetByteArrayAsync(posterUrl);
                            using (var ms = new MemoryStream(bytes))
                            {
                                poster = Image.FromStream(ms);
                            }
                        }
                    }
                    catch
                    {
                        // ignore
                    }

                    if (posterImage != null)
                        imageListPoster.Images.Add(posterImage);
                    else
                        imageListPoster.Images.Add(SystemIcons.Question);

                    var item = new ListViewItem(movieTitle, index);
                    item.SubItems.Add(movieLink);
                    item.Tag = movie;
                    lvMovies.Items.Add(item);

                    index++;
                }


                // Lưu JSON
                SaveMoviesToJson();

                MessageBox.Show($"Đã tải {_movies.Count} phim từ website!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu phim: " + ex.Message);
            }
            finally
            {
                progressBar1.Style = ProgressBarStyle.Blocks;
                progressBar1.MarqueeAnimationSpeed = 0;
                progressBar1.Value = 0;
                btnLoad.Enabled = true;
            }
        }

        private void SaveMoviesToJson()
        {
            try
            {
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true
                };
                string json = JsonSerializer.Serialize(_movies, options);
                File.WriteAllText("movies.json", json);
            }
            catch
            {
                // lỗi ghi file thì thôi, không cần crash chương trình
            }
        }

        // Dùng khi load dữ liệu từ file JSON
        private void FillListViewFromMovies()
        {
            lvMovies.Items.Clear();
            imageListPoster.Images.Clear();

            int index = 0;
            foreach (var m in _movies)
            {
                // Poster chỉ có nếu sau này bạn thêm code tải hình từ URL lưu lại.
                imageListPoster.Images.Add(SystemIcons.Question);

                var item = new ListViewItem(m.Title, index);
                item.SubItems.Add(m.DetailUrl);
                item.Tag = m;
                lvMovies.Items.Add(item);

                index++;
            }
        }

        private async Task MailSending(string msg, string imageFilePath)
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Beta Cinemas", "labrecall@gmail.com"));


                try
                {
                    var toAddress = MailboxAddress.Parse(tb_email.Text.Trim());
                    message.To.Add(toAddress);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Địa chỉ email khách hàng không đúng định dạng!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Dừng hàm ngay, không gửi nữa
                }

                message.Subject = "Thông tin đặt vé";

                var builder = new BodyBuilder();
                string htmlBody = "";

                if (!string.IsNullOrEmpty(imageFilePath) && File.Exists(imageFilePath))
                {
                    var image = builder.LinkedResources.Add(imageFilePath);
                    image.ContentId = MimeUtils.GenerateMessageId();
                    string htmlContent = msg.Replace(Environment.NewLine, "<br>");

                    htmlBody = $@"<html><body>
                            <h2>Xác nhận đặt vé thành công!</h2>
                            <div style='display:flex; gap: 20px;'>
                                <img src=""cid:{image.ContentId}"" alt=""Poster"" style=""width:150px; height:auto;"">
                                <div><p>{htmlContent}</p></div>
                            </div>
                          </body></html>";
                    builder.HtmlBody = htmlBody;
                }
                else
                {
                    builder.TextBody = msg;
                }

                message.Body = builder.ToMessageBody();

                using (var smtpClient = new SmtpClient())
                {
                    await smtpClient.ConnectAsync("smtp.gmail.com", 465, true);
                    await smtpClient.AuthenticateAsync("labrecall@gmail.com", "opmo xljk agmh yvmm");

                    await smtpClient.SendAsync(message);

                    await smtpClient.DisconnectAsync(true);
                }

                MessageBox.Show($"Đã gửi vé đến {tb_email.Text} thành công!");
            }
            catch (MailKit.Net.Smtp.SmtpCommandException ex)
            {
                switch (ex.ErrorCode)
                {
                    case SmtpErrorCode.RecipientNotAccepted:
                        MessageBox.Show("Server từ chối gửi đến địa chỉ email này. Có thể email không tồn tại.", "Lỗi gửi mail");
                        break;
                    case SmtpErrorCode.SenderNotAccepted:
                        MessageBox.Show("Địa chỉ gửi (sender) bị từ chối.", "Lỗi gửi mail");
                        break;
                    case SmtpErrorCode.MessageNotAccepted:
                        MessageBox.Show("Nội dung email bị từ chối (có thể do chứa spam).", "Lỗi gửi mail");
                        break;
                    default:
                        MessageBox.Show($"Lỗi SMTP ({ex.ErrorCode}): {ex.Message}", "Lỗi gửi mail");
                        break;
                }
            }
            catch (SmtpProtocolException ex)
            {
                MessageBox.Show("Lỗi giao thức kết nối SMTP: " + ex.Message, "Lỗi kết nối");
            }
            catch (SocketException)
            {
                MessageBox.Show("Không thể kết nối đến máy chủ Gmail. Vui lòng kiểm tra đường truyền mạng.", "Lỗi mạng");
            }
            catch (Exception ex)
            {
                // Lỗi chung chung khác
                MessageBox.Show("Đã xảy ra lỗi không mong muốn: " + ex.Message);
            }
        }
    }
}
