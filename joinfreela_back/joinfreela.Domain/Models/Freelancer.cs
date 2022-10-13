using joinfreela.Domain.Classes;
using joinfreela.Domain.Classes.Base;

namespace joinfreela.Domain.Models
{
    public class Freelancer: User
    {
        public List<UserSkill> Skills  { get; set; }
        public List<Nomination> Nominations { get; set; }
    }
}