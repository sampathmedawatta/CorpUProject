using CorpU.API.Auth;
using CorpU.API.Auth.Interfaces;
using CorpU.Business;
using CorpU.Business.Interfaces;
using CorpU.Entitiy.Models;
using CorpU.Entitiy.Models.Dto.Applicant;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CorpU.API.Controllers
{
    [ApiKeyAuthentication]
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantQualificationController : ControllerBase
    {
        private readonly ILogger<ApplicantQualificationController> _logger;
        private readonly IApplicantQualificationManager _applicantQualificationManager;
        OperationResult _or;

        public ApplicantQualificationController(IApplicantQualificationManager applicantQualificationManager, ILogger<ApplicantQualificationController> logger)
        {
            this._applicantQualificationManager = applicantQualificationManager;
            this._logger = logger;
            this._or = new OperationResult();
        }
        [HttpGet("GetById")]
        public async Task<ActionResult> GetApplicantQualificationById(int id)
        {
            try
            {
                var applicantQualification = await _applicantQualificationManager.GetByIdAsync(id);
                if (applicantQualification == null)
                {
                    _or = new OperationResult
                    {
                        Message = "applicant qualification details not found!",
                        StatusCode = (int)HttpStatusCode.NotFound,
                        Data = null
                    };
                }
                _or = new OperationResult
                {
                    Message = "applicant qualification details",
                    StatusCode = (int)HttpStatusCode.OK,
                    Data = applicantQualification
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
        public async Task<ActionResult> CreateApplicantQualification(ApplicantQualificationRegisterDto value)
        {
            var applicantContact = await _applicantQualificationManager.CreateApplicantQualificationAsync(value);
            if (applicantContact == null)
            {
                _or = new OperationResult
                {
                    Message = "Error: applicant qualification creation failed.",
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Data = null
                };
                _logger.LogError("Error: ", _or);
            }
            else
            {
                _or = new OperationResult
                {
                    Message = "applicant qualification created successfully",
                    StatusCode = (int)HttpStatusCode.OK,
                    Data = applicantContact
                };
            }

            return Ok(_or);
        }
        [HttpPost("Update")]
        public async Task<ActionResult> UpdateApplicantQualification([FromQuery] ApplicantQualificationUpdateDto value)
        {
            try
            {
                _or = await _applicantQualificationManager.UpdateApplicantQualificationAsync(value);
            }
            catch (Exception ex)
            {
                _or = new OperationResult
                {
                    Message = "Error: applicant qualification update failed.",
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Data = null
                };
                _logger.LogError("Error: applicant qualification update failed", _or);
            }
            return Ok(_or);
        }

        // DELETE api/<ApplicantQualification>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
