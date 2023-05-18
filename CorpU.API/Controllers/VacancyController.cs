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

namespace CorpU.API.Controllers
{
    [ApiKeyAuthentication]
    [Route("api/[controller]")]
    [ApiController]
    public class VacancyController : ControllerBase
    {
        private readonly ILogger<VacancyController> _logger;
        private readonly IVacancyManager _vacancyManager;
        OperationResult _or;

        public VacancyController(IVacancyManager vacancyManager, ILogger<VacancyController> logger)
        {
            this._vacancyManager = vacancyManager;
            this._logger = logger;
            this._or = new OperationResult();
        }
        [HttpGet("All")]
        public async Task<ActionResult> GetAllVacancy()
        {
            try
            {
                IEnumerable<VacancyDto> vacancyList = await _vacancyManager.GetAllAsync();

                if (vacancyList == null)
                {
                    _or = new OperationResult
                    {
                        Message = "Vacancy details not found!",
                        StatusCode = (int)HttpStatusCode.NotFound,
                        Data = null
                    };
                }
                _or = new OperationResult
                {
                    Message = "Vacancy details",
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Data = vacancyList
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
        public async Task<ActionResult> GetVacancyById(int id)
        {
            try
            {
                var vacancy = await _vacancyManager.GetByIdAsync(id);
                if (vacancy == null)
                {
                    _or = new OperationResult
                    {
                        Message = "vacancy details not found!",
                        StatusCode = (int)HttpStatusCode.NotFound,
                        Data = null
                    };
                }
                _or = new OperationResult
                {
                    Message = "vacancy details",
                    StatusCode = (int)HttpStatusCode.OK,
                    Data = vacancy
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
        public async Task<ActionResult> CreateVacancy(VacancyRegisterDto value)
        {
            var vacancy = await _vacancyManager.CreateVacancyAsync(value);
            if (vacancy == null)
            {
                _or = new OperationResult
                {
                    Message = "Error: vacancy creation failed.",
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Data = null
                };
                _logger.LogError("Error: ", _or);
            }
            else
            {
                _or = new OperationResult
                {
                    Message = "vacancy created successfully",
                    StatusCode = (int)HttpStatusCode.OK,
                    Data = vacancy
                };
            }

            return Ok(_or);
        }
        //[HttpPost("Update")]
        //public async Task<ActionResult> UpdateApplicant([FromQuery] ApplicantUpdateDto value)
        //{
        //    try
        //    {
        //        _or = await _applicantManager.UpdateEmployeeAsync(value);
        //    }
        //    catch (Exception ex)
        //    {
        //        _or = new OperationResult
        //        {
        //            Message = "Error: applicant update failed.",
        //            StatusCode = (int)HttpStatusCode.InternalServerError,
        //            Data = null
        //        };
        //        _logger.LogError("Error: applicant update failed", _or);
        //    }
        //    return Ok(_or);
        //}
    }
}
