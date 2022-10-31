using System.Text;
using System.Text.Json;
using joinfreela.Domain.IntegrationsEvents;
using joinfreela.Domain.Interfaces.Repositories;
using joinfreela.Domain.Interfaces.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace joinfreela.Infrastructure.Consumers
{
    public class PaymentDoneConsumer : BackgroundService
    {
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            return Task.CompletedTask;
        }
    // {
    //     private const string PAYMENTS_DONE_QUEUE = "PaymentsDone";
    //     public readonly IConnection _connection;
    //     public readonly IModel _channel;
    //     public readonly IServiceProvider _serviceProvider;

    //     public PaymentDoneConsumer(IServiceProvider serviceProvider)
    //     {
    //         _serviceProvider = serviceProvider;

    //         var connectionFactory = new ConnectionFactory
    //         {
    //             HostName = "localhost"
    //         };

    //         _connection = connectionFactory.CreateConnection();
    //         _channel = _connection.CreateModel();

    //         _channel.QueueDeclare(
    //             queue: PAYMENTS_DONE_QUEUE,
    //             durable:false,
    //             exclusive:false,
    //             autoDelete:false,
    //             arguments:null);
    //     }

    //     protected override Task ExecuteAsync(CancellationToken stoppingToken)
    //     {
    //         var consumer = new EventingBasicConsumer(_channel);
    //         SettingConsumerBehavior(consumer);

    //         _channel.BasicConsume(PAYMENTS_DONE_QUEUE, false, consumer);
    //         return Task.CompletedTask;
    //     }

    //     private void SettingConsumerBehavior(EventingBasicConsumer consumer)
    //     {
    //         consumer.Received += async (sender, eventArgs) =>
    //         {
    //             var paymentDone = DeserializeBytesArray<PaymentDoneIntegrationEvent>(eventArgs.Body.ToArray());   
    //             await SetModelPaymentDone(paymentDone);
    //             _channel.BasicAck(eventArgs.DeliveryTag, false);
    //         };
    //     }

    //     private async Task SetModelPaymentDone(PaymentDoneIntegrationEvent paymentDone)
    //     {
    //         using(var scope = _serviceProvider.CreateScope())
    //         {
    //             var contractRepository = scope.ServiceProvider.GetService<IContractRepository>();
    //             var payment = contractRepository.Query()
    //                 .SelectMany(co=>co.Payments)
    //                 .FirstOrDefault(pa=>pa.Id == paymentDone.PaymentId);

    //             payment.Pending = 1;

    //             await scope.ServiceProvider.GetService<IUnityOfWork>().CommitChangesAsync();

    //         }
    //     }

    //     private T DeserializeBytesArray<T>(byte[] byteArray)
    //     {
    //         var requestJson = Encoding.UTF8.GetString(byteArray);
    //         return JsonSerializer.Deserialize<T>(requestJson);
    //     }

    //     private byte[] SerializeBytesArray<T>(T model)
    //     {
    //         var requestJson = JsonSerializer.Serialize(model);
    //         var requestJsonBytes = Encoding.UTF8.GetBytes(requestJson);
    //         return requestJsonBytes;        
    //     }
    }
}