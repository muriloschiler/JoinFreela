using joinfreela.Domain.Classes.Base;
using joinfreela.Domain.Models;
using joinfreela.Domain.Models.Enumerations;

namespace joinfreela.Domain.Models
{
    public class Job: Register
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Salary { get; set; }
        public int SeniorityId { get; set; }    
        public Seniority Seniority { get; set; }
        public int ProjectId { get; set; }
        public  Project Project { get; set; }
        public Contract Contract { get; set; }       
        public IEnumerable<Nomination> Nominations { get; set; }
    }
}