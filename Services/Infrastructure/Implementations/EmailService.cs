using MailKit.Net.Smtp;
using MimeKit;
using StageWise.Services.Infrastructure.Interfaces;

namespace StageWise.Services.Infrastructure.Implementations
{
    public class EmailService : IEmailService
    {
        public async Task SendEmail(string to, string subject, string body)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("StageWise", "your@email.com"));
            message.To.Add(MailboxAddress.Parse(to));
            message.Subject = subject;
            message.Body = new TextPart("plain") { Text = body };

            using var client = new SmtpClient();
            await client.ConnectAsync("smtp.gmail.com", 587, false);
            await client.AuthenticateAsync("email", "password");
            await client.SendAsync(message);
            await client.DisconnectAsync(true);
        }
    }
}