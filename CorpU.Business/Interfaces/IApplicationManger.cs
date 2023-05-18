using CorpU.Data.Models;
using CorpU.Entitiy.Models;
using CorpU.Entitiy.Models.Dto.Applicant;
using CorpU.Entitiy.Models.Dto.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpU.Business.Interfaces
{
    public interface IApplicationManager : IBaseManager
    {
        Task<IEnumerable<ApplicationDto>> GetAllAsync();
        Task<ApplicationDto> GetByApplicantIdAsync(int id);
        Task<ApplicationDto> GetByApplicationIdAsync(int id);
        //Task<ApplicantDto> CreateApplicantAsync(ApplicantRegisterDto entity);
        //Task<OperationResult> UpdateEmployeeAsync(ApplicantUpdateDto entity);
    }
}
