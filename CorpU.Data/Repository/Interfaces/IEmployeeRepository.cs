using CorpU.Entitiy.Models.Dto.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpU.Data.Repository.Interfaces
{
    public interface IEmployeeRepository<T> : IRepository<T> where T : class
    {
        Task<EmployeeDto> GetByEmailAsync(string Email);
    }
}
