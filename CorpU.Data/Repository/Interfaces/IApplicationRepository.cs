using CorpU.Entitiy.Models.Dto.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpU.Data.Repository.Interfaces
{
    public interface IApplicationRepository<T> : IRepository<T> where T : class
    {
        Task<T> GetByApplicantIdAsync(int id);
        Task<T> GetByApplicationIdAsync(int id);
    }
}
