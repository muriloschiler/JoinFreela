using joinfreela.Domain.Models;
using joinfreela.Infrastructure.Data.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace joinfreela.Infrastructure.Data.Configurations
{
    public class ProjectConfiguration : BaseRegisterConfiguration<Project>
    {
        public override void ConfigureOtherProperties(EntityTypeBuilder<Project> builder)
        {
            builder.Property(po=>po.Name).HasColumnType("Varchar(30)").IsRequired();
            builder.Property(po=>po.Description).HasColumnType("Varchar(500)");
            builder.Property(po=>po.Active)
                .HasColumnType("Integer")
                .HasDefaultValue(0);

            builder
                .HasMany(po=>po.Jobs)
                .WithOne(jo=>jo.Project)
                .HasForeignKey(jo=>jo.ProjectId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
