using System.Linq.Expressions;
using joinfreela.Application.Interfaces.Parameters;
using joinfreela.Domain.Classes.Base;
using LinqKit;
using Microsoft.EntityFrameworkCore;

namespace joinfreela.Application.Parameters.Base
{
    public class UserParameters<T> : BaseParameters<T>
    where T : User
    {
        public string? Name { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public int? Active { get; set; }
        public int? UserRoleId { get; set; }
        public override Expression<Func<T, bool>> Filter()
        {
            ExpressionStarter<T> predicate = PredicateBuilder.New<T>(true);
            
            if(Name is not null)
                predicate.And(us=> EF.Functions.Like(us.Name,Name));
            if(Username is not null)
                predicate.And(us=> EF.Functions.Like(us.Username,Username));
            if(Email is not null)
                predicate.And(us=> EF.Functions.Like(us.Email,Email));
            if(Active is not null)
                predicate.And(us=> us.Active == Active);
            if(UserRoleId is not null)
                predicate.And(us=> us.UserRoleId == UserRoleId);    
        
            return predicate;
        }
    }
}