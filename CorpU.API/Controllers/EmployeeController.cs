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
        public async Task<ActionResult> AddEmployee(EmployeeRegisterDto employeeDto)
        {
            try
            {
                _or = await _employeeManager.CreateEmployeeAsync(employeeDto);
            }
            catch (Exception ex)
            {
                _or = new OperationResult
                {
                    Message = "Error: employee creation failed.",
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Data = null
                };
                _logger.LogError("Error: employee update failed", _or);
            }
            return Ok(_or);
        }

        [HttpPost("Update")]
        public async Task<ActionResult> UpdateEmployee([FromQuery] EmployeeUpdateDto employeeDto)
        {
            try
            {
                _or = await _employeeManager.UpdateEmployeeAsync(employeeDto);
            }
            catch (Exception ex)
            {
                _or = new OperationResult
                {
                    Message = "Error: employee update failed.",
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Data = null
                };
                _logger.LogError("Error: employee update failed", _or);
            }
            return Ok(_or);
        }

        [HttpGet("GetByEmail")]
        public async Task<ActionResult> GetEmployeeByEmail(string email)
        {
            //TODO
            try
            {
                _or = await _employeeManager.GetByEmailAsync(email);
            }
            catch (Exception ex)
            {
                _or = new OperationResult
                {
                    Message = "Error: Exception occurred",
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Data = null
                };
                _logger.LogError("Error: Exception occurred", _or);
            }

            return Ok(_or);
        }

        [HttpGet("GetById")]
        public async Task<ActionResult> GetEmployeeById(int id)
        {
            try
            {
                _or = await _employeeManager.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                _or = new OperationResult
                {
                    Message = "Error: Exception occurred.",
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Data = null
                };
                _logger.LogError("Error: Exception occurred", _or);
            }

            return Ok(_or);
        }

        [HttpGet("All")]
        public async Task<ActionResult> GetAllEmployees()
        {
            //TODO
            try
            {
                _or = await _employeeManager.GetAllAsync();
            }
            catch (Exception ex)
            {
                _or = new OperationResult
                {
                    Message = "Error: Exception occurred",
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Data = null
                };
                _logger.LogError("Error: Exception occurred", _or);
            }

            return Ok(_or);
        }

    }
}
