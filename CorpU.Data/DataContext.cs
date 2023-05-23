using CorpU.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace CorpU.Data
{
    public class DataContext :DbContext
    {
        public virtual DbSet<ApplicantEntity> Applicants { get; set; }
        public virtual DbSet<ApplicantQualificationEntiry> ApplicantQualification { get; set; }
        public virtual DbSet<ApplicantContactDetailEntity> ApplicantContactDetail { get; set; }
        public virtual DbSet<ApplicantClassPreferanceEntity> ApplicantClassPreferance { get; set; }
        public virtual DbSet<ApplicantAvailabilityEntity> ApplicantAvailability { get; set; }
        public virtual DbSet<ApplicationEntity> Application { get; set; }
        public virtual DbSet<ClassTypeEntity> ClassType { get; set; }
        public virtual DbSet<EmployeeEntity> Employee { get; set; }
        public virtual DbSet<EmployeeRoleEntity> EmployeeRole { get; set; }
        public virtual DbSet<FacultyEntity> Faculty { get; set; }
        public virtual DbSet<QualificationTypeEntity> QualificationType { get; set; }
        public virtual DbSet<UnitEntity> Unit { get; set; }
        public virtual DbSet<UserEntity> User { get; set; }
        public virtual DbSet<UserRoleEntity> UserRole { get; set; }
        public virtual DbSet<VacancyEntity> Vacancy { get; set; }
        public virtual DbSet<VacancyTypeEntity> VacancyType { get; set; }
        public virtual DbSet<ShortlistedApplicantEntity> Shortlist { get;set; }

        public readonly string _ConnectionString;

        public DataContext(string ConnectionString)
        {
            _ConnectionString = ConnectionString;
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Use this only when runnung code first migration scripts
            //"Data Source=LAPTOP-198T1MOJ;Initial Catalog=CorpU_DB_v1;Integrated Security=True;TrustServerCertificate=True; User Id=sa;Password=123456;";

            // select CorpU.Data project as a default project under "package manager console"
            // Startup project should be Corup.API

            // Add migraton : EntityFrameworkCore\Add-Migration InitialMigration
            // Create uppdate database : EntityFrameworkCore\Update-Database
            // https://www.c-sharpcorner.com/UploadFile/26b237/code-first-migrations-in-entity-framework/

            optionsBuilder.UseSqlServer("Data Source=LAPTOP-198T1MOJ;Initial Catalog=CorpU_DB_v3;Integrated Security=True;TrustServerCertificate=True; User Id=sa;Password=123456;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes()
            .SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }


            // Create sample referance data
            // Application admin account
            modelBuilder.Entity<UserEntity>()
           .HasData(
              new UserEntity
              {
                  user_id = 1,
                  email = "lool2cool@gmail.com", //Username
                  password = "749452DBA7478C9D1E559D83320AE8E10B3BE7CF7D63240E881914BAC07A1447802ECA3094A5B072501E6DEC4F2F5A00C02444CE529203FFFE7E49C5B707AD67", // Password 123456@ 
                  salt = "33F42E4F54E25F02CDF0FFF578724D8C66121ABCDDD8AE8E7BCC6E296D4C725740DAEE0F936F2A6111588B7C732931A20CAC9BF757263AC03A5BBE569E4D32C3",
                  user_role_id = 2 // Employee
              }
          );

            modelBuilder.Entity<EmployeeEntity>()
           .HasData(
              new EmployeeEntity
              {
                  emp_id = 1,
                  emp_name = "Denis Medawaththa",
                  email = "lool2cool@gmail.com",
                  phone = "0413456785",
                  emp_role_id = 1,
                  user_id = 1,
                  faculty_id = 1,
                  status = true
              }
          ); 

            modelBuilder.Entity<ClassTypeEntity>()
            .HasData(
               new ClassTypeEntity
               {
                   class_type_id = 1,
                   class_description = "Online",
                   status = true
               },
               new ClassTypeEntity
               {
                   class_type_id = 2,
                   class_description = "Lab",
                   status = true
               },
               new ClassTypeEntity
               {
                   class_type_id = 3,
                   class_description = "Theory",
                   status = true
               },
               new ClassTypeEntity
               {
                   class_type_id = 4,
                   class_description = "Workshop",
                   status = true
               },
               new ClassTypeEntity
               {
                   class_type_id = 5,
                   class_description = "Tute",
                   status = true
               }
           );

            modelBuilder.Entity<UnitEntity>()
            .HasData(
               new UnitEntity
               {
                   unit_id = 1,
                   unit_name = "Technology Inquiry Project",
                   unit_code = "TIP",
                   status = true
               },
               new UnitEntity
               {
                   unit_id = 2,
                   unit_name = "Software Quality and Testing",
                   unit_code = "SQT",
                   status = true
               },
               new UnitEntity
               {
                   unit_id = 3,
                   unit_name = "User Centric Design",
                   unit_code = "UCD",
                   status = true
               }
           );

            modelBuilder.Entity<EmployeeRoleEntity>()
           .HasData(
              new EmployeeRoleEntity
              {
                  emp_role_id = 1,
                  role_name = "Admin",
                  status = true
              },
              new EmployeeRoleEntity
              {
                  emp_role_id = 2,
                  role_name = "Manager",
                  status = true
              },
              new EmployeeRoleEntity
              {
                  emp_role_id = 3,
                  role_name = "Staff",
                  status = true
              }
          );

            modelBuilder.Entity<FacultyEntity>()
            .HasData(
               new FacultyEntity
               {
                   faculty_id = 1,
                   faculty_name = "Human Resource",
                   status = true
               },
               new FacultyEntity
               {
                   faculty_id = 2,
                   faculty_name = "Information Technology",
                   status = true
               },
               new FacultyEntity
               {
                   faculty_id = 3,
                   faculty_name = "Civil Engineering",
                   status = true
               }
           );

            modelBuilder.Entity<QualificationTypeEntity>()
            .HasData(
               new QualificationTypeEntity
               {
                   qualification_type_id = 1,
                   description = "BSc",
                   status = true
               },
               new QualificationTypeEntity
               {
                   qualification_type_id = 2,
                   description = "MSc",
                   status = true
               },
               new QualificationTypeEntity
               {
                   qualification_type_id = 3,
                   description = "Phd",
                   status = true
               }
           );

            modelBuilder.Entity<UserRoleEntity>()
            .HasData(
               new UserRoleEntity
               {
                   user_role_id = 1,
                   role_name = "Applicant",
                   status = true
               },
               new UserRoleEntity
               {
                   user_role_id = 2,
                   role_name = "Employee",
                   status = true
               }
           );

            modelBuilder.Entity<VacancyTypeEntity>()
             .HasData(
                new VacancyTypeEntity
                {
                    vacancy_type_id = 1,
                    vacancy_name = "Fultime",
                    status = true
                },
                new VacancyTypeEntity
                {
                    vacancy_type_id = 2,
                    vacancy_name = "Parttime",
                    status = true
                }
            );

        }
    }
}