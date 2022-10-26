using joinfreela.Application.DTOs.Common.Base;
using joinfreela.Application.DTOs.Project;

namespace joinfreela.Application.DTOs.Owner
{
    public class OwnerResponse: UserResponse
    {
        public IEnumerable<ProjectResponse> Projects { get; set; }
    }
}