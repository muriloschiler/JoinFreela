using joinfreela.Domain.Classes.Base;
using joinfreela.Domain.Models;
using joinfreela.Domain.Models.Enumerations;

namespace joinfreela.Domain.Classes
{
    public class Job: Register
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Salary { get; set; }
        public int SeniorityId { get; set; }    
        public Seniority Seniority { get; set; }
        public int ProjectId { get; set; }
        public  Project Project { get; set; }
        public List<Nomination> Nominations { get; set; }
        
    }
}