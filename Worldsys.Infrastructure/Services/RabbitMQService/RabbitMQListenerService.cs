using Microsoft.Extensions.Hosting;
using Worldsys.Domain.Customers.Models;
using Worldsys.Domain.QuequeMessage.Services;

namespace Worldsys.Infrastructure.Services.RabbitMQService
{

    public class RabbitMQListenerService : BackgroundService
    {
        private readonly IMessageQueueService _messageQueueService;

        public RabbitMQListenerService(IMessageQueueService messageQueueService)
        {
            _messageQueueService = messageQueueService ?? throw new ArgumentNullException(nameof(messageQueueService));
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    // Dequeue a message from RabbitMQ
                    var message = await _messageQueueService.DequeueMessageAsync("Customer");

                    if (message != null)
                    {
                        // Handle the received message
                        Console.WriteLine($"Received message: {message}");
                    }
                }
                catch (Exception ex)
                {
                    // Handle exceptions if needed
                    Console.WriteLine($"Error processing message: {ex.Message}");
                }

                // Adjust the delay based on your needs
                await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
            }
        }
    }
}
