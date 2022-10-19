using joinfreela.Application.DTOs.Common;

namespace joinfreela.Application.DTOs.Api
{
    public class PaginationResponse<T> 
    where T: RegisterViewModel
    {
        public int Take { get; set; }
        public int Skip { get; set; }
        public int Count { get; set; }
        public IEnumerable<T> Data { get; set; }
    }    
}