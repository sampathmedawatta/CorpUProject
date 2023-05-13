using CorpU.API.Auth;
using CorpU.API.Auth.Interfaces;
using CorpU.Business;
using CorpU.Business.Interfaces;
using CorpU.Entitiy.Models;
using CorpU.Entitiy.Models.Dto.Applicant;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CorpU.API.Controllers
{
    [ApiKeyAuthentication]
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantController : ControllerBase
    {
        private readonly ILogger<ApplicantController> _logger;
        private readonly IApplicantManager _applicantManager;
        OperationResult _or;

        public ApplicantController(IApplicantManager applicantManager, ILogger<ApplicantController> logger)
        {
            this._applicantManager = applicantManager;
            this._logger = logger;
            this._or = new OperationResult();
        }
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("GetById")]
        public async Task<ActionResult> GetEmployeeById(int id)
        {
            try
            {
                var applicant = await _applicantManager.GetByIdAsync(id);
                if (applicant == null)
                {
                    _or = new OperationResult
                    {
                        Message = "employee details not found!",
                        StatusCode = (int)HttpStatusCode.NotFound,
                        Data = null
                    };
                }
                _or = new OperationResult
                {
                    Message = "employee details",
                    StatusCode = (int)HttpStatusCode.OK,
                    Data = applicant
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

        // POST api/<ApplicantController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ApplicantController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ApplicantController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
