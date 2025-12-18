using MailKit;
using MailKit.Net.Imap;
using MailKit.Search;
using MimeKit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Bai_2_IMAP
{
    public partial class IMAP : Form
    {
        public IMAP()
        {
            InitializeComponent();
        }
        // //string server = "imap.gmail.com";
        // //int port = 993;
        // //string gmail = "lukeeucliffeccg@gmail.com";
        // //string password = "ajkohmqcdlgknxle";
        // //int limit = 10;
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void cb_show_pass_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_show_pass.Checked)
            {
                txt_password.PasswordChar = '\0';
            }
            else
            {
                txt_password.PasswordChar = '*';
            }
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
                var client = new ImapClient();
                client.Connect("imap.gmail.com", 993, true);
                client.Authenticate(txt_email.Text, txt_password.Text);
                
                var inbox = client.Inbox;
                inbox.Open(FolderAccess.ReadOnly);

                lbTotalValue.Text = inbox.Count.ToString();
                lbRecentValue.Text = inbox.Recent.ToString();

                dataGridView1.Columns.Add("Email", "Email");
                dataGridView1.Columns.Add("From", "From");
                dataGridView1.Columns.Add("Date", "Thời gian");
                dataGridView1.Columns["Email"].ReadOnly = true;
                dataGridView1.Columns["From"].ReadOnly = true;
                dataGridView1.Columns["Date"].ReadOnly = true;
                
                int limit = 0;
                for (int i = inbox.Count - 1; i > 0; i--)
                {
                    limit++;
                    var message = inbox.GetMessage(i);
                    string subject = message.Subject;
                    string from = message.From.ToString();
                    DateTime date = message.Date.DateTime;
                    dataGridView1.Rows.Add(subject, from, date);
                    if (limit == 5)
                    {
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}

