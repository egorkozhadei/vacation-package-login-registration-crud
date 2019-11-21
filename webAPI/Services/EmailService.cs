using System;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;

namespace WebAPI
{
    public class EmailService
    {
        public async Task SendMessageAsync(string email, string message, string subject)
        {
            var mailer = new MimeMessage {Body = new TextPart(TextFormat.Text) {Text = message}};
            
            mailer.From.Add(new MailboxAddress("ii334361@gmail.com", ""));
            mailer.To.Add(new MailboxAddress(subject, email));

            using var client = new SmtpClient();

            await client.ConnectAsync("smtp.gmail.com", 465, true);

            await client.AuthenticateAsync("ii334361@gmail.com", "abc334361!322");

            await client.SendAsync(mailer);

            await client.DisconnectAsync(true);
        }
    }
}