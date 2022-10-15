using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using joinfreela.Domain.Models;
using joinfreela.Infrastructure.Data;
using joinfreela.Infrastructure.Repositories.Base;

namespace joinfreela.Infrastructure.Repositories
{
    public class ProjectRepository : BaseRepository<Project>
    {
        public ProjectRepository(JoinFreelaDbContext joinFreelaDbContext) : base(joinFreelaDbContext)
        {}
    }
}