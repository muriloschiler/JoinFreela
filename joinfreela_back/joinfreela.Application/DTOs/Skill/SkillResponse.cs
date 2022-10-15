using joinfreela.Application.DTOs.Common;
using joinfreela.Application.DTOs.Freelancer;

namespace joinfreela.Application.DTOs.Skill
{
    public class SkillResponse: RegisterViewModel
    {    
        public string Name { get; set; }
        public IEnumerable<FreelancerResponse> Freelancers { get; set; }
       
    }
}