using joinfreela.Domain.Classes.Base;
using joinfreela.Domain.Interfaces.Repositories.Base;
using joinfreela.Infrastructure.Data;

namespace joinfreela.Infrastructure.Repositories.Base
{
    public class UserRepository<T> : BaseRepository<T>, IUserRepository<T>
    where T : User
    {
        public UserRepository(JoinFreelaDbContext joinFreelaDbContext) : base(joinFreelaDbContext)
        {}
    }
}