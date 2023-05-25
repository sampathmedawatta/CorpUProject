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
        Task<IEnumerable<ApplicationDto>> GetByApplicantIdAsync(int id);

        Task<ApplicationDto> GetByApplicationIdAsync(int id);
        Task<IEnumerable<ApplicationDto>> CreateApplicationAsync(ApplicationRegisterDto entity);
        Task<OperationResult> UpdateApplicationAsync(ApplicationUpdateDto entity);
    }
}
