using joinfreela.Application.DTOs.Owner;
using joinfreela.Application.Interfaces.Services.Base;
using joinfreela.Domain.Models;

namespace joinfreela.Application.Interfaces.Services
{
    public interface IOwnerService : IBaseService<Owner,OwnerRequest,OwnerResponse>
    {}
}