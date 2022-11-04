using joinfreela.Application.DTOs.Common.Base;
using joinfreela.Application.DTOs.Contract;
using joinfreela.Application.DTOs.Nomination;
using joinfreela.Application.DTOs.Skill;

namespace joinfreela.Application.DTOs.Freelancer
{
    public class FreelancerResponse: UserResponse
    {
        public IEnumerable<UserSkillResponse> Skills  { get; set; }
        public IEnumerable<NominationResponse> Nominations { get; set; }
        public IEnumerable<ContractResponse> Contracts { get; set; }
    }
}