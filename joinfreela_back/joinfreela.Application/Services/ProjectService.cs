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
g
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
            _projectRepository.AddPreQuery(query => query.Include(pr=>pr.Jobs));
            _jobRequestvalidator = jobRequestvalidator;
            _unityOfWork = unityOfWork;
            _authService=authService;
        }

        public override async Task<ProjectResponse> UpdateAsync(int id, ProjectRequest request)
        {
            var validationResult = await _projectRequestvalidator.ValidateAsync(request);
            if(!validationResult.IsValid)
                throw new BadRequestException(validationResult);

            if (id != request.Id)
                throw new BadRequestException("Os id's presentes na rota e na request são diferentes");

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

        public async Task AddJobAsync(int projectId, JobRequest request)
        {
            var validationResult = await _jobRequestvalidator.ValidateAsync(request);
            if(!validationResult.IsValid)
                throw new BadRequestException(validationResult);
            
            if (projectId != request.ProjectId)
                throw new BadRequestException("Os id's presentes na rota e na request são diferentes");

            var project = await _projectRepository.GetByIdAsync(projectId);

            if (project is null)
                throw new NotFoundException($"{nameof(Project)} não existe");
            
            if(project.OwnerId != _authService.AuthUser.Id)
                throw new NotAuthorizedException();
            
            project.Jobs.Add(_mapper.Map<Job>(request));
            //Interaction
            await _unityOfWork.CommitChangesAsync();
            
            return;
        }
    }
}