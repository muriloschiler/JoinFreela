using joinfreela.Application.DTOs.Freelancer;
using joinfreela.Application.Interfaces.Services.Base;
using joinfreela.Domain.Models;

namespace joinfreela.Application.Interfaces.Services
{
    public interface IFreelancerService: IBaseService<Freelancer,FreelancerRequest,FreelancerResponse>
    {}
}