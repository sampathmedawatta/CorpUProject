using CorpU.API.Auth;
using CorpU.API.Auth.Interfaces;
using CorpU.Business;
using CorpU.Business.Interfaces;
using CorpU.Entitiy.Models;
using CorpU.Entitiy.Models.Dto.Applicant;
using CorpU.Entitiy.Models.Dto.Shortlist;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CorpU.API.Controllers
{
    [ApiKeyAuthentication]
    [Route("api/[controller]")]
    [ApiController]
    public class ShortlistController : ControllerBase
    {
        private readonly ILogger<ShortlistController> _logger;
        private readonly IShortlistManager _shortlistManager;
        OperationResult _or;

        public ShortlistController(IShortlistManager shortlistManager, ILogger<ShortlistController> logger)
        {
            this._shortlistManager = shortlistManager;
            this._logger = logger;
            this._or = new OperationResult();
        }
        [HttpGet("All")]
        public async Task<ActionResult> GetAllShortlist()
        {
            try
            {
                IEnumerable<ShortlistDetailDto> shortlistedList = await _shortlistManager.GetAllShortlistAsync();

                if (shortlistedList == null)
                {
                    _or = new OperationResult
                    {
                        Message = "Shortlist details not found!",
                        StatusCode = (int)HttpStatusCode.NotFound,
                        Data = null
                    };
                }
                _or = new OperationResult
                {
                    Message = "Shortlist details",
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Data = shortlistedList
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
        public async Task<ActionResult> GetShortlistByApplicationId(int id)
        {
            try
            {
                var shortlist = await _shortlistManager.GetShortlistByApplicationId(id);
                if (shortlist == null)
                {
                    _or = new OperationResult
                    {
                        Message = "shortlist details not found!",
                        StatusCode = (int)HttpStatusCode.NotFound,
                        Data = null
                    };
                }
                _or = new OperationResult
                {
                    Message = "Shortlist details",
                    StatusCode = (int)HttpStatusCode.OK,
                    Data = shortlist
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
        public async Task<ActionResult> CreateShortlist(ShortlistRegisterDto value)
        {
            var shortlist = await _shortlistManager.CreateShortlistAsync(value);
            if (shortlist == null)
            {
                _or = new OperationResult
                {
                    Message = "Error: shortlist creation failed.",
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Data = null
                };
                _logger.LogError("Error: ", _or);
            }
            else
            {
                _or = new OperationResult
                {
                    Message = "shortlist created successfully",
                    StatusCode = (int)HttpStatusCode.OK,
                    Data = shortlist
                };
            }

            return Ok(_or);
        }
        [HttpPost("Update")]
        public async Task<ActionResult> UpdateShortlist([FromQuery] ShortlistUpdateDto value)
        {
            try
            {
                _or = await _shortlistManager.UpdateShortlistAsync(value);
            }
            catch (Exception ex)
            {
                _or = new OperationResult
                {
                    Message = "Error: shortlist update failed.",
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Data = null
                };
                _logger.LogError("Error: shortlist update failed", _or);
            }
            return Ok(_or);
        }
    }    
}
