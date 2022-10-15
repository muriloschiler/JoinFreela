using joinfreela.Application.DTOs.Common;
using joinfreela.Application.DTOs.Project;

namespace joinfreela.Application.DTOs.Owner
{
    public class OwnerRequest: UserViewModel
    {
        public IEnumerable<ProjectRequest> Projects { get; set; }
    }
}