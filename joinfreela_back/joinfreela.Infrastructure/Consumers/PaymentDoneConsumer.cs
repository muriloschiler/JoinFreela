using Microsoft.Extensions.Hosting;

namespace joinfreela.Infrastructure.Consumers
{
    public class PaymentDoneConsumer : BackgroundService
    {
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            throw new NotImplementedException();
        }
    }
}