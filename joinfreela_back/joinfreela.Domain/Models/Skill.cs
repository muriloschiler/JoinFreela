using joinfreela.Domain.Classes.Base;

namespace joinfreela.Domain.Models
{
    public class Skill: Register
    {
        public string Name { get; set; }
        public IEnumerable<UserSkill> Freelancers { get; set; }
    }
}