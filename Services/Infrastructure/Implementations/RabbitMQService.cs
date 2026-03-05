using RabbitMQ.Client;
using StageWise.Services.Infrastructure.Interfaces;
using System.Text;

namespace StageWise.Services.Infrastructure.Implementations
{
    public class RabbitMqService : IMessageQueue
    {
        private readonly string _hostName = "localhost";
        private readonly IConnection _connection;
        private readonly IChannel _channel;

        public RabbitMqService()
        {
            var factory = new ConnectionFactory()
            {
                HostName = _hostName
            };

            _connection = factory.CreateConnectionAsync().Result;
            _channel = _connection.CreateChannelAsync().Result;
        }

        public async Task Publish(string queueName, string message)
        {
            var properties = new BasicProperties();
            // Create queue if not exists
            await _channel.QueueDeclareAsync(
                queue: queueName,
                durable: false,
                exclusive: false,
                autoDelete: false);

            var body = Encoding.UTF8.GetBytes(message);

            // Publish message
            await _channel.BasicPublishAsync(
                exchange: "",
                routingKey: queueName,
                mandatory: false,
                basicProperties: properties,
                body: body);
        }
    }
}