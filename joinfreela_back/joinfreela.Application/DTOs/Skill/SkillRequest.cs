using joinfreela.Application.DTOs.Common;
using joinfreela.Application.DTOs.Freelancer;

namespace joinfreela.Application.DTOs.Skill
{
    public class SkillRequest:RegisterViewModel
    {
        public string Name { get; set; }
        public IEnumerable<FreelancerRequest> Freelancers { get; set; }
    }
}