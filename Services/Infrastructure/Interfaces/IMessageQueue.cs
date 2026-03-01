public interface IMessageQueue
{
    Task Publish(string queueName, string message);
}