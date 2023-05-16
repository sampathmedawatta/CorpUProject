using CorpU.Entitiy.Models;
using CorpU.Entitiy.Models.Dto.Applicant;
using CorpU.Entitiy.Models.Dto.Referance;
using CorpU.Entitiy.Models.Dto.Unit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpU.Business.Interfaces
{
    public interface IVacancyManager : IBaseManager
    {
        Task<VacancyDto> GetByIdAsync(int id);
        Task<IEnumerable<VacancyDto>> GetAllAsync();
    }
}
