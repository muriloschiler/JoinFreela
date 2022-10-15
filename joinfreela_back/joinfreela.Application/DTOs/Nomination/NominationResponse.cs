using joinfreela.Application.DTOs.Common;
using joinfreela.Application.DTOs.Freelancer;
using joinfreela.Application.DTOs.Job;

namespace joinfreela.Application.DTOs.Nomination
{
    public class NominationResponse:RegisterViewModel
    {
        public FreelancerResponse Freelancer { get; set; }
        public JobResponse JobResponse { get; set; }
    }
}