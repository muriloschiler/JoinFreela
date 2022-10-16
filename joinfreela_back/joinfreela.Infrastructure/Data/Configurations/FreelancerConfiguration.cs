using joinfreela.Domain.Models;
using joinfreela.Infrastructure.Data.Configurations.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace joinfreela.Infrastructure.Data.Configurations
{
    public class FreelancerConfiguration: UserConfiguration<Freelancer>
    {
        public override void ConfigureOtherProperties(EntityTypeBuilder<Freelancer> builder)
        {
            base.ConfigureOtherProperties(builder);

            builder
                .HasMany(fr=>fr.Contracts)
                .WithOne(co=>co.Freelancer)
                .HasForeignKey(co=>co.FreelancerId)
                .IsRequired();
            
            builder
                .HasOne(fr=>fr.UserRole)
                .WithMany()
                .HasForeignKey(fr=>fr.UserRoleId)
                .IsRequired();
        }
    }
}