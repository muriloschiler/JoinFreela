using System.Linq.Expressions;
using joinfreela.Application.Parameters.Base;
using joinfreela.Domain.Models;
using LinqKit;
using Microsoft.EntityFrameworkCore;

namespace joinfreela.Application.Parameters
{
    public class ProjectParameters : BaseParameters<Project>
    {
        public string? Name { get; set; }
        public int? Active { get; set; } = 0 ;  
        public int? OwnerId { get; set; }
        public override Expression<Func<Project, bool>> Filter()
        {
            ExpressionStarter<Project> predicate = PredicateBuilder.New<Project>(true); 
        
            if(Name is not null)
                predicate.And(pr=> EF.Functions.Like(pr.Name,Name));
            
            if (OwnerId is not null)
                predicate.And(pr=>pr.OwnerId == OwnerId);
            
            predicate.And(pr=>pr.Active == Active);
            
            return predicate;
        }
    }
}