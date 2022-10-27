using joinfreela.Domain.Models;
using joinfreela.Infrastructure.Data.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace joinfreela.Infrastructure.Data.Configurations
{
    public class PaymentConfiguration : BaseRegisterConfiguration<Payment>
    {
        public override void ConfigureOtherProperties(EntityTypeBuilder<Payment> builder)
        {
            builder.Property(pa=>pa.Value).HasColumnType("Real");
            builder.Property(pa=>pa.Pending)
                .HasColumnType("Integer")
                .HasDefaultValue(0);
        }
    }
}