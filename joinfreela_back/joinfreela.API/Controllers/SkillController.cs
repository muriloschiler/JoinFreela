using joinfreela.Application.DTOs.Api;
using joinfreela.Application.DTOs.Skill;
using joinfreela.Application.Parameters;
using Microsoft.AspNetCore.Mvc;

namespace joinfreela.API.Controllers
{
    [ApiController]
    public class SkillController:ControllerBase
    {
        [HttpGet]
        public Task<ActionResult<PaginationResponse<SkillResponse>>> GetAsync([FromQuery] SkillParameters skillParameters)
        {
           throw new NotImplementedException(); 
        }  
    }
}