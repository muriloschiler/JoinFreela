using joinfreela.Application.DTOs.Common;

namespace joinfreela.Application.DTOs.Payment
{
    public class PaymentRequest: RegisterViewModel
    {
        public decimal Value { get; set; }
        public int ContractId { get; set; }
        
    }
}