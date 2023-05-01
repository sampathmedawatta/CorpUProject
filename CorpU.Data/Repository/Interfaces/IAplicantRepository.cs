using CorpU.Entitiy.Models.Dto.Aplicant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpU.Data.Repository.Interfaces
{
    public interface IAplicantRepository<T> : IRepository<T> where T : class
    {
        Task<IEnumerable<ApplicantDto>> GetAllByNameAsync(string Name);
        Task<IEnumerable<ApplicantDto>> GetAllByStatusAsync(bool Status);
        Task<IEnumerable<ApplicantDto>> GetAllByEmailAsync(string Email);

    }
}
