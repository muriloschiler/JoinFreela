using joinfreela.Domain.Interfaces.UnitOfWork;
using joinfreela.Infrastructure.Data;

namespace joinfreela.Infrastructure.UnitOfWork
{
    public class UnitOfWork: IUnityOfWork
    {
        public JoinFreelaDbContext _joinFreelaDbContext { get; set; }

        public UnitOfWork(JoinFreelaDbContext joinFreelaDbContext)
        {
            _joinFreelaDbContext = joinFreelaDbContext;
        }

        public async Task CommitChangesAsync()
        {
            await _joinFreelaDbContext.SaveChangesAsync();
        }
    }
}