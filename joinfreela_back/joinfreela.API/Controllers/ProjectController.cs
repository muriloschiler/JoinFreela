using joinfreela.Application.Constants;
using joinfreela.Application.DTOs.Api;
using joinfreela.Application.DTOs.Job;
using joinfreela.Application.DTOs.Project;
using joinfreela.Application.Interfaces.Services;
using joinfreela.Application.Parameters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace joinfreela.API.Controllers
{
    [Route("api/v1/admin/[controller]")]
    [ApiController]
    [Authorize(Roles = UserRoles.Owner)]
    public class ProjectController: ControllerBase
    {
        public IProjectService _projectService { get; set; }
        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public async Task<ActionResult<PaginationResponse<ProjectResponse>>> GetAsync([FromQuery] ProjectParameters parameters)
        {
           var page = await  _projectService.GetAsync(parameters);
           return Ok(page);
        }  

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProjectResponse>> GetById(int id)
        {
            return Ok(await _projectService.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ProjectResponse>> RegisterAsync([FromBody] ProjectRequest projectRequest)
        {
            var projectResponse = await _projectService.RegisterAsync(projectRequest); 
            return Ok(projectResponse);
        }

        [HttpPut("id:int")]
        public async Task<ActionResult<ProjectResponse>> UpdateAsync(int id,[FromBody] ProjectRequest projectRequest)
        {
            var projectResponse = await _projectService.UpdateAsync(id,projectRequest);
            return Ok(projectResponse);
        }

        [HttpDelete("id:int")]
        public async Task<ActionResult<ProjectResponse>> DeleteAsync(int id)
        {
            return Ok(await _projectService.DeleteAsync(id));
        }
    
        [HttpPost("{projectId:int}/job")]
        public async Task<ActionResult<JobResponse>> RegisterJobAsync(int projectId,[FromBody] JobRequest request)
        {
            return Ok(await _projectService.AddJobAsync(projectId,request));
        }

        [HttpPost("{projectId:int}/job/{JobId:int}")]
        public async Task<ActionResult<JobResponse>> UpdateJobAsync(int projectId, int JobId,[FromBody] JobRequest request)
        {
            return Ok(await _projectService.UpdateJobAsync(projectId, JobId,request));
        }
    }
}