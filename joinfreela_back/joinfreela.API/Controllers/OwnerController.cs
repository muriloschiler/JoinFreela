using joinfreela.Application.Constants;
using joinfreela.Application.DTOs.Api;
using joinfreela.Application.DTOs.Owner;
using joinfreela.Application.Interfaces.Services;
using joinfreela.Application.Parameters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace joinfreela.API.Controllers
{
    [ApiController]
    [Route("api/v1/{controller}")]
    [Authorize(Roles = UserRoles.Owner)]
    public class OwnerController : ControllerBase
    {
        public IOwnerService _ownerService { get; set; }

        public OwnerController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        [HttpGet]
        public async Task<ActionResult<PaginationResponse<OwnerResponse>>> GetAsync([FromQuery] OwnerParameters parameters)
        {
            return Ok(await _ownerService.GetAsync(parameters));   
        }
        
        [HttpGet("{id:int}")]
        public async Task<ActionResult<OwnerResponse>> GetById(int id)
        {
            return Ok(await _ownerService.GetById(id));   
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<OwnerResponse>> RegisterAsync(OwnerRequest OwnerRequest)
        {
            return Ok(await _ownerService.RegisterAsync(OwnerRequest));   
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<OwnerResponse>> UpdateAsync(int id,OwnerRequest OwnerRequest)
        {
            return Ok(await _ownerService.UpdateAsync(id,OwnerRequest));   
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<OwnerResponse>> DeleteAsync(int id)
        {
            return Ok(await _ownerService.DeleteAsync(id));   
        }
    }
}