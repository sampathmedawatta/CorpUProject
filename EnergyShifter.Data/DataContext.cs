using EnergyShifter.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace EnergyShifter.Data
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
    }
}