using joinfreela.Domain.Models.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace joinfreela.Infrastructure.Data.Configurations.Base
{
    public abstract class BaseEnumerationConfiguration<EnumerationEntity> : IEntityTypeConfiguration<EnumerationEntity>
    where EnumerationEntity : Enumeration
    {
        public void Configure(EntityTypeBuilder<EnumerationEntity> builder)
        {
            builder.HasKey(en=>en.Id);
            builder.Property(en=> en.Name).HasColumnType("Varchar(30)").IsRequired();
        }
    }
}