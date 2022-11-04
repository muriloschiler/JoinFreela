using joinfreela.Domain.Models;
using joinfreela.Infrastructure.Data.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace joinfreela.Infrastructure.Data.Configurations.ManyToManyConfigurations
{
    public class UserSkillConfiguration: IEntityTypeConfiguration<UserSkill>
    {
        public void Configure(EntityTypeBuilder<UserSkill> builder)
        {
            builder.HasKey(us=> new{ us.FreelancerId,us.SkillId});
            builder.Property(us=>us.Experience).HasColumnType("INTEGER");

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