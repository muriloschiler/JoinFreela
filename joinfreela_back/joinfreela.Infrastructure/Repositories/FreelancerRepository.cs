using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using joinfreela.Domain.Interfaces.Repositories;
using joinfreela.Domain.Interfaces.Repositories.Base;
using joinfreela.Domain.Models;
using joinfreela.Infrastructure.Data;
using joinfreela.Infrastructure.Repositories.Base;

namespace joinfreela.Infrastructure.Repositories
{
    public class FreelancerRepository : UserRepository<Freelancer>, IUserRepository<Freelancer>
    {
        public FreelancerRepository(JoinFreelaDbContext joinFreelaDbContext) : base(joinFreelaDbContext)
        {}
    }
}