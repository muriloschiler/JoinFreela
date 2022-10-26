using joinfreela.Application.DTOs.Common.Base;
using joinfreela.Application.DTOs.Contract;

namespace joinfreela.Application.DTOs.Payment
{
    public class PaymentResponse : RegisterResponse
    {
        public decimal Value { get; set; }
        public ContractResponse Contract { get; set; }
    }
}