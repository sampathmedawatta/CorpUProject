using CorpU.API.Auth;
using CorpU.API.Auth.Interfaces;
using CorpU.Business.Interfaces;
using CorpU.Entitiy.Models;
using CorpU.Entitiy.Models.Dto.Employee;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CorpU.API.Controllers
{
    [ApiKeyAuthentication]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IEmployeeManager _employeeManager;
        OperationResult _or;

        public EmployeeController(IEmployeeManager employeeManager, ILogger<EmployeeController> logger)
        {
            this._employeeManager = employeeManager;
            this._logger = logger;
            this._or = new OperationResult();
        }

        [HttpPost("Add")]
        public async Task<ActionResult> AddEmployee([FromQuery] EmployeeRegisterDto employeeDto)
        {
            try
            {
                var employee = await _employeeManager.CreateEmployeeAsync(employeeDto);
                if (employee == null)
                {
                    _or = new OperationResult
                    {
                        Message = "Error: employee creation failed.",
                        StatusCode = (int)HttpStatusCode.InternalServerError,
                        Data = null
                    };
                    _logger.LogError("Error: ", _or);
                }
                else
                {
                    _or = new OperationResult
                    {
                        Message = "Employee created successfully",
                        StatusCode = (int)HttpStatusCode.OK,
                        Data = employee
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
                _logger.LogError("Error: ", _or);
            }
            return Ok(_or);
        }

        [HttpPost("Update")]
        public async Task<ActionResult> UpdateEmployee([FromQuery] EmployeeUpdateDto employeeDto)
        {
            try
            {
                var employee = await _employeeManager.UpdateEmployeeAsync(employeeDto);
                if (employee == null)
                {
                    _or = new OperationResult
                    {
                        Message = "Error: employee update failed.",
                        StatusCode = (int)HttpStatusCode.InternalServerError,
                        Data = null
                    };
                    _logger.LogError("Error: ", _or);
                }
                else
                {
                    _or = new OperationResult
                    {
                        Message = "Employee update successfully",
                        StatusCode = (int)HttpStatusCode.OK,
                        Data = employee
                    };
                }
            }
            catch (Exception ex)
            {
                _or = new OperationResult
                {
                    Message = "Error: employee update failed.",
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Data = null
                };
                _logger.LogError("Error: ", _or);
            }
            return Ok(_or);
        }

        [HttpGet("GetByEmail")]
        public async Task<ActionResult> GetEmployeeByEmail(string email)
        {
            //TODO
            try
            {
                var employee = await _employeeManager.GetByEmailAsync(email);
                if (employee == null)
                {
                    _or = new OperationResult
                    {
                        Message = "User details not found!",
                        StatusCode = (int)HttpStatusCode.NotFound,
                        Data = null
                    };
                }
                _or = new OperationResult
                {
                    Message = "Employee details",
                    StatusCode = (int)HttpStatusCode.OK,
                    Data = employee
                };
            }
            catch (Exception ex)
            {
                _or = new OperationResult
                {
                    Message = "Error: user registration failed.",
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Data = null
                };
                _logger.LogError("Error: token generation failed.", _or);
            }

            return Ok(_or);
        }

        [HttpGet("GetById")]
        public async Task<ActionResult> GetEmployeeById(int id)
        {
            //TODO
            try
            {
                var employee = await _employeeManager.GetByIdAsync(id);
                if (employee == null)
                {
                    _or = new OperationResult
                    {
                        Message = "employee details not found!",
                        StatusCode = (int)HttpStatusCode.NotFound,
                        Data = null
                    };
                }
                _or = new OperationResult
                {
                    Message = "employee details",
                    StatusCode = (int)HttpStatusCode.OK,
                    Data = employee
                };
            }
            catch (Exception ex)
            {
                _or = new OperationResult
                {
                    Message = "Error: failed.",
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Data = null
                };
                _logger.LogError("Error: token generation failed.", _or);
            }

            return Ok(_or);
        }

        [HttpGet("All")]
        public async Task<ActionResult> GetAllEmployees()
        {
            //TODO
            try
            {
                IEnumerable<EmployeeDto> employeeList = await _employeeManager.GetAllAsync();

                if (employeeList == null)
                {
                    _or = new OperationResult
                    {
                        Message = "Employee details not found!",
                        StatusCode = (int)HttpStatusCode.NotFound,
                        Data = null
                    };
                }
                _or = new OperationResult
                {
                    Message = "Employee details",
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Data = employeeList
                };
            }
            catch (Exception ex)
            {
                _or = new OperationResult
                {
                    Message = "Error: failed.",
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Data = null
                };
                _logger.LogError("Error: failed.", _or);
            }

            return Ok(_or);
        }

    }
}
