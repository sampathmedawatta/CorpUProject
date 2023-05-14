using CorpU.Data.Models;
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
        //Task<ApplicantDto> GetByEmailAsync(string email);
        //Task<IEnumerable<ApplicantDto>> GetAllAsync();
        //Task<ApplicantDto> CreateEmployeeAsync(ApplicantDto entity);
        //Task<ApplicantDto> UpdateEmployeeAsync(ApplicantDto entity);
    }
}
