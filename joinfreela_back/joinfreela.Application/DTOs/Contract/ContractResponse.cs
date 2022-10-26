using joinfreela.Application.DTOs.Common.Base;
using joinfreela.Application.DTOs.Freelancer;
using joinfreela.Application.DTOs.Job;

namespace joinfreela.Application.DTOs.Contract
{
    public class ContractResponse : RegisterResponse
    {
        public JobResponse Job { get; set; }
        public FreelancerResponse Freelancer { get; set; }
    }
}