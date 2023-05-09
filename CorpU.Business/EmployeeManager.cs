using CorpU.Business.Interfaces;
using CorpU.Common;
using CorpU.Data.Repository.Interfaces;
using CorpU.Entitiy.Models.Dto.Employee;
using CorpU.Entitiy.Models.Dto.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpU.Business
{
    public class EmployeeManager : IEmployeeManager
    {
        private IUnitOfWork _unitOfWork;
        readonly AuthenticationOptions _AuthenticationOptions;
        public EmployeeManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _AuthenticationOptions = new AuthenticationOptions();
        }

        public async Task<EmployeeDto?> CreateEmployeeAsync(EmployeeRegisterDto entity)
        {
            try
            {
                //Create user account

                UserDto userDto = new()
                {
                    email = entity.email,
                    password = _AuthenticationOptions.GeneratePassword(true, true, true, true, 20),
                    user_role_id = 2 // Staff
                };

                var userResult = await _unitOfWork.Users.Insert(userDto);

                if (userResult >= 0)
                {
                    EmployeeDto employeeDtoDto = new EmployeeDto();
                   // employeeDtoDto.emp_name = entity.emp_name;
                    employeeDtoDto.email = entity.email;
                    employeeDtoDto.phone = entity.phone;
                    employeeDtoDto.faculty_id = entity.faculty_id;
                    employeeDtoDto.user_id = userDto.user_id;
                    employeeDtoDto.emp_role_id = entity.emp_role_id;
                    employeeDtoDto.status = false;

                    var employeeReuslt = await _unitOfWork.Employees.Insert(employeeDtoDto);

                    if (employeeReuslt <= 0)
                    {
                        // TODO role back user creation
                        var userDeleteResult = await _unitOfWork.Users.Delete(userDto.user_id);
                        return null;
                    }

                    // TODO save the employee sent an email with username and password to employee . they have to verify it. 

                    return employeeDtoDto;
                }
            }
            catch (Exception ex)
            {
                //TODO log error and haddle the error
            }
            return null;
        }

        public Task<IEnumerable<EmployeeDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<EmployeeDto> GetByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<EmployeeDto> GetByEmailIdAsync(int id)
        {
            throw new NotImplementedException();
        }


    }
}
