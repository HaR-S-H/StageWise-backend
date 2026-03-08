using System.Text;
using System.Text.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using StageWise.Services.Infrastructure.Interfaces;
using StageWise.Services.Infrastructure.Models;

namespace StageWise.Services.Infrastructure.Workers
{
    public class S3Worker : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly IConfiguration _configuration;

        public S3Worker(IServiceScopeFactory scopeFactory, IConfiguration configuration)
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
                queue: "S3UploadQueue",
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

                    var fileMessage = JsonSerializer.Deserialize<S3UploadMessage>(json);

                    if (fileMessage != null)
                    {
                        using var scope = _scopeFactory.CreateScope();

                        var s3Service = scope.ServiceProvider
                            .GetRequiredService<IS3Service>();

                        await s3Service.UploadBytesAsync(
    fileMessage.FileBytes,
    fileMessage.Key,
    fileMessage.ContentType
);
                    }

                    await channel.BasicAckAsync(ea.DeliveryTag, false);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"S3 Upload Error: {ex.Message}");
                }
            };

            await channel.BasicConsumeAsync(
                queue: "S3UploadQueue",
                autoAck: false,
                consumer: consumer);

            await Task.Delay(Timeout.Infinite, stoppingToken);
        }
    }
}