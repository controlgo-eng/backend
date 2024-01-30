namespace Worldsys.Domain.QuequeMessage.Services
{
    public interface IMessageQueueService
    {
        Task PublishMessageAsync<T>(string queueName, T message);
        
        //Task<T?> DequeueMessageAsync<T>(string queueName);

        Task PublishMessageAsync(string queueName, string message);

        //Task<string?> DequeueMessageAsync(string queueName);
    }
}
