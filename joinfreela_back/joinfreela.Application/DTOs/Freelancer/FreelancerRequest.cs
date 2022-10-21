using joinfreela.Application.DTOs.Common;
using joinfreela.Application.DTOs.Skill;

namespace joinfreela.Application.DTOs.Freelancer
{
    public class FreelancerRequest:UserViewModel
    {
        public IEnumerable<UserSkillRequest> Skills  { get; set; }
    }
}
