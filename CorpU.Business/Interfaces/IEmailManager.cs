using CorpU.Entitiy.Models;
using CorpU.Entitiy.Models.Dto.Applicant;
using CorpU.Entitiy.Models.Dto.Employee;
using CorpU.Entitiy.Models.Dto.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpU.Business.Interfaces
{
    public interface IEmailManager
    {
        Task<OperationResult> SendAccountSuccessfulEmail_Employee(EmployeeDto employeeDto, UserDto userDto);
        Task<OperationResult> SendAccountSuccessfulEmail_Applicant(ApplicantDto applicantDto, UserDto userDto);
    }
}
