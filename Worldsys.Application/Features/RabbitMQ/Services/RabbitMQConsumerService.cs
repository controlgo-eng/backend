using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using Worldsys.Application.Features.Customers.Services;

namespace Worldsys.Application.Features.RabbitMQ.Services
{


    public class RabbitMQConsumerService : BackgroundService
    {
        private readonly string _hostName;
        private readonly string _queueName;
        private readonly IConnection _connection;
        private readonly IModel _channel;
        
        public RabbitMQConsumerService(IConfiguration configuration)
        {
            _hostName = configuration.GetSection("RabbitMQ:HostName").Value ?? "";
            _queueName = configuration.GetSection("RabbitMQ:QueueName").Value ?? "";

            if (string.IsNullOrEmpty(_hostName)) throw new ArgumentNullException("HostName no definido");
            if (string.IsNullOrEmpty(_queueName)) throw new ArgumentNullException("QueueName no definido");

            var factory = new ConnectionFactory() { HostName = _hostName };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: _queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += async (moduleHandle, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);

                await HandleMessage(message);

                _channel.BasicAck(ea.DeliveryTag, multiple: false);
            };

            _channel.BasicConsume(queue: _queueName, autoAck: false, consumer: consumer);

            return Task.CompletedTask;
        }

        private async Task HandleMessage(string message)
        {
            try
            {
                // Quitar los corchetes exteriores del array JSON y reemplazar los caracteres de escape
                string cleanedMessage = message.Trim(new char[] { '[', ']' }).Trim('\"').Replace("\\\"", "\"");


                //Aqui agregar la logica que se requiera realizar al obtener el mensaje de la cola
                var dataProcessCustomerService = new DataProcessCustomerService();

                await dataProcessCustomerService.ProcessData(cleanedMessage);


                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al procesar el mensaje: {ex.Message}");
            }
        }



        public override void Dispose()
        {
            if (_channel.IsOpen)
            {
                _channel.Close();
                _connection.Close();
            }
            base.Dispose();
        }

    }
}