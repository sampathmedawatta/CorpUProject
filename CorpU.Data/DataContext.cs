using CorpU.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace CorpU.Data
{
    public class DataContext :DbContext
    {
        public virtual DbSet<AplicantEntity> Aplicants { get; set; }
        
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

            optionsBuilder.UseSqlServer(_ConnectionString);
        }
    }
}