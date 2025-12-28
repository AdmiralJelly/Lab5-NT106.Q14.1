using System;
using System.Windows.Forms;
using MailKit.Net.Smtp; // Sử dụng MailKit để gửi mail [cite: 2445]
using MimeKit;

namespace TestMail
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnSendTest_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMyEmail.Text) || string.IsNullOrEmpty(txtAppPass.Text))
            {
                MessageBox.Show("Vui lòng nhập Email và App Password!");
                return;
            }

            btnSendTest.Enabled = false;
            try
            {
                var message = new MimeMessage();

                // Thiết lập người gửi. Nếu txtSenderName trống, hệ thống sẽ coi là ẩn danh 
                string displayName = string.IsNullOrWhiteSpace(txtSenderName.Text) ? "" : txtSenderName.Text;
                message.From.Add(new MailboxAddress(displayName, txtMyEmail.Text));

                // Địa chỉ nhận cố định để tạo database cho bài Lab 5
                message.To.Add(new MailboxAddress("Admin", "ngovantinh27092005@gmail.com"));


                message.Subject = "Đóng góp món ăn";

         
                message.Body = new TextPart("plain")
                {
                    Text = $"{txtFoodName.Text.Trim()};{txtImageLink.Text.Trim()}"
                };

                using (var client = new MailKit.Net.Smtp.SmtpClient()) // Tránh lỗi CS0104
                {
          
                    await client.ConnectAsync("smtp.gmail.com", 465, true);
                    await client.AuthenticateAsync(txtMyEmail.Text, txtAppPass.Text);

                    await client.SendAsync(message);
                    MessageBox.Show("Đã gửi mail đóng góp thành công!");

                    await client.DisconnectAsync(true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi gửi mail: " + ex.Message);
            }
            btnSendTest.Enabled = true;
        }
    }
}