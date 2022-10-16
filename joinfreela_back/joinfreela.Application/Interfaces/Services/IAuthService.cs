using System.Security.Claims;
using joinfreela.Application.DTOs.Auth;

namespace joinfreela.Application.Interfaces.Services
{
    public interface IAuthService
    {
        Task<IEnumerable<Claim>> LoginAsync(LoginRequest loginRequest);
        JWTResponse GenerateJWT(IEnumerable<Claim> claims);
    }
}