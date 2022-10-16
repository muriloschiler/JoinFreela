using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using joinfreela.Domain.Interfaces.Repositories;
using joinfreela.Domain.Models;
using joinfreela.Infrastructure.Data;
using joinfreela.Infrastructure.Repositories.Base;

namespace joinfreela.Infrastructure.Repositories
{
    public class ContractRepository : BaseRepository<Contract>,IContractRepository
    {
        public ContractRepository(JoinFreelaDbContext joinFreelaDbContext) : base(joinFreelaDbContext)
        {}
    }
}