using joinfreela.Domain.Classes.Base;

namespace joinfreela.Domain.Models
{
    public class Freelancer: User
    {
        public IEnumerable<UserSkill> Skills  { get; set; }
        public IEnumerable<Nomination> Nominations { get; set; }
        public IEnumerable<Contract> Contracts { get; set; }
    }
}