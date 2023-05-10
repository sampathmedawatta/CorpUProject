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
        Task<EmployeeDto> GetByIdAsync(int id);
        Task<EmployeeDto> GetByEmailAsync(string email);
        Task<IEnumerable<EmployeeDto>> GetAllAsync();
        Task<EmployeeDto> CreateEmployeeAsync(EmployeeRegisterDto entity);


    }
}
