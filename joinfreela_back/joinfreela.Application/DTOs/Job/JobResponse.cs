using joinfreela.Application.DTOs.Common.Base;
using joinfreela.Application.DTOs.Contract;
using joinfreela.Application.DTOs.Enumerations;
using joinfreela.Application.DTOs.Nomination;
using joinfreela.Application.DTOs.Project;

namespace joinfreela.Application.DTOs.Job
{
    public class JobResponse : RegisterResponse
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Salary { get; set; }
        public int Open { get; set; }
        public SeniorityViewModel Seniority { get; set; }
        public IEnumerable<NominationResponse> Nominations { get; set; }
        public ContractResponse Contract { get; set; }
        
    }
}