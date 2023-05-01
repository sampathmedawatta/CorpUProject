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
            optionsBuilder.UseSqlServer(_ConnectionString);
        }
    }
}