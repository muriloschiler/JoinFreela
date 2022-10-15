using joinfreela.Application.DTOs.Common;
using joinfreela.Application.DTOs.Job;

namespace joinfreela.Application.DTOs.Project
{
    public class ProjectRequest: RegisterViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<JobRequest> Jobs { get; set; }
    }
}