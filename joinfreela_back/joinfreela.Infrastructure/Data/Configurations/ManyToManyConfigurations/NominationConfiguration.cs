using joinfreela.Domain.Models;
using joinfreela.Infrastructure.Data.Configurations.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace joinfreela.Infrastructure.Data.Configurations.ManyToManyConfigurations
{
    public class NominationConfiguration : BaseRegisterConfiguration<Nomination>
    {
        public override void ConfigureOtherProperties(EntityTypeBuilder<Nomination> builder)
        {
            builder.HasKey(no=>no.Id);

            builder
                .HasOne(no=>no.Freelancer)
                .WithMany(fr=>fr.Nominations)
                .HasForeignKey(no=>no.FreelancerId);
            
            builder
                .HasOne(no=>no.Job)
                .WithMany(jo=>jo.Nominations)
                .HasForeignKey(no=>no.JobId);
 
        }
    }
}