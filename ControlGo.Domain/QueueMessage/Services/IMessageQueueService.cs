namespace ControlGo.Domain.QuequeMessage.Services
{
    public interface IMessageQueueService
    {
        Task PublishMessageAsync<T>(string queueName, T message);        
        Task PublishMessageAsync(string queueName, string message);
    }
}
