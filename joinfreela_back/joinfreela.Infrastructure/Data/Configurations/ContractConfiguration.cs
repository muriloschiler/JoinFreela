
using joinfreela.Domain.Models;
using joinfreela.Infrastructure.Data.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace joinfreela.Infrastructure.Data.Configurations
{
    public class ContractConfiguration : BaseRegisterConfiguration<Contract>
    {
        public override void ConfigureOtherProperties(EntityTypeBuilder<Contract> builder)
        {
            builder.Property(co=>co.Active)
                .HasColumnType("Integer")
                .HasDefaultValue(0);
                
            builder
                .HasOne(co=>co.Job)
                .WithOne(jo=>jo.Contract);
            
            builder
                .HasOne(co=>co.Freelancer)
                .WithMany(fr=>fr.Contracts);
            
            builder
                .HasMany(co=>co.Payments)
                .WithOne(pa=>pa.Contract)
                .HasForeignKey(pa=>pa.ContractId)
                .IsRequired();
        }
    }
}