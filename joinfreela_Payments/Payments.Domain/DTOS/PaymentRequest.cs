using Payments.Domain.DTOS.Base;

namespace Payments.Domain.DTOS
{
    public class PaymentRequest : RequestViewModel
    {
        public int Id { get; set; }
        public decimal Value { get; set; }
        public int ContractId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}