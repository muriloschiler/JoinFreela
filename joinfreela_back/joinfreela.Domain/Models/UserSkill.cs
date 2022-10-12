using joinfreela.Domain.Classes.Base;

namespace joinfreela.Domain.Models
{
    public class UserSkill: Register
    {
        public int FreelancerId { get; set; }
        public Freelancer Freelancer { get; set; }
        public int SkillId { get; set; }
        public Skill Skill { get; set; }
    }
}