using CorpU.API.Auth;
using CorpU.API.Auth.Interfaces;
using CorpU.Business;
using CorpU.Business.Interfaces;
using CorpU.Entitiy.Models;
using CorpU.Entitiy.Models.Dto.Applicant;
//using CorpU.Entitiy.Models.Dto.Employee;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CorpU.API.Controllers
{
    [ApiKeyAuthentication]
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantAvailabilityController : ControllerBase
    {
        private readonly ILogger<ApplicantAvailabilityController> _logger;
        private readonly IApplicantAvailabilityManager _applicantAvailabilityManager;
        OperationResult _or;
        public ApplicantAvailabilityController(IApplicantAvailabilityManager applicantAvailabilityManager, ILogger<ApplicantAvailabilityController> logger)
        {
            this._applicantAvailabilityManager = applicantAvailabilityManager;
            this._logger = logger;
            this._or = new OperationResult();
        }
        // GET: api/<ApplicantAvailabilityController>
        [HttpGet("All")]
        public async Task<ActionResult> GetAllApplicantAvailability()
        {
            try
            {
                IEnumerable<ApplicantAvailabilityDto> applicantAvailabilityList = await _applicantAvailabilityManager.GetAllAsync();

                if (applicantAvailabilityList == null)
                {
                    _or = new OperationResult
                    {
                        Message = "Applicant Availability not found!",
                        StatusCode = (int)HttpStatusCode.NotFound,
                        Data = null
                    };
                }
                _or = new OperationResult
                {
                    Message = "Applicant Availability details",
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Data = applicantAvailabilityList
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

        [HttpGet("GetById")]
        public async Task<ActionResult> GetApplicantById(int id)
        {
            try
            {
                var applicantAvailability = await _applicantAvailabilityManager.GetByIdAsync(id);
                if (applicantAvailability == null)
                {
                    _or = new OperationResult
                    {
                        Message = "applicant availability not found!",
                        StatusCode = (int)HttpStatusCode.NotFound,
                        Data = null
                    };
                }
                _or = new OperationResult
                {
                    Message = "Applicant Availability details",
                    StatusCode = (int)HttpStatusCode.OK,
                    Data = applicantAvailability
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
        public async Task<ActionResult> CreateApplicantAvailability(ApplicantAvailabilityRegisterDto value)
        {
            var applicantAvailability = await _applicantAvailabilityManager.CreateApplicantAvailabilityAsync(value);
            if (applicantAvailability == null)
            {
                _or = new OperationResult
                {
                    Message = "Error: applicant creation failed.",
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
                    Data = applicantAvailability
                };
            }

            return Ok(_or);
        }

        [HttpPut("Update")]
        public async Task<ActionResult> UpdateApplicantAvailability(ApplicantAvailabilityUpdateDto value)
        {
            try
            {
                _or = await _applicantAvailabilityManager.UpdateApplicantAvailabilityAsync(value);
            }
            catch (Exception ex)
            {
                _or = new OperationResult
                {
                    Message = "Error: applicant availability update failed.",
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Data = null
                };
                _logger.LogError("Error: applicant availability update failed", _or);
            }
            return Ok(_or);
        }

        // DELETE api/<ApplicantAvailabilityController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
