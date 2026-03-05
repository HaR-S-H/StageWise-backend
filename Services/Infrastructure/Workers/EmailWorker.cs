using System.Text;
using System.Text.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using StageWise.Services.Infrastructure.Interfaces;
using StageWise.Services.Infrastructure.Models;
namespace StageWise.Services.Infrastructure.Workers
{
    public class EmailWorker : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly IConfiguration _configuration;

        public EmailWorker(IServiceScopeFactory scopeFactory, IConfiguration configuration)
        {
            _scopeFactory = scopeFactory;
            _configuration = configuration;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var factory = new ConnectionFactory()
            {
                Uri = new Uri(_configuration["RabbitMQ:Url"]!)
            };

            var connection = await factory.CreateConnectionAsync();
            var channel = await connection.CreateChannelAsync();

            await channel.QueueDeclareAsync(
                queue: "EmailQueue",
                durable: false,
                exclusive: false,
                autoDelete: false);

            var consumer = new AsyncEventingBasicConsumer(channel);

            consumer.ReceivedAsync += async (_, ea) =>
            {
                try
                {
                    var body = ea.Body.ToArray();
                    var json = Encoding.UTF8.GetString(body);

                    var email = JsonSerializer.Deserialize<EmailMessage>(json);

                    if (email != null)
                    {
                        using var scope = _scopeFactory.CreateScope();

                        var emailService = scope.ServiceProvider
                            .GetRequiredService<IEmailService>();

                        await emailService.SendEmail(
                            email.To,
                            email.Subject,
                            email.Body);
                    }

                    await channel.BasicAckAsync(ea.DeliveryTag, false);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            };

            await channel.BasicConsumeAsync(
                queue: "EmailQueue",
                autoAck: false,
                consumer: consumer);

            await Task.Delay(Timeout.Infinite, stoppingToken);
        }
    }
}