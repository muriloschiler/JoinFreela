namespace joinfreela.Domain.Interfaces.Services
{
    public interface IMessageBusService
    {
        void Publish(string queue, byte[] message);
    }
}