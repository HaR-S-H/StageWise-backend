using RabbitMQ.Client;
using System.Text;

namespace StageWise.Services.Infrastructure.Implementations
{
    public class RabbitMQService : IMessageQueue
    {
        private readonly string _hostName = "localhost";

        public async Task Publish(string queueName, string message)
        {
            var factory = new ConnectionFactory()
            {
                HostName = _hostName
            };

            await using var connection = await factory.CreateConnectionAsync();
            await using var channel = await connection.CreateChannelAsync();
            var properties = new BasicProperties();
            // Create queue if not exists
            await channel.QueueDeclareAsync(
                queue: queueName,
                durable: false,
                exclusive: false,
                autoDelete: false);

            var body = Encoding.UTF8.GetBytes(message);

            // Publish message
          await channel.BasicPublishAsync<BasicProperties>(
    exchange: "",
    routingKey: queueName,
    mandatory: false,
    basicProperties: properties,
    body: body);
        }
    }
}