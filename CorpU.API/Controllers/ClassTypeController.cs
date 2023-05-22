using CorpU.API.Auth;
using CorpU.API.Auth.Interfaces;
using CorpU.Business;
using CorpU.Business.Interfaces;
using CorpU.Entitiy.Models;
using CorpU.Entitiy.Models.Dto.Applicant;
using CorpU.Entitiy.Models.Dto.Referance;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CorpU.API.Controllers
{
    [ApiKeyAuthentication]
    [Route("api/[controller]")]
    [ApiController]
    public class ClassTypeController : ControllerBase
    {
        private readonly ILogger<ClassTypeController> _logger;
        private readonly IClassTypeManager _classTypeManager;
        OperationResult _or;
        public ClassTypeController(IClassTypeManager classTypeManager, ILogger<ClassTypeController> logger)
        {
            this._classTypeManager = classTypeManager;
            this._logger = logger;
            this._or = new OperationResult();
        }

        [HttpGet("GetById")]
        public async Task<ActionResult> GetClassTypeById(int id)
        {
            try
            {
                var classType = await _classTypeManager.GetByIdAsync(id);
                if (classType == null)
                {
                    _or = new OperationResult
                    {
                        Message = "Class Type not found!",
                        StatusCode = (int)HttpStatusCode.NotFound,
                        Data = null
                    };
                }
                _or = new OperationResult
                {
                    Message = "Class type details",
                    StatusCode = (int)HttpStatusCode.OK,
                    Data = classType
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
        public async Task<ActionResult> GetAllQualifications()
        {
            try
            {
                IEnumerable<ClassTypeDto> classTypeList = await _classTypeManager.GetAllAsync();

                if (classTypeList == null)
                {
                    _or = new OperationResult
                    {
                        Message = "Class type details not found!",
                        StatusCode = (int)HttpStatusCode.NotFound,
                        Data = null
                    };
                }
                _or = new OperationResult
                {
                    Message = "Class type details",
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Data = classTypeList
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

        // POST api/<Qualification>
        [HttpPost("Add")]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<Qualification>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<Qualification>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
