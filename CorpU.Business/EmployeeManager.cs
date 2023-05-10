using CorpU.Business.Interfaces;
using CorpU.Common;
using CorpU.Data.Repository.Interfaces;
using CorpU.Entitiy.Models.Dto.Employee;
using CorpU.Entitiy.Models.Dto.User;
using Microsoft.Extensions.Options;
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
        private readonly IEmailManager _emailManager;
        readonly AuthenticationOptions _AuthenticationOptions;
        public EmployeeManager(IUnitOfWork unitOfWork, IEmailManager emailManager, IOptions<PasswordSettings> passwordSettings)
        {
            _unitOfWork = unitOfWork;
            this._emailManager = emailManager;
            _AuthenticationOptions = new AuthenticationOptions(passwordSettings.Value);
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
                    employeeDtoDto.emp_name = entity.emp_name;
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

                    await _emailManager.SendPaymentSuccessfulEmail();
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
        public async Task<EmployeeDto?> UpdateEmployeeAsync(EmployeeUpdateDto entity)
        {
            try
            {
                // Can not change the email due to security reasons. Can implement this feature later. 
                EmployeeDto employeeDtoDto = new EmployeeDto();

                employeeDtoDto.emp_id = entity.emp_id;
                employeeDtoDto.emp_name = entity.emp_name;
                employeeDtoDto.phone = entity.phone;
                employeeDtoDto.faculty_id = entity.faculty_id;
                employeeDtoDto.emp_role_id = entity.emp_role_id;
                employeeDtoDto.status = entity.status; 

                var employeeReuslt = await _unitOfWork.Employees.Update(employeeDtoDto);

                var employee = await GetByIdAsync(employeeDtoDto.emp_id);

                return employee;
            }
            catch (Exception ex)
            {
                //TODO log error and haddle the error
            }
            return null;
        }

        public async Task<IEnumerable<EmployeeDto>> GetAllAsync()
        {
            try
            {
                return await _unitOfWork.Employees.GetAllAsync();
            }
            catch (Exception ex)
            {
                //TODO log error and haddle the error
            }
            return null;
        }

        public async Task<EmployeeDto> GetByEmailAsync(string email)
        {
            try
            {
                return await _unitOfWork.Employees.GetByEmailAsync(email);
            }
            catch (Exception ex)
            {
                //TODO log error and haddle the error
            }
            return null;
        }

        public async Task<EmployeeDto> GetByIdAsync(int id)
        {
            try
            {
                return await _unitOfWork.Employees.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                //TODO log error and haddle the error
            }
            return null;
        }


    }
}
