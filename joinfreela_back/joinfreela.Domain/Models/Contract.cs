using joinfreela.Domain.Classes;
using joinfreela.Domain.Classes.Base;

namespace joinfreela.Domain.Models
{
    public class Contract: Register
    {
        public int JobId { get; set; }
        public Job Job { get; set; }
        public int FreelancerId { get; set; }
        public int Active { get; set; }
        public Freelancer Freelancer { get; set; }
        public IEnumerable<Payment> Payments { get; set; }
        
        
    }
}