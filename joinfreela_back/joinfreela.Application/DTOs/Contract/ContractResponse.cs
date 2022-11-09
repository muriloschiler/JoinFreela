using joinfreela.Application.DTOs.Common.Base;
using joinfreela.Application.DTOs.Freelancer;
using joinfreela.Application.DTOs.Job;
using joinfreela.Application.DTOs.Payment;

namespace joinfreela.Application.DTOs.Contract
{
    public class ContractResponse : RegisterResponse
    {
        public FreelancerResponse Freelancer { get; set; }
        public int Active { get; set; }
        public List<PaymentResponse> Payments { get; set; }
    }
}