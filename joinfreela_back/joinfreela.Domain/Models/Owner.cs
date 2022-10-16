using joinfreela.Domain.Classes.Base;
using joinfreela.Domain.Models.Enumerations;

namespace joinfreela.Domain.Models
{
    public class Owner: User
    {
        public IEnumerable<Project> Projects { get; set; }
    }
}