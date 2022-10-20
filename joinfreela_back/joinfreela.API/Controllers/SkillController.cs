using joinfreela.Application.Constants;
using joinfreela.Application.DTOs.Api;
using joinfreela.Application.DTOs.Skill;
using joinfreela.Application.Interfaces.Services;
using joinfreela.Application.Parameters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace joinfreela.API.Controllers
{
    [Route("api/v1/admin/[controller]")]
    [ApiController]
    [Authorize(Roles = UserRoles.Admin)]
    public class SkillController:ControllerBase
    {
        public ISkillService _skillService { get; set; }

        public SkillController(ISkillService skillService)
        {
            _skillService = skillService;
        }

        [HttpGet]
        public async Task<ActionResult<PaginationResponse<SkillResponse>>> GetAsync([FromQuery] SkillParameters skillParameters)
        {
           var page = await  _skillService.GetAsync(skillParameters);
           return Ok(page);
        }  

        [HttpPost]
        public async Task<ActionResult<SkillResponse>> RegisterAsync([FromBody] SkillRequest skillRequest)
        {
            var skillResponse = await _skillService.RegisterAsync(skillRequest); 
            return Ok(skillResponse);
        }

        [HttpPut("id:int")]
        public async Task<ActionResult<SkillResponse>> UpdateAsync(int id,[FromBody] SkillRequest skillRequest)
        {
            var skillResponse = await _skillService.UpdateAsync(id,skillRequest);
            return Ok(skillResponse);
        }

        [HttpDelete("id:int")]
        public async Task<ActionResult<SkillResponse>> DeleteAsync(int id)
        {
            return Ok(await _skillService.DeleteAsync(id));
        }
    }
}