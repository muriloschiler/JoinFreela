using joinfreela.Application.DTOs.Common.Base;

namespace joinfreela.Application.DTOs.Api
{
    public class PaginationResponse<T> 
    where T: RegisterResponse
    {
        public int Take { get; set; }
        public int Skip { get; set; }
        public int Count { get; set; }
        public IEnumerable<T> Data { get; set; }
    }    
}