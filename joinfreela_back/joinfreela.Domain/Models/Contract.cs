using joinfreela.Domain.Classes;
using joinfreela.Domain.Classes.Base;

namespace joinfreela.Domain.Models
{
    public class Contract: Register
    {
        public int JobId { get; set; }
        public Job Project { get; set; }
        public int FreelancerId { get; set; }
        public Freelancer Freelancer { get; set; }
        public int OwnerId { get; set; }
        public Owner Owner { get; set; }
    }
}