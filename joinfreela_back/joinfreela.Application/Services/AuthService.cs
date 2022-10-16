using System.Security.Claims;
using joinfreela.Application.DTOs.Auth;
using joinfreela.Application.Interfaces.Services;
using joinfreela.Domain.Classes.Base;
using joinfreela.Domain.Interfaces.Repositories;
using joinfreela.Domain.Interfaces.Repositories.Base;
using joinfreela.Domain.Models;
using joinfreela.Domain.Models.Enumerations;
using joinfreela.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace joinfreela.Application.Services
{
    public class AuthService : IAuthService
    {
        public IUserRepository<Freelancer> _freelancerRepository { get; set; }
        public IUserRepository<Owner> _ownerRepository { get; set; }
        public IUserRepository<User> _repository { get; set; }
        
        public AuthService(IUserRepository<Freelancer> freelancerRepository, IUserRepository<Owner> ownerRepository)
        {
            _freelancerRepository = freelancerRepository;
            _ownerRepository = ownerRepository;

        }
        public async Task<IEnumerable<Claim>> LoginAsync(LoginRequest loginRequest)
        {    
            if(loginRequest.UserRoleId == UserRole.Freelancer.Id)
                _repository = (IUserRepository<User>)_freelancerRepository;
            else
                _repository= (IUserRepository<User>)_ownerRepository;
            
            User user = _repository.Query()
                .AsNoTracking()
                .Include(us=>us.UserRole)
                .FirstOrDefault(us=>us.Email == loginRequest.Email
                                && us.Password == loginRequest.Password);

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
            throw new NotImplementedException();
        }

    }
}