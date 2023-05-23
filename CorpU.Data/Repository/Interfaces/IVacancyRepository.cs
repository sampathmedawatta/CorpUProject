using CorpU.Entitiy.Models.Dto.Applicant;
using CorpU.Entitiy.Models.Dto.Unit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpU.Data.Repository.Interfaces
{
    public interface IVacancyRepository<T> : IRepository<T> where T : class
    {
        Task<IEnumerable<VacancyDto>> SearchVacancyAsync(string text);
    }
}
