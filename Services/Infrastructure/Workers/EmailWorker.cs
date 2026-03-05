using System.Text;
using System.Text.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using StageWise.Services.Infrastructure.Interfaces;
using StageWise.Services.Infrastructure.Models;

namespace StageWise.Services.Infrastructure.Workers
{
    public class EmailWorker
    {
       private readonly IEmailService _emailService;
        private readonly IConfiguration _configuration;

        public EmailWorker(IEmailService emailService, IConfiguration configuration)
        {
            _emailService = emailService;
            _configuration = configuration;
        }

        public async Task Start()
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

                    await _emailService.SendEmail(
                        email!.To,
                        email.Subject,
                        email.Body);

                    await channel.BasicAckAsync(ea.DeliveryTag, false);
                }
                catch
                {
                    await channel.BasicNackAsync(ea.DeliveryTag, false, true);
                }
            };

            await channel.BasicConsumeAsync(
                queue: "EmailQueue",
                autoAck: false,
                consumer: consumer);
        }
    }
}