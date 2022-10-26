using AutoMapper;
using FluentValidation;
using joinfreela.Application.DTOs.Owner;
using joinfreela.Application.Interfaces.Services;
using joinfreela.Application.Services.Base;
using joinfreela.Domain.Interfaces.Repositories;
using joinfreela.Domain.Interfaces.Repositories.Base;
using joinfreela.Domain.Interfaces.UnitOfWork;
using joinfreela.Domain.Models;

namespace joinfreela.Application.Services
{
    public class OwnerService : BaseService<Owner, OwnerRequest, OwnerResponse>, IOwnerService
    {
        public OwnerService(IOwnerRepository repository, IMapper mapper, IValidator<OwnerRequest> requestvalidator, IUnityOfWork unityOfWork) : base(repository, mapper, requestvalidator, unityOfWork)
        {}
    }
}