using joinfreela.Domain.Classes.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace joinfreela.Infrastructure.Data.Configurations.Base
{
    public abstract class UserConfiguration<UserEntity> : BaseRegisterConfiguration<UserEntity>
    where UserEntity : User
    {
        public override void ConfigureOtherProperties(EntityTypeBuilder<UserEntity> builder)
        {
            builder.Property(us=>us.Name).HasColumnType("Varchar(30)").IsRequired();
            builder.Property(us=>us.Username).HasColumnType("Varchar(30)").IsRequired();
            builder.Property(us=>us.Name).HasColumnType("Varchar(30)").IsRequired();
        }
    }
}