using CorpU.Entitiy.Models.Dto.Unit;
using CorpU.Entitiy.Models.Dto.Referance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpU.Business.Interfaces
{
    public interface IUnitManager : IBaseManager
    {
        Task<UnitDto> GetByIdAsync(int id);
        Task<IEnumerable<UnitDto>> GetAllAsync();
    }
}
