using RabbitMQ.Client;
using StageWise.Services.Infrastructure.Interfaces;
using System.Text;

namespace StageWise.Services.Infrastructure.Implementations
{
    public class RabbitMqService : IMessageQueue
    {
         private readonly IConnection _connection;
        private readonly IChannel _channel;
        private readonly IConfiguration _configuration;

        public RabbitMqService(IConfiguration configuration)
        {
            _configuration = configuration;

            var factory = new ConnectionFactory()
            {
                Uri = new Uri(_configuration["RabbitMQ:Url"]!)
            };

            _connection = factory.CreateConnectionAsync().Result;
            _channel = _connection.CreateChannelAsync().Result;
        }

        public async Task Publish(string queueName, string message)
        {
            var properties = new BasicProperties();

            await _channel.QueueDeclareAsync(
                queue: queueName,
                durable: false,
                exclusive: false,
                autoDelete: false);

            var body = Encoding.UTF8.GetBytes(message);

            await _channel.BasicPublishAsync(
                exchange: "",
                routingKey: queueName,
                mandatory: false,
                basicProperties: properties,
                body: body);
        }
    }
}