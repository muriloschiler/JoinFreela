using joinfreela.Domain.Classes.Base;

namespace joinfreela.Domain.Models
{
    public class Owner: User
    {
        public List<Project> Projects { get; set; }
    }
}