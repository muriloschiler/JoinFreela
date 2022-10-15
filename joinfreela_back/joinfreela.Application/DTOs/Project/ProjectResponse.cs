using joinfreela.Application.DTOs.Common;
using joinfreela.Application.DTOs.Job;
using joinfreela.Application.DTOs.Owner;

namespace joinfreela.Application.DTOs.Project
{
    public class ProjectResponse:RegisterViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public OwnerResponse Owner { get; set; }
        public IEnumerable<JobResponse> Jobs { get; set; }
    }
}