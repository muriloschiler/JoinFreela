using joinfreela.Application.Constants;
using joinfreela.Application.DTOs.Api;
using joinfreela.Application.DTOs.Contract;
using joinfreela.Application.Interfaces.Services;
using joinfreela.Application.Parameters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace joinfreela.API.Controllers
{
    [Route("api/v1/admin/[controller]")]
    [ApiController]
    [Authorize(Roles = UserRoles.Owner)]
    public class ContractController : ControllerBase
    {
       
        public IContractService _contractService { get; set; }

        public ContractController(IContractService contractService)
        {
            _contractService = contractService;
        }

        [HttpGet]
        public async Task<ActionResult<PaginationResponse<ContractResponse>>> GetAsync([FromQuery] ContractParameters parameters)
        {
           var page = await  _contractService.GetAsync(parameters);
           return Ok(page);
        }  

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ContractResponse>> GetById(int id)
        {
            return Ok(await _contractService.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ContractResponse>> RegisterAsync([FromBody] ContractRequest contractRequest)
        {
            return Ok(await _contractService.RegisterAsync(contractRequest));
        }

        [HttpPut("{id:int}")]   
        public async Task<ActionResult<ContractResponse>> UpdateAsync(int id,[FromBody] ContractRequest contractRequest)
        {
            return Ok(await _contractService.UpdateAsync(id,contractRequest));
        }
    
        [HttpDelete("id:int")]
        public async Task<ActionResult<ContractResponse>> DeleteAsync(int id)
        {
            return Ok(await _contractService.DeleteAsync(id));
        }
    }
}