using System;
using System.Windows.Forms;

namespace Bai6
{
    public partial class SendMailForm : Form
    {
        private string _smtpServer;
        private int _port;
        private string _username;
        private string _password;
        private SmtpService _smtpService;

        public SendMailForm(string smtpServer, int port, string username, string password)
        {
            InitializeComponent();
            _smtpServer = smtpServer;
            _port = port;
            _username = username;
            _password = password;
            _smtpService = new SmtpService();

            txtFrom.Text = username;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtAttachment.Text = openFileDialog.FileName;
            }
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            string to = txtTo.Text;
            string subject = txtSubject.Text;
            string body = rtbBody.Text;
            string attachment = txtAttachment.Text;
            bool isHtml = chkHtml.Checked;

            btnSend.Enabled = false;
            btnSend.Text = "Sending...";

            try
            {
                await _smtpService.SendEmailAsync(_smtpServer, _port, true, _username, _password, to, subject, body, attachment, isHtml);
                MessageBox.Show("Gửi mail thành công!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gửi mail thất bại: {ex.Message}");
                btnSend.Enabled = true;
                btnSend.Text = "Send";
            }
        }
    }
}
