using joinfreela.Domain.Classes.Base;
using joinfreela.Domain.Models;

namespace joinfreela.Domain.Classes
{
    public class Project: Register
    {   
        public string Name { get; set; }
        public string Description { get; set; }
        public int OwnerId { get; set; }
        public Owner Owner { get; set; }
        public List<Job> Jobs { get; set; }
        
        
    }
}   