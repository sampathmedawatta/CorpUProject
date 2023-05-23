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
    public class FacultyController : ControllerBase
    {
        private readonly ILogger<FacultyController> _logger;
        private readonly IFacultyManager _facultyManager;
        OperationResult _or;
        public FacultyController(IFacultyManager facultyManager, ILogger<FacultyController> logger)
        {
            this._facultyManager = facultyManager;
            this._logger = logger;
            this._or = new OperationResult();
        }
        [HttpGet("GetById")]
        public async Task<ActionResult> GetFacultyById(int id)
        {
            try
            {
                var faculty = await _facultyManager.GetByIdAsync(id);
                if (faculty == null)
                {
                    _or = new OperationResult
                    {
                        Message = "Faculty not found!",
                        StatusCode = (int)HttpStatusCode.NotFound,
                        Data = null
                    };
                }
                _or = new OperationResult
                {
                    Message = "Faculty details",
                    StatusCode = (int)HttpStatusCode.OK,
                    Data = faculty
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
        public async Task<ActionResult> GetAllFaculty()
        {
            try
            {
                IEnumerable<FacultyDto> facultyList = await _facultyManager.GetAllAsync();



                if (facultyList == null)
                {
                    _or = new OperationResult
                    {
                        Message = "Faculty details not found!",
                        StatusCode = (int)HttpStatusCode.NotFound,
                        Data = null
                    };
                }
                _or = new OperationResult
                {
                    Message = "Faculty details",
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Data = facultyList
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