using joinfreela.Domain.Models;
using joinfreela.Infrastructure.Data.Configurations.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace joinfreela.Infrastructure.Data.Configurations.ManyToManyConfigurations
{
    public class UserSkillConfiguration : BaseRegisterConfiguration<UserSkill>
    {
        public override void ConfigureOtherProperties(EntityTypeBuilder<UserSkill> builder)
        {
            builder.HasKey(us=>us.Id);

            builder
                .HasOne(us=>us.Freelancer)
                .WithMany(fr=>fr.Skills)
                .HasForeignKey(us=>us.FreelancerId);

            builder
                .HasOne(us=>us.Skill)
                .WithMany(sk=>sk.Freelancers)
                .HasForeignKey(us=>us.SkillId);
        }
    }
}