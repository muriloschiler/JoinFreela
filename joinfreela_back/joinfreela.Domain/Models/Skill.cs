using joinfreela.Domain.Classes.Base;

namespace joinfreela.Domain.Models
{
    public class Skill: Register
    {
        public string Title { get; set; }
        public List<UserSkill> Users { get; set; }
    }
}