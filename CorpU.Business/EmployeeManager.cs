using CorpU.Business.Interfaces;
using CorpU.Common;
using CorpU.Data.Repository.Interfaces;
using CorpU.Entitiy.Models;
using CorpU.Entitiy.Models.Dto.Employee;
using CorpU.Entitiy.Models.Dto.User;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CorpU.Business
{
    public class EmployeeManager : IEmployeeManager
    {
        private IUnitOfWork _unitOfWork;
        private readonly IEmailManager _emailManager;
        readonly AuthenticationOptions _AuthenticationOptions;
        OperationResult _or;
        public EmployeeManager(IUnitOfWork unitOfWork, IEmailManager emailManager, IOptions<PasswordSettings> passwordSettings)
        {
            _unitOfWork = unitOfWork;
            this._emailManager = emailManager;
            _AuthenticationOptions = new AuthenticationOptions(passwordSettings.Value);
            this._or = new OperationResult();
        }

        public async Task<OperationResult> CreateEmployeeAsync(EmployeeRegisterDto entity)
        {
            try
            {
                var _employee = await GetByEmailAsync(entity.email);

                if (_employee.Data != null)
                {
                    _or = new OperationResult
                    {
                        Message = "Error: Employee already exist!",
                        StatusCode = (int)HttpStatusCode.OK,
                        Data = null
                    };

                    return _or;
                }
             
                //Create user account
                var _password = _AuthenticationOptions.GeneratePassword(true, true, true, true, 20);
                UserDto userDto = new()
                {
                    email = entity.email,
                    password = _password.Hash,
                    salt = _password.Salt,
                    user_role_id = 2 // Staff
                };

                var userResult = await _unitOfWork.Users.Insert(userDto);

                if (userResult >= 0)
                {
                    EmployeeDto employeeDto = new EmployeeDto();
                    employeeDto.emp_name = entity.emp_name;
                    employeeDto.email = entity.email;
                    employeeDto.phone = entity.phone;
                    employeeDto.faculty_id = entity.faculty_id;
                    employeeDto.user_id = userDto.user_id;
                    employeeDto.emp_role_id = entity.emp_role_id;
                    employeeDto.status = false;

                    var employeeReuslt = await _unitOfWork.Employees.Insert(employeeDto);

                    if (employeeReuslt <= 0)
                    {
                        // TODO role back user creation
                        var userDeleteResult = await _unitOfWork.Users.Delete(userDto.user_id);
                        _or = new OperationResult
                        {
                            Message = "Error: Employee creation faild!",
                            StatusCode = (int)HttpStatusCode.InternalServerError,
                            Data = null
                        };
                    }
                    else
                    {
                        var employee = await _unitOfWork.Employees.GetByIdAsync(employeeDto.emp_id);

                        // sent an email with username and password to employee.
                        await _emailManager.SendAccountSuccessfulEmail_Employee(employee, userDto);

                        _or = new OperationResult
                        {
                            Message = "Employee created successfully",
                            StatusCode = (int)HttpStatusCode.OK,
                            Data = employee
                        };

                    }
                }
                else
                {
                    _or = new OperationResult
                    {
                        Message = "Error: Employee created faild!",
                        StatusCode = (int)HttpStatusCode.InternalServerError,
                        Data = null
                    };
                }
            }
            catch (Exception ex)
            {
                _or = new OperationResult
                {
                    Message = "Error: employee creation failed.",
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Data = null
                };
            }
            return _or;
        }
        public async Task<OperationResult> UpdateEmployeeAsync(EmployeeUpdateDto entity)
        {
            try
            {
                var _employee = await GetByIdAsync(entity.emp_id);

                if (_employee.Data == null)
                {
                    _or = new OperationResult
                    {
                        Message = "Error: Employee details are not available!",
                        StatusCode = (int)HttpStatusCode.OK,
                        Data = null
                    };

                    return _or;
                }


                EmployeeDto employeeDtoDto = new EmployeeDto(); 
                
                employeeDtoDto.emp_id = entity.emp_id;
                employeeDtoDto.emp_name = entity.emp_name;
                employeeDtoDto.phone = entity.phone;
                employeeDtoDto.faculty_id = entity.faculty_id;
                employeeDtoDto.emp_role_id = entity.emp_role_id;
                employeeDtoDto.status = entity.status; 

                var employeeReuslt = await _unitOfWork.Employees.Update(employeeDtoDto);

                var employee = await GetByIdAsync(employeeDtoDto.emp_id);

                _or = new OperationResult
                {
                    Message = "Employee successfully updated.",
                    StatusCode = (int)HttpStatusCode.OK,
                    Data = employee
                };
            }
            catch (Exception ex)
            {
                _or = new OperationResult
                {
                    Message = "Error: Employee update faild!",
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Data = null
                };
            }
            return _or;
        }

        public async Task<OperationResult> GetAllAsync()
        {
            try
            {
                var employeeList = await _unitOfWork.Employees.GetAllAsync();
                if (employeeList!= null)
                {
                    _or = new OperationResult
                    {
                        Message = "Employee list is available",
                        StatusCode = (int)HttpStatusCode.OK,
                        Data = employeeList
                    };
                }
                else
                {
                    _or = new OperationResult
                    {
                        Message = "There are no employees in the system.",
                        StatusCode = (int)HttpStatusCode.NotFound,
                        Data = null
                    };
                }
            }
            catch (Exception ex)
            {
                _or = new OperationResult
                {
                    Error = "Error: Unable to get employee list.",
                    Message = "Error: Unable to employee list.",
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Data = await _unitOfWork.Users.GetAllAsync()
                };
            }
            return _or;
        }

        public async Task<OperationResult> GetByEmailAsync(string email)
        {
            try
            {
                var employee = await _unitOfWork.Employees.GetByEmailAsync(email);
                if (employee != null)
                {
                    _or = new OperationResult
                    {
                        Message = "Employee data is available",
                        StatusCode = (int)HttpStatusCode.OK,
                        Data = employee
                    };
                }
                else
                {
                    _or = new OperationResult
                    {
                        Message = "There is no employee in the system.",
                        StatusCode = (int)HttpStatusCode.NotFound,
                        Data = null
                    };
                }
            }
            catch (Exception ex)
            {
                _or = new OperationResult
                {
                    Error = "Error: Unable to get employee datails.",
                    Message = "Error: Unable to employee list.",
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Data = await _unitOfWork.Users.GetAllAsync()
                };
            }
            return _or;
        }

        public async Task<OperationResult> GetByIdAsync(int id)
        {
            try
            {
                var employee = await _unitOfWork.Employees.GetByIdAsync(id);
                if (employee != null)
                {
                    _or = new OperationResult
                    {
                        Message = "Employee data is available",
                        StatusCode = (int)HttpStatusCode.OK,
                        Data = employee
                    };
                }
                else
                {
                    _or = new OperationResult
                    {
                        Message = "There is no employee in the system.",
                        StatusCode = (int)HttpStatusCode.NotFound,
                        Data = null
                    };
                }
            }
            catch (Exception ex)
            {
                 _or = new OperationResult
                {
                    Error = "Error: Unable to get employee datails.",
                    Message = "Error: Unable to employee list.",
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Data = await _unitOfWork.Users.GetAllAsync()
                };
            }
            return _or;
        }


    }
}
