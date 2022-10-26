using joinfreela.Application.DTOs.Common.Base;
using joinfreela.Application.DTOs.Job;

namespace joinfreela.Application.DTOs.Project
{
    public class ProjectRequest: RegisterRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}