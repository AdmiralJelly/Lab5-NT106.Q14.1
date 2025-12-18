using MailKit;
using MimeKit;
using System;
using System.Windows.Forms;

namespace Bai6
{
    public partial class ReadMailForm : Form
    {
        private ImapService _imapService;
        private UniqueId _uid;

        public ReadMailForm(ImapService imapService, UniqueId uid)
        {
            InitializeComponent();
            _imapService = imapService;
            _uid = uid;
        }

        private async void ReadMailForm_Load(object sender, EventArgs e)
        {
            try
            {
                var message = await _imapService.GetMessageAsync(_uid);
                if (message != null)
                {
                    lblFrom.Text = $"From: {message.From}";
                    lblTo.Text = $"To: {message.To}";
                    lblSubject.Text = message.Subject;
                    
                    if (!string.IsNullOrEmpty(message.HtmlBody))
                    {
                        webBrowser1.DocumentText = message.HtmlBody;
                    }
                    else
                    {
                         webBrowser1.DocumentText = $"<pre>{message.TextBody}</pre>";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải nội dung mail: {ex.Message}");
            }
        }
    }
}
