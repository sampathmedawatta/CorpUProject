using CorpU.Entitiy.Models.Dto.Applicant;
using CorpU.Entitiy.Models.Dto.Referance;
using CorpU.Entitiy.Models.Dto.Employee;
using CorpU.Entitiy.Models.Dto.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpU.Data.Repository.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IApplicantRepository<ApplicantDto> Applicants { get; }
        IEmployeeRepository<EmployeeDto> Employees { get; }

        IApplicantContactRepository<ApplicantContactDetailDto> ApplicantContact { get; }
        IApplicantQualificationRepository<ApplicantQualificationDto> ApplicantQualification { get; }
        IQualificationRepository<QualificationTypeDto> Qualifications { get; }
        IUserRepository<UserDto> Users { get; }
        int Complete();

    }
}
