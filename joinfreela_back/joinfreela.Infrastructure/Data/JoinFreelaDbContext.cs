using joinfreela.Domain.Models;
using joinfreela.Domain.Models.Base;
using joinfreela.Domain.Models.Enumerations;
using joinfreela.Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace joinfreela.Infrastructure.Data
{
    public class JoinFreelaDbContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Freelancer> Freelancers { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Seniority> Seniorities { get; set; }
        public DbSet<Nomination> Nominations { get; set; }
        public DbSet<UserSkill> UserSkills { get; set; }
    
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=../joinfreela.Infrastructure/Data/joinfreela.db;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfigurationsFromAssembly(typeof(ProjectConfiguration).Assembly);

            modelBuilder
                .Entity<Seniority>()
                .HasData(Enumeration.GetAll<Seniority>());
            modelBuilder
                .Entity<UserRole>()
                .HasData(Enumeration.GetAll<UserRole>());      
        }
    }
}