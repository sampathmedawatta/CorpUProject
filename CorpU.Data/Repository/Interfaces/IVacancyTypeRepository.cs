using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpU.Data.Repository.Interfaces
{
    public interface IVacancyTypeRepository<T> : IRepository<T> where T : class
    {
    }
}
