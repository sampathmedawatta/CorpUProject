using CorpU.API.Auth;
using CorpU.API.Auth.Interfaces;
using CorpU.Business;
using CorpU.Business.Interfaces;
using CorpU.Entitiy.Models;
using CorpU.Entitiy.Models.Dto.Applicant;
using CorpU.Entitiy.Models.Dto.Shortlist;
using CorpU.Entitiy.Models.Dto.Unit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CorpU.API.Controllers
{
    [ApiKeyAuthentication]
    [Route("api/[controller]")]
    [ApiController]
    public class OfferController : ControllerBase
    {
        private readonly ILogger<OfferController> _logger;
        private readonly IOfferManager _offerManager;
        OperationResult _or;

        public OfferController(IOfferManager offerManager, ILogger<OfferController> logger)
        {
            this._offerManager = offerManager;
            this._logger = logger;
            this._or = new OperationResult();
        }
        [HttpGet("All")]
        public async Task<ActionResult> GetAllOffer()
        {
            try
            {
                IEnumerable<OfferDetailDto> offerList = await _offerManager.GetAllOfferAsync();

                if (offerList == null)
                {
                    _or = new OperationResult
                    {
                        Message = "Offer details not found!",
                        StatusCode = (int)HttpStatusCode.NotFound,
                        Data = null
                    };
                }
                _or = new OperationResult
                {
                    Message = "Offer details",
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Data = offerList
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
        public async Task<ActionResult> GetOfferByApplicationId(int id)
        {
            try
            {
                var offer = await _offerManager.GetOfferByApplicationId(id);
                if (offer == null)
                {
                    _or = new OperationResult
                    {
                        Message = "offer details not found!",
                        StatusCode = (int)HttpStatusCode.NotFound,
                        Data = null
                    };
                }
                _or = new OperationResult
                {
                    Message = "Offer details",
                    StatusCode = (int)HttpStatusCode.OK,
                    Data = offer
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
        public async Task<ActionResult> CreateOffer(OfferRegisterDto value)
        {
            var offer = await _offerManager.CreateOfferAsync(value);
            if (offer == null)
            {
                _or = new OperationResult
                {
                    Message = "Error: offer creation failed.",
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Data = null
                };
                _logger.LogError("Error: ", _or);
            }
            else
            {
                _or = new OperationResult
                {
                    Message = "offer created successfully",
                    StatusCode = (int)HttpStatusCode.OK,
                    Data = offer
                };
            }

            return Ok(_or);
        }
    }
}
