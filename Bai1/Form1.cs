namespace Bai1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(rtbBody.Text))
            {
                 MessageBox.Show("Please enter email content. Do not send empty mail!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                 return;
            }

            try
            {
                using (var client = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587))
                {
                    client.EnableSsl = true;
                    string password = "bweq jjqp hzwe wksz"; 
                    client.Credentials = new System.Net.NetworkCredential(txtFrom.Text, password);

                    var mail = new System.Net.Mail.MailMessage
                    {
                        From = new System.Net.Mail.MailAddress(txtFrom.Text),
                        Subject = txtSubject.Text,
                        Body = rtbBody.Text
                    };
                    mail.To.Add(txtTo.Text);

                    client.Send(mail);
                }
                MessageBox.Show("Email sent successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to send email.\nError: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
