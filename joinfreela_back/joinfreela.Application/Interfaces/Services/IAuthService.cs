using System.Security.Claims;
using joinfreela.Application.DTOs.Auth;
using joinfreela.Domain.Models.Auth;

namespace joinfreela.Application.Interfaces.Services
{
    public interface IAuthService
    {
        Task<IEnumerable<Claim>> LoginAsync(LoginRequest loginRequest);
        JWTResponse GenerateJWT(IEnumerable<Claim> claims);
        public AuthUser AuthUser { get; }
    }
}