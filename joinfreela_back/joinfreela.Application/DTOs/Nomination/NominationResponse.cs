using joinfreela.Application.DTOs.Common.Base;
using joinfreela.Application.DTOs.Freelancer;

namespace joinfreela.Application.DTOs.Nomination
{
    public class NominationResponse : RegisterResponse
    {
        public FreelancerResponse Freelancer { get; set; }
    }
}