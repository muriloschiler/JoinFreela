using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using joinfreela.Application.DTOs.Auth;
using joinfreela.Application.Interfaces.Services;
using joinfreela.Application.Options;
using joinfreela.Domain.Classes.Base;
using joinfreela.Domain.Interfaces.Repositories;
using joinfreela.Domain.Models.Enumerations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace joinfreela.Application.Services
{
    public class AuthService : IAuthService
    {
        public IFreelancerRepository _freelancerRepository { get; set; }
        public IOwnerRepository _ownerRepository { get; set; }
        private readonly JWTOptions _jwtOptions;    
        public AuthService
        (   IFreelancerRepository freelancerRepository, 
            IOwnerRepository ownerRepository,
            IOptions<JWTOptions> jwtOptions )
        {
            _freelancerRepository = freelancerRepository;
            _ownerRepository = ownerRepository;
            _jwtOptions = jwtOptions.Value;

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

            //If user is nul throw NotFound 
            
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