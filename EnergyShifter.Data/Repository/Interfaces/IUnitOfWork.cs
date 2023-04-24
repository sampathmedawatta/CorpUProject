using EnergyShifter.Entitiy.Models.Dto.Aplicant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyShifter.Data.Repository.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IAplicantRepository<AplicantDto> Aplicants { get; }
        int Complete();

    }
}
