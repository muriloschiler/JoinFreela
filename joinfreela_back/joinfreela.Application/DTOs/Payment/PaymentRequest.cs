using joinfreela.Application.DTOs.Common.Base;

namespace joinfreela.Application.DTOs.Payment
{
    public class PaymentRequest: RegisterRequest
    {
        public decimal Value { get; set; }
        public int? ContractId { get; set; }
    }
}