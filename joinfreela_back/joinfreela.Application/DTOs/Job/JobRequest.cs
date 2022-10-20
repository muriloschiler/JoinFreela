using joinfreela.Application.DTOs.Common;namespace joinfreela.Application.DTOs.Job
{
    public class JobRequest : RegisterViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Salary { get; set; }
        public int SeniorityId { get; set; }
        public int ProjectId { get; set; }   
    }
}