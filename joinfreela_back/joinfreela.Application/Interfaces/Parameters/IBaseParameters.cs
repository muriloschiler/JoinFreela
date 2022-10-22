using System.Linq.Expressions;
using joinfreela.Domain.Classes.Base;

namespace joinfreela.Application.Interfaces.Parameters
{
    public interface IBaseParameters<T>
    where T: Register
    {
        public int Take { get; set; }
        public int Skip { get; set; }
         public Expression<Func<T,bool>> Filter();
    }
}