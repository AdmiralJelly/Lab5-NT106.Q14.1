using MailKit;
using MailKit.Net.Imap;
using MailKit.Search;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MimeKit;
using System.Threading.Tasks;

namespace Bai6
{
    public partial class Form1 : Form
    {
        private ImapService _imapService;
        private List<UniqueId> _currentUids;

        public Form1()
        {
            InitializeComponent();
            _imapService = new ImapService();
            _currentUids = new List<UniqueId>();
            ToggleState(false);
        }

        private void ToggleState(bool isLoggedIn)
        {
            grpLogin.Visible = !isLoggedIn; 
            grpLogin.Enabled = !isLoggedIn;
            grpSettings.Enabled = !isLoggedIn;

            btnCompose.Visible = isLoggedIn;
            btnRefresh.Visible = isLoggedIn;
            btnLogout.Visible = isLoggedIn;
            dataGridView1.Visible = isLoggedIn;
            
            if (isLoggedIn)
            {
                this.Height = 600; // Expand for grid
            }
            else
            {
                // this.Height = 250; // Collapse? Maybe not needed.
            }
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string user = txtUser.Text;
            string pass = txtPass.Text;
            string imapServer = txtImap.Text;
            int imapPort = (int)numImapPort.Value;

            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Vui lòng nhập tài khoản và mật khẩu.");
                return;
            }

            btnLogin.Enabled = false;
            btnLogin.Text = "Đang đăng nhập...";

            try
            {
                await _imapService.ConnectAsync(imapServer, imapPort, true);
                await _imapService.AuthenticateAsync(user, pass);

                MessageBox.Show("Đăng nhập thành công!");
                ToggleState(true);
                
                await LoadEmails();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đăng nhập thất bại: {ex.Message}");
                btnLogin.Enabled = true;
                btnLogin.Text = "Đăng nhập";
            }
        }

        private async Task LoadEmails()
        {
            try
            {
                dataGridView1.Rows.Clear();
                _currentUids = await _imapService.GetRecentEmailIdsAsync(50); // Get last 50
                var messages = await _imapService.GetHeadersAsync(_currentUids);
                
                int index = 0;
                
                foreach (var uid in _currentUids)
                {
                    var summary = messages.Find(m => m.UniqueId == uid);
                    if (summary != null)
                    {
                        dataGridView1.Rows.Add(
                            index++,
                            summary.Envelope.From.ToString(),
                            summary.Envelope.Subject,
                            summary.Envelope.Date.ToString()
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải mail: {ex.Message}");
            }
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            btnRefresh.Enabled = false;
            await LoadEmails();
            btnRefresh.Enabled = true;
        }

        private async void btnLogout_Click(object sender, EventArgs e)
        {
            await _imapService.DisconnectAsync();
            ToggleState(false);
            btnLogin.Enabled = true;
            btnLogin.Text = "Đăng nhập";
            dataGridView1.Rows.Clear();
        }

        private void btnCompose_Click(object sender, EventArgs e)
        {
            var frm = new SendMailForm(txtSmtp.Text, (int)numSmtpPort.Value, txtUser.Text, txtPass.Text);
            frm.ShowDialog();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < _currentUids.Count)
            {
                var uid = _currentUids[e.RowIndex];
                var frm = new ReadMailForm(_imapService, uid);
                frm.Show();
            }
        }
    }
}
