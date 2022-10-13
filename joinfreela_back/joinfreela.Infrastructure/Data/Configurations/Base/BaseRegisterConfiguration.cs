using joinfreela.Domain.Classes.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace joinfreela.Infrastructure.Data.Configurations.Base
{
    public abstract class BaseRegisterConfiguration<RegisterEntity> : IEntityTypeConfiguration<RegisterEntity>
    where RegisterEntity : Register
    {
        public void Configure(EntityTypeBuilder<RegisterEntity> builder)
        {
            builder.HasKey(re=>re.Id);
            builder.Property(re=>re.CreatedAt).HasColumnType("Date");
            builder.Property(re=>re.UpdateAt).HasColumnType("Date");
            ConfigureOtherProperties(builder);
        }

        public abstract void ConfigureOtherProperties(EntityTypeBuilder<RegisterEntity> builder);
    }
}