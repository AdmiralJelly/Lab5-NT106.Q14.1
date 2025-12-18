using MailKit.Net.Smtp;
using MimeKit;
using System.Threading.Tasks;

namespace Bai6
{
    public class SmtpService
    {
        public async Task SendEmailAsync(string host, int port, bool useSsl, string username, string password, string to, string subject, string body, string attachmentPath = null, bool isHtml = false)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Me", username));
            message.To.Add(new MailboxAddress("", to));
            message.Subject = subject;

            var builder = new BodyBuilder();
            if (isHtml)
            {
                builder.HtmlBody = body;
            }
            else
            {
                builder.TextBody = body;
            }

            if (!string.IsNullOrEmpty(attachmentPath))
            {
                builder.Attachments.Add(attachmentPath);
            }

            message.Body = builder.ToMessageBody();

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(host, port, useSsl);
                await client.AuthenticateAsync(username, password);
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
        }
    }
}
