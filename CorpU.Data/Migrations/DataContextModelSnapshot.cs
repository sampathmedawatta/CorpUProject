﻿// <auto-generated />
using System;
using CorpU.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CorpU.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CorpU.Data.Models.ApplicantAvailabilityEntity", b =>
                {
                    b.Property<int>("app_availability_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("app_availability_id"));

                    b.Property<int>("applicant_id")
                        .HasColumnType("int");

                    b.Property<DateTime>("end_date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("start_date")
                        .HasColumnType("datetime2");

                    b.HasKey("app_availability_id");

                    b.HasIndex("applicant_id");

                    b.ToTable("ApplicantAvailability");
                });

            modelBuilder.Entity("CorpU.Data.Models.ApplicantClassPreferanceEntity", b =>
                {
                    b.Property<int>("class_preferance_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("class_preferance_id"));

                    b.Property<int>("applicant_id")
                        .HasColumnType("int");

                    b.Property<int>("class_type_id")
                        .HasColumnType("int");

                    b.HasKey("class_preferance_id");

                    b.HasIndex("applicant_id");

                    b.HasIndex("class_type_id");

                    b.ToTable("ApplicantClassPreferance");
                });

            modelBuilder.Entity("CorpU.Data.Models.ApplicantContactDetailEntity", b =>
                {
                    b.Property<int>("app_contact_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("app_contact_id"));

                    b.Property<string>("address_line1")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("address_line2")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("applicant_id")
                        .HasColumnType("int");

                    b.Property<int>("phone")
                        .HasColumnType("int");

                    b.Property<int>("postcode")
                        .HasColumnType("int");

                    b.Property<string>("state")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("app_contact_id");

                    b.HasIndex("applicant_id");

                    b.ToTable("ApplicantContactDetail");
                });

            modelBuilder.Entity("CorpU.Data.Models.ApplicantEntity", b =>
                {
                    b.Property<int>("applicant_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("applicant_id"));

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("resume_url")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("status")
                        .HasColumnType("bit");

                    b.Property<int>("user_id")
                        .HasColumnType("int");

                    b.HasKey("applicant_id");

                    b.HasIndex("user_id");

                    b.ToTable("Aplicants");
                });

            modelBuilder.Entity("CorpU.Data.Models.ApplicantQualificationEntiry", b =>
                {
                    b.Property<int>("app_qualification_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("app_qualification_id"));

                    b.Property<int>("applicant_id")
                        .HasColumnType("int");

                    b.Property<DateTime>("awarded_date")
                        .HasColumnType("datetime2");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("institute")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("qualification_type_id")
                        .HasColumnType("int");

                    b.HasKey("app_qualification_id");

                    b.HasIndex("applicant_id");

                    b.HasIndex("qualification_type_id");

                    b.ToTable("ApplicantQualification");
                });

            modelBuilder.Entity("CorpU.Data.Models.ApplicationEntity", b =>
                {
                    b.Property<int>("Application_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Application_id"));

                    b.Property<int>("applicant_id")
                        .HasColumnType("int");

                    b.Property<string>("resume_url")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Application_id");

                    b.HasIndex("applicant_id");

                    b.ToTable("Application");
                });

            modelBuilder.Entity("CorpU.Data.Models.ClassTypeEntity", b =>
                {
                    b.Property<int>("class_type_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("class_type_id"));

                    b.Property<string>("class_description")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<bool>("status")
                        .HasColumnType("bit");

                    b.HasKey("class_type_id");

                    b.ToTable("ClassType");

                    b.HasData(
                        new
                        {
                            class_type_id = 1,
                            class_description = "Online",
                            status = true
                        },
                        new
                        {
                            class_type_id = 2,
                            class_description = "Lab",
                            status = true
                        },
                        new
                        {
                            class_type_id = 3,
                            class_description = "Theory",
                            status = true
                        },
                        new
                        {
                            class_type_id = 4,
                            class_description = "Workshop",
                            status = true
                        },
                        new
                        {
                            class_type_id = 5,
                            class_description = "Tute",
                            status = true
                        });
                });

            modelBuilder.Entity("CorpU.Data.Models.EmployeeEntity", b =>
                {
                    b.Property<int>("emp_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("emp_id"));

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("emp_name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("emp_role_id")
                        .HasColumnType("int");

                    b.Property<int>("faculty_id")
                        .HasColumnType("int");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("status")
                        .HasColumnType("bit");

                    b.Property<int>("user_id")
                        .HasColumnType("int");

                    b.HasKey("emp_id");

                    b.HasIndex("emp_role_id");

                    b.HasIndex("faculty_id");

                    b.HasIndex("user_id");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("CorpU.Data.Models.EmployeeRoleEntity", b =>
                {
                    b.Property<int>("emp_role_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("emp_role_id"));

                    b.Property<string>("role_name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<bool>("status")
                        .HasColumnType("bit");

                    b.HasKey("emp_role_id");

                    b.ToTable("EmployeeRole");

                    b.HasData(
                        new
                        {
                            emp_role_id = 1,
                            role_name = "Admin",
                            status = true
                        },
                        new
                        {
                            emp_role_id = 2,
                            role_name = "Manager",
                            status = true
                        },
                        new
                        {
                            emp_role_id = 3,
                            role_name = "Staff",
                            status = true
                        });
                });

            modelBuilder.Entity("CorpU.Data.Models.FacultyEntity", b =>
                {
                    b.Property<int>("faculty_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("faculty_id"));

                    b.Property<string>("faculty_name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<bool>("status")
                        .HasColumnType("bit");

                    b.HasKey("faculty_id");

                    b.ToTable("Faculty");

                    b.HasData(
                        new
                        {
                            faculty_id = 1,
                            faculty_name = "Human Resource",
                            status = true
                        },
                        new
                        {
                            faculty_id = 2,
                            faculty_name = "Information Technology",
                            status = true
                        },
                        new
                        {
                            faculty_id = 3,
                            faculty_name = "Civil Engineering",
                            status = true
                        });
                });

            modelBuilder.Entity("CorpU.Data.Models.QualificationTypeEntity", b =>
                {
                    b.Property<int>("qualification_type_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("qualification_type_id"));

                    b.Property<string>("description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("status")
                        .HasColumnType("bit");

                    b.HasKey("qualification_type_id");

                    b.ToTable("QualificationType");

                    b.HasData(
                        new
                        {
                            qualification_type_id = 1,
                            description = "BSc",
                            status = true
                        },
                        new
                        {
                            qualification_type_id = 2,
                            description = "MSc",
                            status = true
                        },
                        new
                        {
                            qualification_type_id = 3,
                            description = "Phd",
                            status = true
                        });
                });

            modelBuilder.Entity("CorpU.Data.Models.UnitEntity", b =>
                {
                    b.Property<int>("unit_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("unit_id"));

                    b.Property<bool>("status")
                        .HasColumnType("bit");

                    b.Property<string>("unit_code")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("unit_name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("unit_id");

                    b.ToTable("Unit");
                });

            modelBuilder.Entity("CorpU.Data.Models.UserEntity", b =>
                {
                    b.Property<int>("user_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("user_id"));

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("salt")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<int>("user_role_id")
                        .HasColumnType("int");

                    b.HasKey("user_id");

                    b.HasIndex("user_role_id")
                        .IsUnique();

                    b.ToTable("User");
                });

            modelBuilder.Entity("CorpU.Data.Models.UserRoleEntity", b =>
                {
                    b.Property<int>("user_role_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("user_role_id"));

                    b.Property<string>("role_name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<bool>("status")
                        .HasColumnType("bit");

                    b.HasKey("user_role_id");

                    b.ToTable("UserRole");

                    b.HasData(
                        new
                        {
                            user_role_id = 1,
                            role_name = "Applicant",
                            status = true
                        },
                        new
                        {
                            user_role_id = 2,
                            role_name = "Employee",
                            status = true
                        });
                });

            modelBuilder.Entity("CorpU.Data.Models.VacancyEntity", b =>
                {
                    b.Property<int>("vacancy_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("vacancy_id"));

                    b.Property<int>("class_type_id")
                        .HasColumnType("int");

                    b.Property<DateTime>("closing_date")
                        .HasColumnType("datetime2");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("emp_id")
                        .HasColumnType("int");

                    b.Property<DateTime>("publish_date")
                        .HasColumnType("datetime2");

                    b.Property<bool>("status")
                        .HasColumnType("bit");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("unit_id")
                        .HasColumnType("int");

                    b.Property<int>("vacancy_type_id")
                        .HasColumnType("int");

                    b.HasKey("vacancy_id");

                    b.HasIndex("class_type_id");

                    b.HasIndex("emp_id");

                    b.HasIndex("unit_id");

                    b.HasIndex("vacancy_type_id");

                    b.ToTable("Vacancy");
                });

            modelBuilder.Entity("CorpU.Data.Models.VacancyTypeEntity", b =>
                {
                    b.Property<int>("vacancy_type_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("vacancy_type_id"));

                    b.Property<bool>("status")
                        .HasColumnType("bit");

                    b.Property<string>("vacancy_name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("vacancy_type_id");

                    b.ToTable("VacancyType");

                    b.HasData(
                        new
                        {
                            vacancy_type_id = 1,
                            status = true,
                            vacancy_name = "Fultime"
                        },
                        new
                        {
                            vacancy_type_id = 2,
                            status = true,
                            vacancy_name = "Parttime"
                        });
                });

            modelBuilder.Entity("CorpU.Data.Models.ApplicantAvailabilityEntity", b =>
                {
                    b.HasOne("CorpU.Data.Models.ApplicantEntity", "Applicant")
                        .WithMany()
                        .HasForeignKey("applicant_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Applicant");
                });

            modelBuilder.Entity("CorpU.Data.Models.ApplicantClassPreferanceEntity", b =>
                {
                    b.HasOne("CorpU.Data.Models.ApplicantEntity", "Applicant")
                        .WithMany()
                        .HasForeignKey("applicant_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CorpU.Data.Models.ClassTypeEntity", "ClassType")
                        .WithMany()
                        .HasForeignKey("class_type_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Applicant");

                    b.Navigation("ClassType");
                });

            modelBuilder.Entity("CorpU.Data.Models.ApplicantContactDetailEntity", b =>
                {
                    b.HasOne("CorpU.Data.Models.ApplicantEntity", "Applicant")
                        .WithMany()
                        .HasForeignKey("applicant_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Applicant");
                });

            modelBuilder.Entity("CorpU.Data.Models.ApplicantEntity", b =>
                {
                    b.HasOne("CorpU.Data.Models.UserEntity", "User")
                        .WithMany()
                        .HasForeignKey("user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("CorpU.Data.Models.ApplicantQualificationEntiry", b =>
                {
                    b.HasOne("CorpU.Data.Models.ApplicantEntity", "Applicant")
                        .WithMany()
                        .HasForeignKey("applicant_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CorpU.Data.Models.QualificationTypeEntity", "QualificationType")
                        .WithMany()
                        .HasForeignKey("qualification_type_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Applicant");

                    b.Navigation("QualificationType");
                });

            modelBuilder.Entity("CorpU.Data.Models.ApplicationEntity", b =>
                {
                    b.HasOne("CorpU.Data.Models.ApplicantEntity", "Applicant")
                        .WithMany()
                        .HasForeignKey("applicant_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Applicant");
                });

            modelBuilder.Entity("CorpU.Data.Models.EmployeeEntity", b =>
                {
                    b.HasOne("CorpU.Data.Models.EmployeeRoleEntity", "EmployeeRole")
                        .WithMany()
                        .HasForeignKey("emp_role_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CorpU.Data.Models.FacultyEntity", "Faculty")
                        .WithMany()
                        .HasForeignKey("faculty_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CorpU.Data.Models.UserEntity", "User")
                        .WithMany()
                        .HasForeignKey("user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EmployeeRole");

                    b.Navigation("Faculty");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CorpU.Data.Models.UserEntity", b =>
                {
                    b.HasOne("CorpU.Data.Models.UserRoleEntity", "UserRole")
                        .WithOne("User")
                        .HasForeignKey("CorpU.Data.Models.UserEntity", "user_role_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserRole");
                });

            modelBuilder.Entity("CorpU.Data.Models.VacancyEntity", b =>
                {
                    b.HasOne("CorpU.Data.Models.ClassTypeEntity", "ClassType")
                        .WithMany()
                        .HasForeignKey("class_type_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CorpU.Data.Models.EmployeeEntity", "Employee")
                        .WithMany()
                        .HasForeignKey("emp_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CorpU.Data.Models.UnitEntity", "Unit")
                        .WithMany()
                        .HasForeignKey("unit_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CorpU.Data.Models.VacancyTypeEntity", "VacancyType")
                        .WithMany()
                        .HasForeignKey("vacancy_type_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClassType");

                    b.Navigation("Employee");

                    b.Navigation("Unit");

                    b.Navigation("VacancyType");
                });

            modelBuilder.Entity("CorpU.Data.Models.UserRoleEntity", b =>
                {
                    b.Navigation("User")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
