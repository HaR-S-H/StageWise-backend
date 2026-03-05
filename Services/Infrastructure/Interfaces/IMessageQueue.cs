namespace StageWise.Services.Infrastructure.Interfaces
{
   public interface IMessageQueue
{
    Task Publish(string queueName, string message);
}
}

