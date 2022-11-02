using joinfreela.Application.DTOs.Common.Base;
using joinfreela.Application.DTOs.Skill;

namespace joinfreela.Application.DTOs.Freelancer
{
    public class FreelancerRequest : UserRequest
    {
        public IEnumerable<int> Skills  { get; set; }
    }
}
