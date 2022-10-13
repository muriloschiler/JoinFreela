using joinfreela.Domain.Models;
using joinfreela.Infrastructure.Data.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace joinfreela.Infrastructure.Data.Configurations
{
    public class SkillConfiguration : BaseRegisterConfiguration<Skill>
    {
        public override void ConfigureOtherProperties(EntityTypeBuilder<Skill> builder)
        {
            builder.Property(sk=>sk.Name).HasColumnType("Varchar(30)").IsRequired();
        }
    }
}