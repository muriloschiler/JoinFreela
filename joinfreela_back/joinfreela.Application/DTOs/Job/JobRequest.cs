using joinfreela.Application.DTOs.Common.Base;namespace joinfreela.Application.DTOs.Job
{
    public class JobRequest : RegisterRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Salary { get; set; }
        public int SeniorityId { get; set; }
    }
}