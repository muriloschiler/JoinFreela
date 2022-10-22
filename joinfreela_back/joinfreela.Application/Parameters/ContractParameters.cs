using System.Linq.Expressions;
using joinfreela.Application.Parameters.Base;
using joinfreela.Domain.Models;
using LinqKit;

namespace joinfreela.Application.Parameters
{
    public class ContractParameters : BaseParameters<Contract>
    {
        public int? JobId { get; set; }
        public int? FreelancerId { get; set; }   
    
        public override Expression<Func<Contract,bool>> Filter()
        {
            ExpressionStarter<Contract> predicate = PredicateBuilder.New<Contract>(true);
            
            if(JobId is not null)
                predicate.And(co=>co.JobId == JobId);
            
            if(FreelancerId is not null)
                predicate.And(co=>co.FreelancerId == FreelancerId);
        
            return predicate;
        }
    }
}