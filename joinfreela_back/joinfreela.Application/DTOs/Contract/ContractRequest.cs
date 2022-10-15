using joinfreela.Application.DTOs.Common;

namespace joinfreela.Application.DTOs.Contract
{
    public class ContractRequest:RegisterViewModel
    {
        public int JobId { get; set; }

        public int FreelancerId { get; set; }
    }
}