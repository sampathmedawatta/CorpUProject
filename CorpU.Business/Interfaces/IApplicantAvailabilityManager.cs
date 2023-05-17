using CorpU.Entitiy.Models.Dto.Applicant;
using CorpU.Entitiy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpU.Business.Interfaces
{
    public interface IApplicantAvailabilityManager : IBaseManager
    {
        Task<ApplicantAvailabilityDto> GetByIdAsync(int id);
        Task<IEnumerable<ApplicantAvailabilityDto>> GetAllAsync();
        Task<ApplicantAvailabilityDto> CreateApplicantAvailabilityAsync(ApplicantAvailabilityRegisterDto entity);
        Task<OperationResult> UpdateApplicantAvailabilityAsync(ApplicantAvailabilityUpdateDto entity);
    }
}
