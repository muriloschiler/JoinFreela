
using Payments.Domain.DTOS;

namespace Payments.Domain.Interfaces.Services
{
    public interface IPaymentService
    {
        public Task<bool> ProcessPayment(PaymentRequest request);
    }
}