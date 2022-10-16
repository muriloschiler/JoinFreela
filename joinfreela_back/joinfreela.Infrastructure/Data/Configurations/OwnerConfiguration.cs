using joinfreela.Domain.Classes;
using joinfreela.Domain.Models;
using joinfreela.Infrastructure.Data.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace joinfreela.Infrastructure.Data.Configurations
{
    public class OwnerConfiguration : UserConfiguration<Owner>
    {
        public override void ConfigureOtherProperties(EntityTypeBuilder<Owner> builder)
        {
            base.ConfigureOtherProperties(builder);
            
            builder
                .HasMany(ow=>ow.Projects)
                .WithOne(po=> po.Owner)
                .HasForeignKey(po=>po.OwnerId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(ow=>ow.UserRole)
                .WithMany()
                .HasForeignKey(ow=>ow.UserRoleId)
                .IsRequired();
        }
    }
}