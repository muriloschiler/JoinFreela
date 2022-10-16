using joinfreela.Domain.Interfaces.Repositories;
using joinfreela.Domain.Interfaces.Repositories.Base;
using joinfreela.Domain.Models;
using joinfreela.Infrastructure.Data;
using joinfreela.Infrastructure.Repositories.Base;

namespace joinfreela.Infrastructure.Repositories
{
    public class OwnerRepository : UserRepository<Owner>, IUserRepository<Owner>
    {
        public OwnerRepository(JoinFreelaDbContext joinFreelaDbContext) : base(joinFreelaDbContext)
        {}
    }
}