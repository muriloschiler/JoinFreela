
using joinfreela.Domain.Models;
using joinfreela.Infrastructure.Data.Configurations.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace joinfreela.Infrastructure.Data.Configurations
{
    public class ContractConfiguration : BaseRegisterConfiguration<Contract>
    {
        public override void ConfigureOtherProperties(EntityTypeBuilder<Contract> builder)
        {
            builder
                .HasOne(co=>co.Job)
                .WithOne(jo=>jo.Contract);
            
            builder
                .HasOne(co=>co.Freelancer)
                .WithMany(fr=>fr.Contracts);
        }
    }
}