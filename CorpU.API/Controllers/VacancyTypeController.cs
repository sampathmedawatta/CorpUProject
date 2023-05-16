using CorpU.API.Auth;
using CorpU.API.Auth.Interfaces;
using CorpU.Business;
using CorpU.Business.Interfaces;
using CorpU.Entitiy.Models;
using CorpU.Entitiy.Models.Dto.Applicant;
using CorpU.Entitiy.Models.Dto.Employee;
using CorpU.Entitiy.Models.Dto.Unit;
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
    public class VacancyTypeController : ControllerBase
    {
        private readonly ILogger<VacancyTypeController> _logger;
        private readonly IVacancyTypeManager _vacancyTypeManager;
        OperationResult _or;
        public VacancyTypeController(IVacancyTypeManager vacancyTypeManager, ILogger<VacancyTypeController> logger)
        {
            this._vacancyTypeManager = vacancyTypeManager;
            this._logger = logger;
            this._or = new OperationResult();
        }

        [HttpGet("All")]
        public async Task<ActionResult> GetAllVacancyType()
        {
            try
            {
                IEnumerable<VacancyTypeDto> vacancyTypeList = await _vacancyTypeManager.GetAllAsync();

                if (vacancyTypeList == null)
                {
                    _or = new OperationResult
                    {
                        Message = "Vacancy type not found!",
                        StatusCode = (int)HttpStatusCode.NotFound,
                        Data = null
                    };
                }
                _or = new OperationResult
                {
                    Message = "Vacancy type details",
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Data = vacancyTypeList
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
        public async Task<ActionResult> GetVacancyTypeById(int id)
        {
            try
            {
                var vacancyType = await _vacancyTypeManager.GetByIdAsync(id);
                if (vacancyType == null)
                {
                    _or = new OperationResult
                    {
                        Message = "vacancy type details not found!",
                        StatusCode = (int)HttpStatusCode.NotFound,
                        Data = null
                    };
                }
                _or = new OperationResult
                {
                    Message = "vacancy type details",
                    StatusCode = (int)HttpStatusCode.OK,
                    Data = vacancyType
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

        // POST api/<VacancyTypeController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<VacancyTypeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<VacancyTypeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
