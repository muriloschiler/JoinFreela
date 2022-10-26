using Payments.Application.DTOS;
using Payments.Application.Interfaces.Services;

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