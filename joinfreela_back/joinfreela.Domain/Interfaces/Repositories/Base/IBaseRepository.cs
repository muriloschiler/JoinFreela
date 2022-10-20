using System.Linq.Expressions;
using joinfreela.Domain.Classes.Base;

namespace joinfreela.Domain.Interfaces.Repositories.Base
{
    public interface IBaseRepository<T> 
    where T:Register
    {
        IQueryable<T> Query();
        Task<IEnumerable<T>> GetAsync(int skip,int take, Expression<Func<T,bool>> filter = null);
        Task<T> GetByIdAsync(int id);
        Task<T> RegisterAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(T entity);
        Task<int> Count(Expression<Func<T,bool>>filter);
    }
}