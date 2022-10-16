using joinfreela.Domain.Classes.Base;
using joinfreela.Domain.Models.Enumerations;

namespace joinfreela.Domain.Models
{
    public class Freelancer: User
    {
        public IEnumerable<UserSkill> Skills  { get; set; }
        public IEnumerable<Nomination> Nominations { get; set; }
        public IEnumerable<Contract> Contracts { get; set; }
        public int UserRoleId { get; set; }
        public UserRole UserRole { get; set; }
    }
}