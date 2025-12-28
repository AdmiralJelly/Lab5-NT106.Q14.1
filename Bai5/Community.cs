using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai5
{
    public partial class Community : Form
    {
        public string UserEmail { get; set; } = "";
        public string UserPassword { get; set; } = "";

        private string _userEmail = "";
        private string _userPassword = "";

        private const string RECEIVER_EMAIL = "labrecall@gmail.com";

        public Community()
        {
            InitializeComponent();

            tb_psw.UseSystemPasswordChar = true;

            ptb_donggop.SizeMode = PictureBoxSizeMode.Zoom;
            ptb_image.SizeMode = PictureBoxSizeMode.Zoom;

            btn_add.Visible = false;
            btn_reset.Visible = false;
            btn_reset2.Visible = false;

            this.Load += Community_Load;

            btn_src.Click += btn_src_Click;
            btn_add.Click += btn_add_Click;
            btn_find.Click += btn_find_Click;

            cb_showpsw.CheckedChanged += cb_showpsw_CheckedChanged;
            btn_reset.Click += btn_reset_Click;
            btn_reset2.Click += btn_reset2_Click;

            tb_foodname.TextChanged += AnyInput_Changed;
            tb_image.TextChanged += AnyInput_Changed;
            rtb_info.TextChanged += AnyInput_Changed;
        }

        private async void Community_Load(object? sender, EventArgs e)
        {
            _userEmail = (UserEmail ?? "").Trim();
            _userPassword = (UserPassword ?? "").Replace(" ", "");

            tb_email.Text = _userEmail;
            tb_psw.Text = _userPassword;

            Database.Init();

            try
            {
                int imported = await Database.ImportEmailContributionsAsync(_userEmail, _userPassword);
                if (imported > 0)
                    MessageBox.Show($"Đã tải {imported} đóng góp mới từ email.");
            }
            catch
            {
                // bỏ qua nếu không import được
            }

            UpdateButtonsVisibility();
        }

        private void cb_showpsw_CheckedChanged(object? sender, EventArgs e)
        {
            tb_psw.UseSystemPasswordChar = !cb_showpsw.Checked;
        }

        private void AnyInput_Changed(object? sender, EventArgs e)
        {
            UpdateButtonsVisibility();
        }

        private void UpdateButtonsVisibility()
        {
            btn_add.Visible =
                !string.IsNullOrWhiteSpace(tb_foodname.Text) &&
                !string.IsNullOrWhiteSpace(tb_image.Text);

            btn_reset.Visible =
                !string.IsNullOrWhiteSpace(rtb_info.Text) ||
                ptb_image.Image != null;

            btn_reset2.Visible =
                !string.IsNullOrWhiteSpace(tb_foodname.Text) ||
                !string.IsNullOrWhiteSpace(tb_image.Text) ||
                ptb_donggop.Image != null;
        }

        private void btn_src_Click(object? sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (ofd.ShowDialog() != DialogResult.OK) return;

                tb_image.Text = ofd.FileName;

                try
                {
                    using (var img = Image.FromFile(ofd.FileName))
                        ptb_donggop.Image = new Bitmap(img);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không đọc được ảnh: " + ex.Message);
                    ptb_donggop.Image = null;
                }
            }

            UpdateButtonsVisibility();
        }

        private void btn_reset_Click(object? sender, EventArgs e)
        {
            rtb_info.Clear();
            ptb_image.Image = null;
            UpdateButtonsVisibility();
        }

        private void btn_reset2_Click(object? sender, EventArgs e)
        {
            tb_foodname.Clear();
            tb_image.Clear();
            ptb_donggop.Image = null;
            UpdateButtonsVisibility();
        }

        private async void btn_add_Click(object? sender, EventArgs e)
        {
            string dishName = tb_foodname.Text.Trim();
            string imagePath = tb_image.Text.Trim();

            if (string.IsNullOrWhiteSpace(dishName) || ptb_donggop.Image == null)
            {
                MessageBox.Show("Vui lòng nhập tên món ăn và chọn hình ảnh.");
                return;
            }

            if (string.IsNullOrWhiteSpace(_userEmail) || string.IsNullOrWhiteSpace(_userPassword))
            {
                MessageBox.Show("Thiếu thông tin đăng nhập. Vui lòng đăng nhập lại.");
                return;
            }

            btn_add.Enabled = false;

            try
            {
                byte[] imgBytes = Database.ImageToBytes(ptb_donggop.Image);

                // Nếu trùng tên => InsertDish trả false => KHÔNG báo thành công
                bool inserted = Database.InsertDish(dishName, imgBytes, _userEmail, "Người ẩn danh");

                if (!inserted)
                {
                    MessageBox.Show("Món ăn này đã có trong cơ sở dữ liệu (tên bị trùng).");
                    return;
                }

                await SendContributionMailAsync(dishName, imagePath);

                MessageBox.Show("Đóng góp thành công!");
                btn_reset2_Click(null, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đóng góp: " + ex.Message);
            }
            finally
            {
                btn_add.Enabled = true;
            }
        }

        private async Task SendContributionMailAsync(string dishName, string imagePath)
        {
            using (var smtpClient = new SmtpClient("smtp.gmail.com"))
            {
                smtpClient.Port = 587;
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(_userEmail, _userPassword);

                using (var mail = new MailMessage())
                {
                    mail.From = new MailAddress(_userEmail);
                    mail.To.Add(RECEIVER_EMAIL);
                    mail.Subject = "Đóng góp món ăn";
                    mail.Body = $"{dishName};{Path.GetFileName(imagePath)}";

                    if (File.Exists(imagePath))
                        mail.Attachments.Add(new Attachment(imagePath));

                    await smtpClient.SendMailAsync(mail);
                }
            }
        }

        private void btn_find_Click(object? sender, EventArgs e)
        {
            try
            {
                Dish? dish = Database.GetOneRandomDish();

                if (dish == null)
                {
                    MessageBox.Show("Chưa có món ăn nào trong cộng đồng. Hãy đóng góp trước!");
                    return;
                }

                rtb_info.Clear();
                rtb_info.AppendText($"Món ăn: {dish.Name}\n");
                rtb_info.AppendText($"Đóng góp bởi: {dish.ContributorName}\n");
                rtb_info.AppendText($"Email: {dish.UserEmail}\n");
                rtb_info.AppendText($"Thời gian: {dish.CreatedAt}\n");

                ptb_image.Image = (dish.Image != null && dish.Image.Length > 0)
                    ? Database.BytesToImage(dish.Image)
                    : null;

                UpdateButtonsVisibility();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
            }
        }

        private void btn_dropdb_Click(object? sender, EventArgs e)
        {
            var confirm = MessageBox.Show(
                "Xoá toàn bộ dữ liệu hiện tại? (Không thể hoàn tác)",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            try
            {
                Database.ClearAllData();

                rtb_info.Clear();
                ptb_image.Image = null;

                tb_foodname.Clear();
                tb_image.Clear();
                ptb_donggop.Image = null;

                UpdateButtonsVisibility();

                MessageBox.Show("Đã xoá toàn bộ dữ liệu trong database!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xoá dữ liệu thất bại: " + ex.Message);
            }
        }

        private void tb_email_TextChanged(object? sender, EventArgs e) { }
    }
}
