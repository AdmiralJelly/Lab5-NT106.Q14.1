using System;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace Bai5
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();

            tb_psw.UseSystemPasswordChar = true;
            cb_showpsw.CheckedChanged += cb_showpsw_CheckedChanged;
            this.AcceptButton = btn_login;
        }

        private void cb_showpsw_CheckedChanged(object? sender, EventArgs e)
        {
            tb_psw.UseSystemPasswordChar = !cb_showpsw.Checked;
        }

        private async void btn_login_Click(object sender, EventArgs e)
        {
            string email = tb_email.Text.Trim();
            string password = tb_psw.Text.Replace(" ", "");

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Email và Password.");
                return;
            }

            // Check email format
            try { _ = new MailAddress(email); }
            catch
            {
                MessageBox.Show("Email không hợp lệ.");
                return;
            }

            btn_login.Enabled = false;
            btn_login.Text = "Checking...";

            try
            {
                using (var smtpClient = new SmtpClient("smtp.gmail.com"))
                {
                    smtpClient.Port = 587;
                    smtpClient.EnableSsl = true;
                    smtpClient.Credentials = new NetworkCredential(email, password);

                    using (var mail = new MailMessage())
                    {
                        mail.From = new MailAddress(email);
                        mail.To.Add(email);
                        mail.Subject = "Login Check";
                        mail.Body = "Success";

                        await smtpClient.SendMailAsync(mail); // không đơ UI
                    }
                }

                MessageBox.Show("Đăng nhập thành công!");

                var communityForm = new Community
                {
                    UserEmail = email,
                    UserPassword = password
                };

                this.Hide();
                communityForm.ShowDialog();
                this.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đăng nhập thất bại: " + ex.Message +
                                "\n(Lưu ý: Gmail cần App Password)");
            }
            finally
            {
                btn_login.Enabled = true;
                btn_login.Text = "Login";
            }
        }
    }
}
