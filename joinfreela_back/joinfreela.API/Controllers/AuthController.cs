using System.Security.Claims;
using joinfreela.Application.DTOs.Auth;
using joinfreela.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace joinfreela.API.Controllers
{

    [ApiController]
    [Route("api/v1/{action}")]
    public class AuthController : ControllerBase
    {
        public IAuthService _authService { get; set; }
        public AuthController(IAuthService _authService)
        {
            this._authService = _authService;
        }

        [HttpPost]
        public async Task<ActionResult<JWTResponse>> Login([FromBody] LoginRequest loginRequest)
        {
            IEnumerable<Claim> claims = await _authService.LoginAsync(loginRequest);
            JWTResponse jwtResponse = _authService.GenerateJWT(claims);
            return Ok(jwtResponse);
        }
    }
}