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
    public interface IApplicantManager: IBaseManager
    {
        Task<ApplicantDto> GetByIdAsync(int id);

        Task<ApplicantDto> GetByUserIdAsync(int id);
        
        Task<IEnumerable<ApplicantDto>> GetAllAsync();
        Task<IEnumerable<ApplicantDto>> SearchApplicantAsync(string name);
        Task<ApplicantDto> CreateApplicantAsync(ApplicantRegisterDto entity);
        Task<OperationResult> UpdateEmployeeAsync(ApplicantUpdateDto entity);
    }
}
