using System.Linq.Expressions;
using joinfreela.Domain.Classes.Base;
using joinfreela.Domain.Interfaces.Repositories.Base;
using joinfreela.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace joinfreela.Infrastructure.Repositories.Base
{
    public class BaseRepository<T> : IBaseRepository<T>
    where T: Register
    {
        private JoinFreelaDbContext _joinFreelaDbContext {get;set;}
        private DbSet<T> _dbSet { get; set; }
        private IQueryable<T> _query { get; set; }

        public BaseRepository(JoinFreelaDbContext joinFreelaDbContext)
        {
            _joinFreelaDbContext=joinFreelaDbContext;
            _dbSet = _joinFreelaDbContext.Set<T>();
            _query = _dbSet.AsQueryable<T>();
        }
        
        public IQueryable<T> Query()
        {
            return _query;
        }
        public void AddPreQuery(Func<IQueryable<T>,IQueryable<T>> preQuery)
        {
            _query = preQuery.Invoke(_query);
        }
        public async Task<IEnumerable<T>> GetAsync(int skip,int take, Expression<Func<T,bool>> filter = null)
        {
            return await Query().Where(filter).Skip(skip).Take(take).ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await Query().FirstOrDefaultAsync(t=>t.Id == id);
        }

        public Task<T> RegisterAsync(T entity)
        {
            entity.CreatedAt = DateTime.Now;
            _dbSet.Add(entity);
            return Task.FromResult(entity);
        }

        public Task<T> UpdateAsync(T entity)
        {
            entity.UpdatedAt = DateTime.Now;
            _dbSet.Update(entity);
            return Task.FromResult(entity);
        }

        public Task<T> DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            return Task.FromResult(entity);
        }

        public async Task<int> Count(Expression<Func<T,bool>>filter)
        {
            return await Task.FromResult(Query().Where(filter).Count());
        }
    }
}