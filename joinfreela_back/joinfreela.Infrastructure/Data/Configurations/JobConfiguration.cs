using joinfreela.Domain.Models;
using joinfreela.Infrastructure.Data.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace joinfreela.Infrastructure.Data.Configurations
{
    public class JobConfiguration : BaseRegisterConfiguration<Job>
    {
        public override void ConfigureOtherProperties(EntityTypeBuilder<Job> builder)
        {
            builder.Property(jo=>jo.Title).HasColumnType("Varchar(30)").IsRequired();
            builder.Property(jo=>jo.Description).HasColumnType("Varchar(1000)");
            builder.Property(jo=>jo.Salary).HasColumnType("Real");
            
            builder
                .HasOne(jo=>jo.Seniority)
                .WithMany()
                .HasForeignKey(jo=>jo.SeniorityId)
                .IsRequired();
        }
    }
}