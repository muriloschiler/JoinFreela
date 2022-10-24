using System.Data.Entity;
using AutoMapper;
using FluentValidation;
using joinfreela.Application.DTOs.Job;
using joinfreela.Application.DTOs.Project;
using joinfreela.Application.Exceptions;
using joinfreela.Application.Interfaces.Services;
using joinfreela.Application.Services.Base;
using joinfreela.Domain.Interfaces.Repositories;
using joinfreela.Domain.Interfaces.UnitOfWork;
using joinfreela.Domain.Models;

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

            _projectRepository.AddPreQuery(query => query.Include(pr=>pr.Jobs));
        }

        public override async Task<ProjectResponse> UpdateAsync(int id, ProjectRequest request)
        {
            var validationResult = await _projectRequestvalidator.ValidateAsync(request);
            if(!validationResult.IsValid)
                throw new BadRequestException(validationResult);

            var project = await _projectRepository.GetByIdAsync(id);
            if (project is null)
                throw new NotFoundException($"{nameof(Project)} não existe");
            
            if(project.OwnerId != _authService.AuthUser.Id)
                throw new NotAuthorizedException();
            
            _mapper.Map<ProjectRequest,Project>(request,project);
            await _projectRepository.UpdateAsync(project);
            //Interaction
            await _unityOfWork.CommitChangesAsync();
            return _mapper.Map<ProjectResponse>(project);

        } 
        public override async Task<ProjectResponse> DeleteAsync(int id)
        {
            var project = await _projectRepository.GetByIdAsync(id);
            if (project is null)
                throw new NotFoundException($"{nameof(Project)} não existe");
            
            if(project.OwnerId != _authService.AuthUser.Id)
                throw new NotAuthorizedException();
            
            await _projectRepository.DeleteAsync(project);
            //Interaction
            await _unityOfWork.CommitChangesAsync();
            return _mapper.Map<ProjectResponse>(project);
        }

        public async Task<JobResponse> AddJobAsync(int projectId, JobRequest request)
        {
            var project = await ValidationsForProject(projectId, request);

            var job = _mapper.Map<Job>(request);
            project.Jobs.Add(job);
            //Interaction
            await _unityOfWork.CommitChangesAsync();
            
            return _mapper.Map<JobResponse>(job);
        }

        public async Task<JobResponse> UpdateJobAsync(int projectId, int jobId, JobRequest request)
        {
            var project = await ValidationsForProject(projectId, request);
            
            var job = project.Jobs.FirstOrDefault(jo=>jo.Id == jobId); 
            if( job is null)
                throw new BadRequestException("O projeto informado não contém a vaga informada");
            
            _mapper.Map<JobRequest,Job>(request,job);
            await _projectRepository.UpdateAsync(project);
            //Interaction
            await _unityOfWork.CommitChangesAsync();
            return _mapper.Map<JobResponse>(job);
        }

        private async Task<Project> ValidationsForProject(int projectId, JobRequest request)
        {
            var validationResult = await _jobRequestvalidator.ValidateAsync(request);
            if (!validationResult.IsValid)
                throw new BadRequestException(validationResult);

            var project = await _projectRepository.GetByIdAsync(projectId);

            if (project is null)
                throw new NotFoundException($"{nameof(Project)} não existe");

            if (project.OwnerId != _authService.AuthUser.Id)
                throw new NotAuthorizedException();
        
            return project;
        }
    }


}