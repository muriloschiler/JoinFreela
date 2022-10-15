using joinfreela.Domain.Classes.Base;

namespace joinfreela.Domain.Models
{
    public class Owner: User
    {
        public IEnumerable<Project> Projects { get; set; }
    }
}