using CorpU.API.Auth.Interfaces;
using CorpU.Business.Interfaces;
using CorpU.Entitiy.Models;
using CorpU.Entitiy.Models.Dto.Employee;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CorpU.API.Controllers
{
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

        [HttpPost]
        public async Task<ActionResult> AddUser([FromQuery] EmployeeRegisterDto employeeDto)
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

    }
}
