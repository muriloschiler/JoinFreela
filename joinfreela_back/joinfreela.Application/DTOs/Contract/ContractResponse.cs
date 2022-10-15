using joinfreela.Application.DTOs.Common;
using joinfreela.Application.DTOs.Freelancer;
using joinfreela.Application.DTOs.Job;

namespace joinfreela.Application.DTOs.Contract
{
    public class ContractResponse:RegisterViewModel
    {
        public JobResponse Job { get; set; }
        public FreelancerResponse Freelancer { get; set; }
    }
}