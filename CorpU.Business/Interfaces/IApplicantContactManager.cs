using CorpU.Data.Models;
using CorpU.Entitiy.Models;
using CorpU.Entitiy.Models.Dto.Applicant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpU.Business.Interfaces
{
    public interface IApplicantContactManager : IBaseManager
    {
        Task<ApplicantContactDetailDto> GetByIdAsync(int id);
        //Task<ApplicantDto> GetByEmailAsync(string email);
        //Task<IEnumerable<ApplicantDto>> GetAllAsync();
        Task<ApplicantContactDetailDto> CreateApplicantContactAsync(ApplicantContactRegisterDto entity);
        Task<OperationResult> UpdateApplicantContactAsync(ApplicantContactUpdateDto entity);
    }
}
