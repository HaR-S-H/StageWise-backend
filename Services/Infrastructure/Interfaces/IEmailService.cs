namespace StageWise.Services.Infrastructure.Interfaces;

public interface IEmailService
{
    Task SendEmail(string to, string subject, string body);
}