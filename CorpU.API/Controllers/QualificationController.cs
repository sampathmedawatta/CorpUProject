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
    public class QualificationController : ControllerBase
    {
        private readonly ILogger<QualificationController> _logger;
        private readonly IQualificationManager _qualificationManager;
        OperationResult _or;
        public QualificationController(IQualificationManager qualificationManager, ILogger<QualificationController> logger)
        {
            this._qualificationManager = qualificationManager;
            this._logger = logger;
            this._or = new OperationResult();
        }


        [HttpGet("GetById")]
        public async Task<ActionResult> GetQualificationById(int id)
        {
            try
            {
                var qualification = await _qualificationManager.GetByIdAsync(id);
                if (qualification == null)
                {
                    _or = new OperationResult
                    {
                        Message = "qualification not found!",
                        StatusCode = (int)HttpStatusCode.NotFound,
                        Data = null
                    };
                }
                _or = new OperationResult
                {
                    Message = "qualification details",
                    StatusCode = (int)HttpStatusCode.OK,
                    Data = qualification
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
                IEnumerable<QualificationTypeDto> applicantList = await _qualificationManager.GetAllAsync();

                if (applicantList == null)
                {
                    _or = new OperationResult
                    {
                        Message = "Applicant details not found!",
                        StatusCode = (int)HttpStatusCode.NotFound,
                        Data = null
                    };
                }
                _or = new OperationResult
                {
                    Message = "Applicant details",
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Data = applicantList
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
        [HttpPost]
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
