using System.Text;
using System.Text.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Payments.Domain.DTOS;
using Payments.Domain.Interfaces.Services;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Payments.Infrastructure.Consumers
{
    public class ProcessPaymentConsumer : BackgroundService
    {
        private const string QUEUE_NAME = "Payments";
        public readonly IConnection _connection;
        public readonly IModel _channel;
        public readonly IServiceProvider _serviceProvider;

        public ProcessPaymentConsumer(IConnection connection, IModel channel, IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;

            var connectionFactory = new ConnectionFactory
            {
                HostName = "localhost"
            };

            _connection = connectionFactory.CreateConnection();
            _channel = _connection.CreateModel();

            _channel.QueueDeclare(
                queue: QUEUE_NAME,
                durable:false,
                exclusive:false,
                autoDelete:false,
                arguments:null);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new EventingBasicConsumer(_channel);
            SettingConsumerBehavior(consumer);

            _channel.BasicConsume(QUEUE_NAME, false, consumer);
            return Task.CompletedTask;
        }

        private void SettingConsumerBehavior(EventingBasicConsumer consumer)
        {
            consumer.Received += (sender, eventArgs) =>
            {
                var byteArray = eventArgs.Body.ToArray();
                var requestJson = Encoding.UTF8.GetString(byteArray);
                var request = JsonSerializer.Deserialize<PaymentRequest>(requestJson);
                ProcessPaymentAsync(request);
                _channel.BasicAck(eventArgs.DeliveryTag, false);
            };
        }

        private async Task ProcessPaymentAsync(PaymentRequest request)
        {
            
            using(var scope = _serviceProvider.CreateScope())
            {
                var paymentService = scope.ServiceProvider.GetService<IPaymentService>();
                await paymentService.ProcessPayment(request);
            }
        }
    }
}