using System.Linq.Expressions;
using joinfreela.Domain.Classes.Base;

namespace joinfreela.Domain.Interfaces.Repositories.Base
{
    public interface IBaseRepository<T> 
    where T:Register
    {
        public IQueryable<T> Query();
        public Task<IEnumerable<T>> GetAsync(int skip,int take, Expression<Func<T,bool>> filter = null);
        public Task<T> GetByIdAsync(int id);
        public Task<T> RegisterAsync(T entity);
        public Task<T> UpdateAsync(T entity);
        public Task<T> DeleteAsync(T entity);
    }
}