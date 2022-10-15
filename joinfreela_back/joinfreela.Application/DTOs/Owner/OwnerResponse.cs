using joinfreela.Application.DTOs.Common;
using joinfreela.Application.DTOs.Project;

namespace joinfreela.Application.DTOs.Owner
{
    public class OwnerResponse:UserViewModel
    {
        public IEnumerable<ProjectResponse> Projects { get; set; }
    }
}