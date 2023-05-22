using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpU.Data.Repository.Interfaces
{
    public interface IApplicantQualificationRepository<T> : IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllByIdAsync(int id);
        //Task<IEnumerable<ApplicantDto>> GetAllByNameAsync(string Name);
        //Task<IEnumerable<ApplicantDto>> GetAllByStatusAsync(bool Status);
        //Task<IEnumerable<ApplicantDto>> GetAllByEmailAsync(string Email);

    }
}
