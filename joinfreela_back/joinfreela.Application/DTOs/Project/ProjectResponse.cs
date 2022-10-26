using joinfreela.Application.DTOs.Common.Base;
using joinfreela.Application.DTOs.Job;
using joinfreela.Application.DTOs.Owner;

namespace joinfreela.Application.DTOs.Project
{
    public class ProjectResponse:RegisterResponse
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public OwnerResponse Owner { get; set; }
        public IEnumerable<JobResponse> Jobs { get; set; }
    }
}