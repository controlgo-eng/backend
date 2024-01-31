using RabbitMQ.Client;
using System.Text;
using Worldsys.Domain.QuequeMessage.Services;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;

namespace Worldsys.Infrastructure.Services.RabbitMQService
{
    public class RabbitMQService : IMessageQueueService
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public RabbitMQService(IConfiguration configuration)
        {
            var hostName = configuration.GetSection("RabbitMQ:HostName").Value ?? "";

            if (string.IsNullOrEmpty(hostName)) throw new ArgumentNullException("HostName no definido");

            var userName = configuration.GetSection("RabbitMQ:Username").Value ?? "";
            var password = configuration.GetSection("RabbitMQ:Password").Value ?? "";
                        
            ConnectionFactory factory;

            if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password))
            {
                factory = new ConnectionFactory
                {
                    HostName = hostName,
                    UserName = userName,
                    Password = password
                };
            }
            else
            {
                factory = new ConnectionFactory
                {
                    HostName = hostName,
                };
            }

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
        }

        public Task PublishMessageAsync<T>(string queueName, T message)
        {
            _channel.QueueDeclare(queue: queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));

            _channel.BasicPublish(exchange: "", routingKey: queueName, basicProperties: null, body: body);

            return Task.CompletedTask;
        }

        public Task PublishMessageAsync(string queueName, string message)
        {
            _channel.QueueDeclare(queue: queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

            var body = Encoding.UTF8.GetBytes(message);

            _channel.BasicPublish(exchange: "", routingKey: queueName, basicProperties: null, body: body);

            return Task.CompletedTask;
        }
    }
}
