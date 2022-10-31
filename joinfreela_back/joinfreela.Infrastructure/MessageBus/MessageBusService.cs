using joinfreela.Domain.Interfaces.Services;
using RabbitMQ.Client;

namespace joinfreela.Infrastructure.MessageBus
{
    public class MessageBusService : IMessageBusService
    {
        public void Publish(string queue, byte[] message)
        {
            throw new NotImplementedException();
        }
        // private readonly ConnectionFactory _factory;
        // public MessageBusService()
        // {
        //     _factory = new ConnectionFactory
        //     {
        //         HostName = "localhost",
        //     };
        // }
        // public void Publish(string queue, byte[] message)
        // {
        //     using (var connection = _factory.CreateConnection())
        //     {
        //         using (var channel = connection.CreateModel())
        //         {
        //             //Garantir que a fila esteja criada
        //             channel.QueueDeclare(
        //                 queue:queue,
        //                 durable: false,
        //                 exclusive: false,
        //                 autoDelete: false,
        //                 arguments:null
        //             );
        //             //publicar a mensagem 
        //             channel.BasicPublish(
        //                 exchange:"",
        //                 routingKey:queue,
        //                 basicProperties:null,
        //                 body:message
        //             );
        //         }
        //     }
        // }
    }
}