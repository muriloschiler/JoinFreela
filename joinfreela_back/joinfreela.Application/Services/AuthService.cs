using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using joinfreela.Application.DTOs.Auth;
using joinfreela.Application.Exceptions;
using joinfreela.Application.Interfaces.Services;
using joinfreela.Application.Options;
using joinfreela.Domain.Classes.Base;
using joinfreela.Domain.Interfaces.Repositories;
using joinfreela.Domain.Interfaces.Repositories.Base;
using joinfreela.Domain.Models.Auth;
using joinfreela.Domain.Models.Base;
using joinfreela.Domain.Models.Enumerations;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace joinfreela.Application.Services
{
    public class AuthService : IAuthService
    {
        private IFreelancerRepository _freelancerRepository;
        private IOwnerRepository _ownerRepository; 
        private readonly JWTOptions _jwtOptions; 
        public AuthUser AuthUser { get; set; }
        
        public AuthService
        (   IFreelancerRepository freelancerRepository, 
            IOwnerRepository ownerRepository,
            IOptions<JWTOptions> jwtOptions,
            IHttpContextAccessor httpContextAccessor = null )
        {
            _freelancerRepository = freelancerRepository;
            _ownerRepository = ownerRepository;
            _jwtOptions = jwtOptions.Value;
            if(httpContextAccessor is not null)
                SetLoggedUser(httpContextAccessor.HttpContext.User);
        }

        private void SetLoggedUser(ClaimsPrincipal user)
        {
            if (user.Identity.IsAuthenticated)
            {
                AuthUser = new AuthUser{
                    Id = int.Parse(user.Claims.FirstOrDefault(cl=>cl.Type==ClaimTypes.Sid).Value),
                    Email = user.Claims.FirstOrDefault(cl=>cl.Type==ClaimTypes.Email).ToString(),
                    Name = user.Claims.FirstOrDefault(cl=>cl.Type==ClaimTypes.Name).ToString(),
                    Role = user.Claims.FirstOrDefault(cl=>cl.Type==ClaimTypes.Role).ToString(),
                };
            }
        }

        public async Task<IEnumerable<Claim>> LoginAsync(LoginRequest loginRequest)
        {    
            User user = null;
            if(loginRequest.UserRoleId == UserRole.Freelancer.Id){

                user = _freelancerRepository.Query()
                    .AsNoTracking()
                    .Include(us=>us.UserRole)
                    .FirstOrDefault(us=>us.Email == loginRequest.Email
                                && us.Password == loginRequest.Password);
            }
            else{

                user = _ownerRepository.Query()
                    .AsNoTracking()
                    .Include(us=>us.UserRole)
                    .FirstOrDefault(us=>us.Email == loginRequest.Email
                                && us.Password == loginRequest.Password);
            }

            if(user is null) 
                throw new NotFoundException("Usuário não encontrado"); 
            
            return new List<Claim>{
                new Claim(ClaimTypes.Sid,user.Id.ToString()),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.Name,user.Name),
                new Claim(ClaimTypes.Role,user.UserRole.Name)
            };

            
        }   

        public JWTResponse GenerateJWT(IEnumerable<Claim> claims)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtOptions.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(_jwtOptions.ExpirationMinutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new JWTResponse{
                TokenJWT = tokenHandler.WriteToken(token) 
            };
                

        }

    }
}