using joinfreela.Application.DTOs.Api;
using joinfreela.Application.DTOs.Job;
using joinfreela.Application.DTOs.Project;
using joinfreela.Application.DTOs.Skill;
using joinfreela.Application.Interfaces.Services.Base;
using joinfreela.Application.Parameters;
using joinfreela.Domain.Models;

namespace joinfreela.Application.Interfaces.Services
{
    public interface IProjectService : IBaseService<Project,ProjectRequest,ProjectResponse>
    {
        Task<JobResponse> AddJobAsync(int projectId, JobRequest request);
        Task<JobResponse> UpdateJobAsync(int projectId,int jobId, JobRequest request);
        Task<JobResponse> DeleteJobAsync(int projectId, int jobId);
    }
}