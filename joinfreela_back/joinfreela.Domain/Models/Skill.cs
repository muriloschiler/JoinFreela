using joinfreela.Domain.Classes.Base;

namespace joinfreela.Domain.Models
{
    public class Skill: Register
    {
        public string Name { get; set; }
        public List<UserSkill> Users { get; set; }
    }
}