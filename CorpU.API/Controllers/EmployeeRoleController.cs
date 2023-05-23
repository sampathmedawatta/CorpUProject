using CorpU.API.Auth;
using CorpU.API.Auth.Interfaces;
using CorpU.Business;
using CorpU.Business.Interfaces;
using CorpU.Entitiy.Models;
using CorpU.Entitiy.Models.Dto.Referance;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
namespace CorpU.API.Controllers
{
    [ApiKeyAuthentication]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeRoleController : ControllerBase
    {
        private readonly ILogger<EmployeeRoleController> _logger;
        private readonly IEmployeeRoleManager _employeeManager;
        OperationResult _or;
        public EmployeeRoleController(IEmployeeRoleManager employeeManager, ILogger<EmployeeRoleController> logger)
        {
            this._employeeManager = employeeManager;
            this._logger = logger;
            this._or = new OperationResult();
        }
        [HttpGet("GetById")]
        public async Task<ActionResult> GetEmployeeRoleById(int id)
        {
            try
            {
                var employeeRole = await _employeeManager.GetByIdAsync(id);
                if (employeeRole == null)
                {
                    _or = new OperationResult
                    {
                        Message = "Employee Role not found!",
                        StatusCode = (int)HttpStatusCode.NotFound,
                        Data = null
                    };
                }
                _or = new OperationResult
                {
                    Message = "Employee Role details",
                    StatusCode = (int)HttpStatusCode.OK,
                    Data = employeeRole
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



        //[HttpGet("All")]
        //public async Task<ActionResult> GetAllFaculty()
        //{
        //    try
        //    {
        //        IEnumerable<FacultyDto> facultyList = await _facultyManager.GetAllAsync();



        //        if (facultyList == null)
        //        {
        //            _or = new OperationResult
        //            {
        //                Message = "Faculty details not found!",
        //                StatusCode = (int)HttpStatusCode.NotFound,
        //                Data = null
        //            };
        //        }
        //        _or = new OperationResult
        //        {
        //            Message = "Faculty details",
        //            StatusCode = (int)HttpStatusCode.InternalServerError,
        //            Data = facultyList
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        _or = new OperationResult
        //        {
        //            Message = "Error: failed.",
        //            StatusCode = (int)HttpStatusCode.InternalServerError,
        //            Data = null
        //        };
        //        _logger.LogError("Error: failed.", _or);
        //    }
        //    return Ok(_or);
        //}
    }
}