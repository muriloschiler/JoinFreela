using System.Text;
using System.Text.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Payments.Domain.Domain;
using Payments.Domain.DTOS;
using Payments.Domain.DTOS.Base;
using Payments.Domain.Interfaces.Services;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Payments.Infrastructure.Consumers
{
    public class ProcessPaymentConsumer : BackgroundService
    {
        private const string PAYMENTS_PENDING_QUEUE = "PaymentsPending";
        private const string PAYMENTS_DONE_QUEUE = "PaymentsDone";
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
                queue: PAYMENTS_PENDING_QUEUE,
                durable:false,
                exclusive:false,
                autoDelete:false,
                arguments:null);

            _channel.QueueDeclare(
                queue: PAYMENTS_DONE_QUEUE,
                durable:false,
                exclusive:false,
                autoDelete:false,
                arguments:null);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new EventingBasicConsumer(_channel);
            SettingConsumerBehavior(consumer);

            _channel.BasicConsume(PAYMENTS_PENDING_QUEUE, false, consumer);
            return Task.CompletedTask;
        }

        private void SettingConsumerBehavior(EventingBasicConsumer consumer)
        {
            consumer.Received += (sender, eventArgs) =>
            {
                var request = DeserializeBytesArray<PaymentRequest>(eventArgs.Body.ToArray());
                ProcessPaymentAsync(request);
                PublishPaymentDone(request);

                _channel.BasicAck(eventArgs.DeliveryTag, false);
            };
        }

        private void PublishPaymentDone(PaymentRequest request)
        {
            var paymentDoneBytesArray = SerializeBytesArray(new PaymentDoneIntegrationEvent(request.Id));
            _channel.BasicPublish(
                exchange: "",
                routingKey: PAYMENTS_DONE_QUEUE,
                basicProperties: null,
                body: paymentDoneBytesArray
            );
        }

        private T DeserializeBytesArray<T>(byte[] byteArray)
        {
            var requestJson = Encoding.UTF8.GetString(byteArray);
            return JsonSerializer.Deserialize<T>(requestJson);
        }

        private byte[] SerializeBytesArray<T>(T model)
        {
            var requestJson = JsonSerializer.Serialize(model);
            var requestJsonBytes = Encoding.UTF8.GetBytes(requestJson);
            return requestJsonBytes;        
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