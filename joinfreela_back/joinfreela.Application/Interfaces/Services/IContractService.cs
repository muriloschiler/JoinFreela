using joinfreela.Application.DTOs.Contract;
using joinfreela.Application.Interfaces.Services.Base;
using joinfreela.Domain.Models;

namespace joinfreela.Application.Interfaces.Services
{
    public interface IContractService : IBaseService<Contract, ContractRequest, ContractResponse>
    {}
}