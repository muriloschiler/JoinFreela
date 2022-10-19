using System.Linq.Expressions;
using joinfreela.Domain.Classes.Base;

namespace joinfreela.Application.Parameters.Base
{
    public abstract class BaseParameters<T>
    where T: Register
    {
        public int Take { get; set; } = 5;
        public int Skip { get; set; } = 0;
        public abstract Expression<Func<T,bool>> Filter();
    }
}