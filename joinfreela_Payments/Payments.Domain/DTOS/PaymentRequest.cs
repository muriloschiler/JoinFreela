using Payments.Domain.DTOS.Base;

namespace Payments.Domain.DTOS
{
    public class PaymentRequest : RequestViewModel
    {
        public decimal Value { get; set; }
        public int ContractId { get; set; }
    }
}