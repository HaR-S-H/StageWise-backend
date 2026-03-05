using MailKit.Net.Smtp;
using MimeKit;
using StageWise.Services.Infrastructure.Interfaces;

namespace StageWise.Services.Infrastructure.Implementations
{
    public class EmailService : IEmailService
    {
       private readonly IConfiguration _configuration;

    public EmailService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task SendEmail(string to, string subject, string body)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress("StageWise", _configuration["Email:User"]!));
        message.To.Add(MailboxAddress.Parse(to));
        message.Subject = subject;
        message.Body = new TextPart("plain") { Text = body };

        using var client = new SmtpClient();

        await client.ConnectAsync(
            _configuration["Email:Host"],
            int.Parse(_configuration["Email:Port"]!),
            false);

        await client.AuthenticateAsync(
            _configuration["Email:User"],
            _configuration["Email:Password"]);

        await client.SendAsync(message);
        await client.DisconnectAsync(true);
    }
    }
}