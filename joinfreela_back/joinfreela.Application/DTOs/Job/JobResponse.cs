using joinfreela.Application.DTOs.Common;
using joinfreela.Application.DTOs.Contract;
using joinfreela.Application.DTOs.Enumerations;
using joinfreela.Application.DTOs.Nomination;
using joinfreela.Application.DTOs.Project;

namespace joinfreela.Application.DTOs.Job
{
    public class JobResponse:RegisterViewModel
    {
        public string Title { get; set; }
        public int Description { get; set; }
        public decimal Salary { get; set; }
        public SeniorityViewModel Seniority { get; set; }
        public ProjectResponse Project { get; set; }
        public ContractResponse Contract { get; set; }
        public IEnumerable<NominationResponse> Nominations { get; set; }
        
    }
}