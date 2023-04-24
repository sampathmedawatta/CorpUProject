using EnergyShifter.Common;
using EnergyShifter.Data.Repository.Interfaces;
using EnergyShifter.Entitiy.Models.Dto.Aplicant;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyShifter.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly string ConnectionString;
        private DataContext Context
        {
            get
            {
                return new DataContext(ConnectionString);
            }
        }

        public IAplicantRepository<AplicantDto> Aplicants { get; private set; }

        public UnitOfWork(IOptions<AppSettings> appSetting)
        {

            ConnectionString = appSetting.Value.DBConnection;
            Aplicants = new AplicantRepository(Context);
        }

        public int Complete()
        {
            return Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
