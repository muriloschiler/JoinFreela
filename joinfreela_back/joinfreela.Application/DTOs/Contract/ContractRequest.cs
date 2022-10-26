using joinfreela.Application.DTOs.Common.Base;

namespace joinfreela.Application.DTOs.Contract
{
    public class ContractRequest : RegisterRequest
    {
        public int JobId { get; set; }
        public int FreelancerId { get; set; }
    }
}