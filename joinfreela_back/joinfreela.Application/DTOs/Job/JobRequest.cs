using joinfreela.Application.DTOs.Common;
using joinfreela.Application.DTOs.Nomination;

namespace joinfreela.Application.DTOs.Job
{
    public class JobRequest:RegisterViewModel
    {
        public string Title { get; set; }
        public int Description { get; set; }
        public decimal Salary { get; set; }
        public int SeniorityId { get; set; }
        public int ProjectId { get; set; }   
    }
}