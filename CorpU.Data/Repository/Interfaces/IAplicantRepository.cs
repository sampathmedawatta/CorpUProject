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
        Task<IEnumerable<AplicantDto>> GetAllByNameAsync(string Name);
        Task<IEnumerable<AplicantDto>> GetAllByStatusAsync(int Status);
        Task<IEnumerable<AplicantDto>> GetAllByEmailAsync(string Email);

    }
}
