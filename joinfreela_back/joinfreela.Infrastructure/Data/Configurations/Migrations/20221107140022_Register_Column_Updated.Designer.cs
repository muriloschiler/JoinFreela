﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using joinfreela.Infrastructure.Data;

#nullable disable

namespace joinfreela.Infrastructure.Migrations
{
    [DbContext(typeof(JoinFreelaDbContext))]
    [Migration("20221107140022_Register_Column_Updated")]
    partial class Register_Column_Updated
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.10");

            modelBuilder.Entity("joinfreela.Domain.Models.Contract", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("Integer")
                        .HasDefaultValue(0);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("Date");

                    b.Property<int>("FreelancerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("JobId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("Date");

                    b.HasKey("Id");

                    b.HasIndex("FreelancerId");

                    b.HasIndex("JobId")
                        .IsUnique();

                    b.ToTable("Contract");
                });

            modelBuilder.Entity("joinfreela.Domain.Models.Enumerations.Seniority", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("Varchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Seniorities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Junior"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Full"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Senior"
                        });
                });

            modelBuilder.Entity("joinfreela.Domain.Models.Enumerations.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("Varchar(30)");

                    b.HasKey("Id");

                    b.ToTable("UserRole");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Owner"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Freelancer"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Admin"
                        });
                });

            modelBuilder.Entity("joinfreela.Domain.Models.Freelancer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("Integer")
                        .HasDefaultValue(0);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("Date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("Varchar(30)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("Varchar(30)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("Varchar(30)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("Date");

                    b.Property<int>("UserRoleId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("Varchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("UserRoleId");

                    b.ToTable("Freelancers");
                });

            modelBuilder.Entity("joinfreela.Domain.Models.Job", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("Date");

                    b.Property<string>("Description")
                        .HasColumnType("Varchar(1000)");

                    b.Property<int>("Open")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("Integer")
                        .HasDefaultValue(0);

                    b.Property<int>("ProjectId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Salary")
                        .HasColumnType("Real");

                    b.Property<int>("SeniorityId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("Varchar(30)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("Date");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.HasIndex("SeniorityId");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("joinfreela.Domain.Models.Nomination", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("Date");

                    b.Property<int>("FreelancerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("JobId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("Date");

                    b.HasKey("Id");

                    b.HasIndex("FreelancerId");

                    b.HasIndex("JobId");

                    b.ToTable("Nominations");
                });

            modelBuilder.Entity("joinfreela.Domain.Models.Owner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("Integer")
                        .HasDefaultValue(0);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("Date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("Varchar(30)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("Varchar(30)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("Varchar(30)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("Date");

                    b.Property<int>("UserRoleId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("Varchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("UserRoleId");

                    b.ToTable("Owners");
                });

            modelBuilder.Entity("joinfreela.Domain.Models.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ContractId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("Date");

                    b.Property<int>("Pending")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("Integer")
                        .HasDefaultValue(0);

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("Date");

                    b.Property<decimal>("Value")
                        .HasColumnType("Real");

                    b.HasKey("Id");

                    b.HasIndex("ContractId");

                    b.ToTable("Payment");
                });

            modelBuilder.Entity("joinfreela.Domain.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("Integer")
                        .HasDefaultValue(0);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("Date");

                    b.Property<string>("Description")
                        .HasColumnType("Varchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("Varchar(30)");

                    b.Property<int>("OwnerId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("Date");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("joinfreela.Domain.Models.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("Date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("Varchar(30)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("Date");

                    b.HasKey("Id");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("joinfreela.Domain.Models.UserSkill", b =>
                {
                    b.Property<int>("FreelancerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SkillId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Experience")
                        .HasColumnType("INTEGER");

                    b.HasKey("FreelancerId", "SkillId");

                    b.HasIndex("SkillId");

                    b.ToTable("UserSkills");
                });

            modelBuilder.Entity("joinfreela.Domain.Models.Contract", b =>
                {
                    b.HasOne("joinfreela.Domain.Models.Freelancer", "Freelancer")
                        .WithMany("Contracts")
                        .HasForeignKey("FreelancerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("joinfreela.Domain.Models.Job", "Job")
                        .WithOne("Contract")
                        .HasForeignKey("joinfreela.Domain.Models.Contract", "JobId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Freelancer");

                    b.Navigation("Job");
                });

            modelBuilder.Entity("joinfreela.Domain.Models.Freelancer", b =>
                {
                    b.HasOne("joinfreela.Domain.Models.Enumerations.UserRole", "UserRole")
                        .WithMany()
                        .HasForeignKey("UserRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserRole");
                });

            modelBuilder.Entity("joinfreela.Domain.Models.Job", b =>
                {
                    b.HasOne("joinfreela.Domain.Models.Project", "Project")
                        .WithMany("Jobs")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("joinfreela.Domain.Models.Enumerations.Seniority", "Seniority")
                        .WithMany()
                        .HasForeignKey("SeniorityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");

                    b.Navigation("Seniority");
                });

            modelBuilder.Entity("joinfreela.Domain.Models.Nomination", b =>
                {
                    b.HasOne("joinfreela.Domain.Models.Freelancer", "Freelancer")
                        .WithMany("Nominations")
                        .HasForeignKey("FreelancerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("joinfreela.Domain.Models.Job", "Job")
                        .WithMany("Nominations")
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Freelancer");

                    b.Navigation("Job");
                });

            modelBuilder.Entity("joinfreela.Domain.Models.Owner", b =>
                {
                    b.HasOne("joinfreela.Domain.Models.Enumerations.UserRole", "UserRole")
                        .WithMany()
                        .HasForeignKey("UserRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserRole");
                });

            modelBuilder.Entity("joinfreela.Domain.Models.Payment", b =>
                {
                    b.HasOne("joinfreela.Domain.Models.Contract", "Contract")
                        .WithMany("Payments")
                        .HasForeignKey("ContractId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contract");
                });

            modelBuilder.Entity("joinfreela.Domain.Models.Project", b =>
                {
                    b.HasOne("joinfreela.Domain.Models.Owner", "Owner")
                        .WithMany("Projects")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("joinfreela.Domain.Models.UserSkill", b =>
                {
                    b.HasOne("joinfreela.Domain.Models.Freelancer", "Freelancer")
                        .WithMany("Skills")
                        .HasForeignKey("FreelancerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("joinfreela.Domain.Models.Skill", "Skill")
                        .WithMany("Freelancers")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Freelancer");

                    b.Navigation("Skill");
                });

            modelBuilder.Entity("joinfreela.Domain.Models.Contract", b =>
                {
                    b.Navigation("Payments");
                });

            modelBuilder.Entity("joinfreela.Domain.Models.Freelancer", b =>
                {
                    b.Navigation("Contracts");

                    b.Navigation("Nominations");

                    b.Navigation("Skills");
                });

            modelBuilder.Entity("joinfreela.Domain.Models.Job", b =>
                {
                    b.Navigation("Contract");

                    b.Navigation("Nominations");
                });

            modelBuilder.Entity("joinfreela.Domain.Models.Owner", b =>
                {
                    b.Navigation("Projects");
                });

            modelBuilder.Entity("joinfreela.Domain.Models.Project", b =>
                {
                    b.Navigation("Jobs");
                });

            modelBuilder.Entity("joinfreela.Domain.Models.Skill", b =>
                {
                    b.Navigation("Freelancers");
                });
#pragma warning restore 612, 618
        }
    }
}
