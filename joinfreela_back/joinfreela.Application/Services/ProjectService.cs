
using AutoMapper;
using FluentValidation;
using joinfreela.Application.Constants;
using joinfreela.Application.DTOs.Api;
using joinfreela.Application.DTOs.Job;
using joinfreela.Application.DTOs.Nomination;
using joinfreela.Application.DTOs.Project;
using joinfreela.Application.Exceptions;
using joinfreela.Application.Interfaces.Services;
using joinfreela.Application.Parameters;
using joinfreela.Application.Services.Base;
using joinfreela.Domain.Interfaces.Repositories;
using joinfreela.Domain.Interfaces.UnitOfWork;
using joinfreela.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace joinfreela.Application.Services
{
    public class ProjectService : BaseService<Project, ProjectRequest, ProjectResponse>, IProjectService
    {
        public IProjectRepository _projectRepository { get; set; }
        public IMapper _mapper { get; set; }
        public IValidator<ProjectRequest> _projectRequestvalidator { get; set; }
        public IValidator<JobRequest> _jobRequestvalidator { get; set; }
        public IUnityOfWork _unityOfWork { get; set; }
        public IAuthService _authService { get; set; }
        
        public ProjectService(IProjectRepository projectRepository, IMapper mapper, IValidator<ProjectRequest> projectRequestvalidator,IValidator<JobRequest> jobRequestvalidator, IUnityOfWork unityOfWork,IAuthService authService) 
            :base(projectRepository, mapper, projectRequestvalidator, unityOfWork)
        {
            _projectRepository=projectRepository;
            _mapper =mapper;
            _projectRequestvalidator = projectRequestvalidator;
            _jobRequestvalidator = jobRequestvalidator;
            _unityOfWork = unityOfWork;
            _authService=authService;

            _projectRepository.AddPreQuery(query => query.Include(pr=>pr.Owner));
            _projectRepository.AddPreQuery(query => query.Include(pr=>pr.Jobs).ThenInclude(jo=>jo.Seniority));
            _projectRepository.AddPreQuery(query => query.Include(pr=>pr.Jobs).ThenInclude(jo=>jo.Nominations));
            _projectRepository.AddPreQuery(query => query.Include(pr=>pr.Jobs).ThenInclude(jo=>jo.Contract));
   
        }

        public override async Task<ProjectResponse> UpdateAsync(int id, ProjectRequest request)
        {
            var validationResult = await _projectRequestvalidator.ValidateAsync(request);
            if(!validationResult.IsValid)
                throw new BadRequestException(validationResult);

            var project = await ValidationsForProject(id);
            
            _mapper.Map<ProjectRequest,Project>(request,project);
            await _projectRepository.UpdateAsync(project);
            //Interaction
            await _unityOfWork.CommitChangesAsync();
            return _mapper.Map<ProjectResponse>(project);

        } 
        public override async Task<ProjectResponse> DeleteAsync(int id)
        {
            var project = await ValidationsForProject(id);
            
            await _projectRepository.DeleteAsync(project);
            //Interaction
            await _unityOfWork.CommitChangesAsync();
            return _mapper.Map<ProjectResponse>(project);
        }

        public async Task<PaginationResponse<JobResponse>> GetJobsAsync(JobParameters parameters)
        {
            var data =  _projectRepository.Query().SelectMany(pr=>pr.Jobs).Where(parameters.Filter()).ToList();
            return new PaginationResponse<JobResponse>
            {
                Skip = parameters.Skip,
                Take = parameters.Take,
                Data = _mapper.Map<IEnumerable<JobResponse>>(data.Skip(parameters.Skip).Take(parameters.Take)),
                Count = data.Count()
            };  
        }        
        public async Task<JobResponse> AddJobAsync(int projectId, JobRequest request)
        {
            var validationResult = await _jobRequestvalidator.ValidateAsync(request);
            if (!validationResult.IsValid)
                throw new BadRequestException(validationResult);
            
            var project = await ValidationsForProject(projectId);

            var job = _mapper.Map<Job>(request);
            project.Jobs.Add(job);
            //Interaction
            await _unityOfWork.CommitChangesAsync();
            
            return _mapper.Map<JobResponse>(job);
        }
        
        public async Task<JobResponse> UpdateJobAsync(int projectId, int jobId, JobRequest request)
        {
            var validationResult = await _jobRequestvalidator.ValidateAsync(request);
            if (!validationResult.IsValid)
                throw new BadRequestException(validationResult);
                
            var project = await ValidationsForProject(projectId);
            var job = project.Jobs.FirstOrDefault(jo=>jo.Id == jobId); 
            if( job is null)
                throw new BadRequestException("O projeto informado não contém a vaga informada");
            
            _mapper.Map<JobRequest,Job>(request,job);
            await _projectRepository.UpdateAsync(project);
            //Interaction
            await _unityOfWork.CommitChangesAsync();
            return _mapper.Map<JobResponse>(job);
        }

        public async Task<JobResponse> DeleteJobAsync(int projectId, int jobId)
        {
            var project = await ValidationsForProject(projectId);
            var job = project.Jobs.FirstOrDefault(jo=>jo.Id == jobId); 
            if( job is null)
                throw new BadRequestException("O projeto informado não contém a vaga informada");
            
            project.Jobs.Remove(job);
            await _projectRepository.UpdateAsync(project);
            //interaction
            await _unityOfWork.CommitChangesAsync();
            return _mapper.Map<JobResponse>(job);
        }
        
        public async Task<JobResponse> GetJobById(int projectId, int jobId)
        {
            var project = await ValidationsForProject(projectId);
            var job = project.Jobs.FirstOrDefault(jo=>jo.Id == jobId);
            if ( job is null)
                throw new NotFoundException($"A Vaga informada não existe");
            
            return _mapper.Map<JobResponse>(job);
        }

        public async Task RegisterNominationAsync(int projectId,int jobId)
        {
            var project = await _projectRepository.GetByIdAsync(projectId);
            if (project is null)
                throw new NotFoundException($"O Projeto informado não existe");
            if (project.Active != 0)
                throw new BadRequestException("Projeto não se encontra mais ativo");
            
            var job = project.Jobs.FirstOrDefault(jo=>jo.Id==jobId);   
            if(job is null)
                throw new NotFoundException("O projeto não contém a vaga informada");
            if(job.Open != 0)
                throw new BadRequestException("A vaga informada não se encontra aberta");

            job.Nominations.Add(new Nomination{
                FreelancerId = _authService.AuthUser.Id,
                JobId = jobId
            });
        
            //interaction
            await _projectRepository.UpdateAsync(project);
            await _unityOfWork.CommitChangesAsync();
        }
        private async Task<Project> ValidationsForProject(int projectId)
        {
            var project = await _projectRepository.GetByIdAsync(projectId);

            if (project is null)
                throw new NotFoundException($"O Projeto informado não existe");

            if (project.OwnerId != _authService.AuthUser.Id)
                throw new NotAuthorizedException();

            if (project.Active != 0)
                throw new BadRequestException("Projeto não se encontra mais ativo");

            return project;
        }
    }
}