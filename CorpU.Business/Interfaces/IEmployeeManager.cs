using CorpU.Entitiy.Models;
using CorpU.Entitiy.Models.Dto.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpU.Business.Interfaces
{
    public interface IEmployeeManager : IBaseManager
    {
        Task<OperationResult> GetByIdAsync(int id);
        Task<OperationResult> GetByEmailAsync(string email);
        Task<OperationResult> GetAllAsync();
        Task<OperationResult> CreateEmployeeAsync(EmployeeRegisterDto entity);
        Task<OperationResult> UpdateEmployeeAsync(EmployeeUpdateDto entity);

    }
}
