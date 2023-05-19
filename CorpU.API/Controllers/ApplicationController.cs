using CorpU.API.Auth;
using CorpU.API.Auth.Interfaces;
using CorpU.Business;
using CorpU.Business.Interfaces;
using CorpU.Entitiy.Models;
using CorpU.Entitiy.Models.Dto.Applicant;
using CorpU.Entitiy.Models.Dto.Application;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
namespace CorpU.API.Controllers
{
    [ApiKeyAuthentication]
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly ILogger<ApplicationController> _logger;
        private readonly IApplicationManager _applicationManager;
        OperationResult _or;
        public ApplicationController(IApplicationManager applicationManager, ILogger<ApplicationController> logger)
        {
            this._applicationManager = applicationManager;
            this._logger = logger;
            this._or = new OperationResult();
        }
        [HttpGet("All")]
        public async Task<ActionResult> GetAllApplication()
        {
            try
            {
                IEnumerable<ApplicationDto> applicationList = await _applicationManager.GetAllAsync();

                if (applicationList == null)
                {
                    _or = new OperationResult
                    {
                        Message = "Application details not found!",
                        StatusCode = (int)HttpStatusCode.NotFound,
                        Data = null
                    };
                }
                _or = new OperationResult
                {
                    Message = "Application details",
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Data = applicationList
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

        [HttpGet("GetByApplicationId")]
        public async Task<ActionResult> GetByApplicationId(int id)
        {
            try
            {
                var application = await _applicationManager.GetByApplicationIdAsync(id);
                if (application == null)
                {
                    _or = new OperationResult
                    {
                        Message = "application details not found!",
                        StatusCode = (int)HttpStatusCode.NotFound,
                        Data = null
                    };
                }
                _or = new OperationResult
                {
                    Message = "application details",
                    StatusCode = (int)HttpStatusCode.OK,
                    Data = application
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
        [HttpGet("GetByApplicantId")]
        public async Task<ActionResult> GetByApplicantId(int id)
        {
            try
            {
                var application = await _applicationManager.GetByApplicantIdAsync(id);
                if (application == null)
                {
                    _or = new OperationResult
                    {
                        Message = "application details not found!",
                        StatusCode = (int)HttpStatusCode.NotFound,
                        Data = null
                    };
                }
                _or = new OperationResult
                {
                    Message = "application details",
                    StatusCode = (int)HttpStatusCode.OK,
                    Data = application
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
        [HttpPost("Add")]
        public async Task<ActionResult> CreateApplication(ApplicationRegisterDto value)
        {
            var application = await _applicationManager.CreateApplicationAsync(value);
            if (application == null)
            {
                _or = new OperationResult
                {
                    Message = "Error: application creation failed.",
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Data = null
                };
                _logger.LogError("Error: ", _or);
            }
            else
            {
                _or = new OperationResult
                {
                    Message = "applicant created successfully",
                    StatusCode = (int)HttpStatusCode.OK,
                    Data = application
                };
            }

            return Ok(_or);
        }
        [HttpPost("Update")]
        public async Task<ActionResult> UpdateApplication(ApplicationUpdateDto value)
        {
            try
            {
                _or = await _applicationManager.UpdateApplicationAsync(value);
            }
            catch (Exception ex)
            {
                _or = new OperationResult
                {
                    Message = "Error: application update failed.",
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Data = null
                };
                _logger.LogError("Error: application update failed", _or);
            }
            return Ok(_or);
        }

        // DELETE api/<ApplicationController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
