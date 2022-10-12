using joinfreela.Domain.Classes;
using joinfreela.Domain.Classes.Base;

namespace joinfreela.Domain.Models
{
    public class Nomination: Register
    {
        public int FreelancerId { get; set; }
        public Freelancer Freelancer { get; set; }
        public int JobId { get; set; }
        public Job Job { get; set; }
    }
}