using CorpU.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace CorpU.Data
{
    public class DataContext :DbContext
    {
        public virtual DbSet<ApplicantEntity> Aplicants { get; set; }
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
        public virtual DbSet<UserRoleEntiry> UserRole { get; set; }
        public virtual DbSet<VacancyEntity> Vacancy { get; set; }
        public virtual DbSet<VacancyTypeEntity> VacancyType { get; set; }

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

            // Add migraton : add-migration InitialMigration
            // Create uppdate database : Update - Database
            // https://www.c-sharpcorner.com/UploadFile/26b237/code-first-migrations-in-entity-framework/

            optionsBuilder.UseSqlServer("Data Source=LAPTOP-198T1MOJ;Initial Catalog=CorpU_DB_v2;Integrated Security=True;TrustServerCertificate=True; User Id=sa;Password=123456;");
        }
    }
}