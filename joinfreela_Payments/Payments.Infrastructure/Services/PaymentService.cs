
using Payments.Domain.DTOS;
using Payments.Domain.Interfaces.Services;

namespace Payments.Application.Services
{
    public class PaymentService : IPaymentService
    {
        public async Task<bool> ProcessPayment(PaymentRequest request)
        {
            //Fake Payment process
            return await Task.FromResult(true);
        }
    }
}