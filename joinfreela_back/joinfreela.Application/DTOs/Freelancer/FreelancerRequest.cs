using joinfreela.Application.DTOs.Common;
using joinfreela.Application.DTOs.Contract;
using joinfreela.Application.DTOs.Nomination;
using joinfreela.Application.DTOs.Skill;

namespace joinfreela.Application.DTOs.Freelancer
{
    public class FreelancerRequest:UserViewModel
    {
        public IEnumerable<SkillRequest> Skills  { get; set; }
        public IEnumerable<NominationRequest> Nominations { get; set; }
    }
}