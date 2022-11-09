using joinfreela.Application.DTOs.Common.Base;

namespace joinfreela.Application.DTOs.Project
{
    public class ProjectRequest: RegisterRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}