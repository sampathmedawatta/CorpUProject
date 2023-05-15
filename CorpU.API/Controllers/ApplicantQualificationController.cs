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

        // POST api/<ApplicantQualification>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ApplicantQualification>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ApplicantQualification>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
