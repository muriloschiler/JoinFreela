using Payments.Application.DTOS;

namespace Payments.Application.Interfaces.Services
{
    public interface IPaymentService
    {
        public Task<bool> ProcessPayment(PaymentRequest request);
    }
}