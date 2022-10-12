using joinfreela.Domain.Classes;
using joinfreela.Domain.Classes.Base;

namespace joinfreela.Domain.Models
{
    public class Owner: User
    {
        public string Name { get; set; }
        public List<Project> Projects { get; set; }
    }
}