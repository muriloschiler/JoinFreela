using joinfreela.Application.Constants;
using joinfreela.Application.DTOs.Contract;
using joinfreela.Application.Interfaces.Services;
using joinfreela.Domain.Interfaces.Repositories;
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

        [HttpPost]
        public async Task<ActionResult<ContractResponse>> RegisterAsync([FromBody] ContractRequest contractRequest)
        {
            return Ok(await _contractService.RegisterAsync(contractRequest));
        }   
    }
}