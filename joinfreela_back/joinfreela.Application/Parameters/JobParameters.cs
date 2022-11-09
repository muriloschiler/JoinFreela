using System.Linq.Expressions;
using joinfreela.Application.Constants;
using joinfreela.Application.Parameters.Base;
using joinfreela.Domain.Interfaces.Repositories;
using joinfreela.Domain.Models;
using LinqKit;
using Microsoft.EntityFrameworkCore;

namespace joinfreela.Application.Parameters
{
    public class JobParameters : BaseParameters<Job>
    {

        public string? Title { get; set; }
        public int? Open { get; set; } = 0 ;

        // public decimal? MaxSalary { get; set; }
        // public decimal? MinSalary { get; set; }
        // public int? SeniorityId { get; set; }
        // public int? ProjectId { get; set; }

        public string? Order { get; set; } = "Salary" ;
        public string? Direction { get; set; } = DirectionQueryParameters.Ascending;
        
        public override Expression<Func<Job, bool>> Filter()
        {
            ExpressionStarter<Job> predicate = PredicateBuilder.New<Job>();
            
            if(!String.IsNullOrEmpty(Title))
                predicate.And(jo => EF.Functions.Like(jo.Title,Title));

            if(! (Open is null))
                predicate.And(jo=> jo.Open == Open);
            
            return predicate;
        }
    }
}