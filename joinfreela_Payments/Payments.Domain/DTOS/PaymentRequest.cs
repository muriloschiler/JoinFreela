namespace Payments.Domain.DTOS
{
    public class PaymentRequest
    {
        public decimal Value { get; set; }
        public int ContractId { get; set; }
    }
}