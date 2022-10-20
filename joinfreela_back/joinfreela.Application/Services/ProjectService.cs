using AutoMapper;
using FluentValidation;
using joinfreela.Application.DTOs.Api;
using joinfreela.Application.DTOs.Project;
using joinfreela.Application.Exceptions;
using joinfreela.Application.Interfaces.Services;
using joinfreela.Application.Parameters;
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
        public IValidator<ProjectRequest> _requestvalidator { get; set; }
        public IUnityOfWork _unityOfWork { get; set; }
        public IAuthService _authService { get; set; }
        
        public ProjectService(IProjectRepository projectRepository, IMapper mapper, IValidator<ProjectRequest> requestvalidator, IUnityOfWork unityOfWork,IAuthService authService) 
            :base(projectRepository, mapper, requestvalidator, unityOfWork)
        {
            _projectRepository=projectRepository;
            _mapper =mapper;
            _requestvalidator = requestvalidator;
            _unityOfWork = unityOfWork;
            _authService=authService;
        }

        public async Task<PaginationResponse<ProjectResponse>> GetAsync(ProjectParameters parameters)
        {
            return new PaginationResponse<ProjectResponse>{
                Skip = parameters.Skip,
                Take = parameters.Take,
                Count = await _projectRepository.Count(parameters.Filter()),
                Data = _mapper.Map<IEnumerable<ProjectResponse>>(await _projectRepository.GetAsync(parameters.Skip,parameters.Take, parameters.Filter()))
            };
        }
        public override async Task<ProjectResponse> UpdateAsync(int id, ProjectRequest request)
        {
            var validationResult = await _requestvalidator.ValidateAsync(request);
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
    }
}