namespace Payments.Application.DTOS
{
    public class PaymentRequest
    {
        public decimal Value { get; set; }
        public int ContractId { get; set; }
    }
}