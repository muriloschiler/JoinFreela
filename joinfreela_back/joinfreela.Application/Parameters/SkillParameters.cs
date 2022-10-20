using System.Linq.Expressions;
using joinfreela.Application.Parameters.Base;
using joinfreela.Domain.Models;
using LinqKit;
using Microsoft.EntityFrameworkCore;

namespace joinfreela.Application.Parameters
{
    public class SkillParameters: BaseParameters<Skill>
    {
        public string Name { get; set; }
        
        public override Expression<Func<Skill,bool>> Filter()
        {
            ExpressionStarter<Skill> predicate = PredicateBuilder.New<Skill>(true);

            if( !String.IsNullOrEmpty(Name))
                predicate.And(sk => EF.Functions.Like(sk.Name,Name));
            
            return predicate;
        }
    }
}