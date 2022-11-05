using joinfreela.Application.Constants;
using joinfreela.Application.DTOs.Api;
using joinfreela.Application.DTOs.Freelancer;
using joinfreela.Application.Interfaces.Services;
using joinfreela.Application.Parameters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace joinfreela.API.Controllers
{
    [ApiController]
    [Route("api/v1/{controller}")]
    [Authorize(Roles = UserRoles.Freelancer)]
    public class FreelancerController : ControllerBase
    {
        public IFreelancerService _freelancerService { get; set; }

        public FreelancerController(IFreelancerService freelancerService)
        {
            _freelancerService = freelancerService;
        }

        [HttpGet]
        public async Task<ActionResult<PaginationResponse<FreelancerResponse>>> GetAsync([FromQuery] FreelancerParameters parameters)
        {
            return Ok(await _freelancerService.GetAsync(parameters));   
        }
        
        [HttpGet("{id:int}")]
        public async Task<ActionResult<FreelancerResponse>> GetById(int id)
        {
            return Ok(await _freelancerService.GetById(id));   
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<FreelancerResponse>> RegisterAsync(FreelancerRequest freelancerRequest)
        {
            return Ok(await _freelancerService.RegisterAsync(freelancerRequest));
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<FreelancerResponse>> UpdateAsync(int id,FreelancerRequest freelancerRequest)
        {
            return Ok(await _freelancerService.UpdateAsync(id,freelancerRequest));   
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<FreelancerResponse>> DeleteAsync(int id)
        {
            return Ok(await _freelancerService.DeleteAsync(id));   
        }
    }
}