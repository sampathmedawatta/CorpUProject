using CorpU.API.Auth;
using CorpU.API.Auth.Interfaces;
using CorpU.Business;
using CorpU.Business.Interfaces;
using CorpU.Entitiy.Models;
using CorpU.Entitiy.Models.Dto.Referance;
using CorpU.Entitiy.Models.Dto.Unit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CorpU.API.Controllers
{
    [ApiKeyAuthentication]
    [Route("api/[controller]")]
    [ApiController]
    public class UnitController : ControllerBase
    {
        private readonly ILogger<UnitController> _logger;
        private readonly IUnitManager _unitManager;
        OperationResult _or;
        public UnitController(IUnitManager unitManager, ILogger<UnitController> logger)
        {
            this._unitManager = unitManager;
            this._logger = logger;
            this._or = new OperationResult();
        }

        [HttpGet("GetById")]
        public async Task<ActionResult> GetUnitById(int id)
        {
            try
            {
                var unit = await _unitManager.GetByIdAsync(id);
                if (unit == null)
                {
                    _or = new OperationResult
                    {
                        Message = "Unit not found!",
                        StatusCode = (int)HttpStatusCode.NotFound,
                        Data = null
                    };
                }
                _or = new OperationResult
                {
                    Message = "Unit details",
                    StatusCode = (int)HttpStatusCode.OK,
                    Data = unit
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
        public async Task<ActionResult> GetAllUnits()
        {
            try
            {
                IEnumerable<UnitDto> unitList = await _unitManager.GetAllAsync();

                if (unitList == null)
                {
                    _or = new OperationResult
                    {
                        Message = "Unit details not found!",
                        StatusCode = (int)HttpStatusCode.NotFound,
                        Data = null
                    };
                }
                _or = new OperationResult
                {
                    Message = "Applicant details",
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Data = unitList
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
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<UnitController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<UnitController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
