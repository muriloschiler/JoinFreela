using joinfreela.Application.DTOs.Api;
using joinfreela.Application.DTOs.Common;
using joinfreela.Application.Interfaces.Parameters;
using joinfreela.Application.Parameters.Base;
using joinfreela.Domain.Classes.Base;

namespace joinfreela.Application.Interfaces.Services.Base
{
    public interface IBaseService<Tmodel,Trequest,Tresponse>
    where Tmodel: Register
    where Trequest: RegisterViewModel
    where Tresponse: RegisterViewModel
    {
        public Task<PaginationResponse<Tresponse>> GetAsync(IBaseParameters<Tmodel> parameters);
        public Task<Tresponse> GetById(int id);
        public Task<Tresponse> RegisterAsync(Trequest request);
        public Task<Tresponse> UpdateAsync(int id,Trequest request);
        public Task<Tresponse> DeleteAsync(int id);
    }

}