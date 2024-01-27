namespace Worldsys.Domain.QuequeMessage.Services
{
    public interface IMessageQueueService
    {
        void EnqueueMessageAsync<T>(string queueName, T message);
        
        Task<T?> DequeueMessageAsync<T>(string queueName);

        void EnqueueMessageAsync(string queueName, string message);

        Task<string?> DequeueMessageAsync(string queueName);
    }
}
