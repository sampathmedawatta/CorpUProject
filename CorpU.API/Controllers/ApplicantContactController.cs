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
    public class ApplicantContactController : ControllerBase
    {
        private readonly ILogger<ApplicantContactController> _logger;
        private readonly IApplicantContactManager _applicantContactManager;
        OperationResult _or;

        public ApplicantContactController(IApplicantContactManager applicantContactManager, ILogger<ApplicantContactController> logger)
        {
            this._applicantContactManager = applicantContactManager;
            this._logger = logger;
            this._or = new OperationResult();
        }
        [HttpGet("GetById")]
        public async Task<ActionResult> GetApplicantContactById(int id)
        {
            try
            {
                var applicantContact = await _applicantContactManager.GetByIdAsync(id);
                if (applicantContact == null)
                {
                    _or = new OperationResult
                    {
                        Message = "applicant contact details not found!",
                        StatusCode = (int)HttpStatusCode.NotFound,
                        Data = null
                    };
                }
                _or = new OperationResult
                {
                    Message = "applicant contact details",
                    StatusCode = (int)HttpStatusCode.OK,
                    Data = applicantContact
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
        public async Task<ActionResult> CreateApplicantContact(ApplicantContactRegisterDto value)
        {
            var applicantContact = await _applicantContactManager.CreateApplicantContactAsync(value);
            if (applicantContact == null)
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
                    Data = applicantContact
                };
            }

            return Ok(_or);
        }
        [HttpPost("Update")]
        public async Task<ActionResult> UpdateApplicantContact( ApplicantContactUpdateDto value)
        {
            try
            {
                _or = await _applicantContactManager.UpdateApplicantContactAsync(value);
            }
            catch (Exception ex)
            {
                _or = new OperationResult
                {
                    Message = "Error: applicant contact update failed.",
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Data = null
                };
                _logger.LogError("Error: applicant contact update failed", _or);
            }
            return Ok(_or);
        }

        // DELETE api/<ApplicantContact>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
