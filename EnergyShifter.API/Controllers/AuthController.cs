using EnergyShifter.API.Auth;
using EnergyShifter.API.Auth.Interfaces;
using EnergyShifter.Common;
using EnergyShifter.Entitiy.Models;
using EnergyShifter.Entitiy.Models.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Net;

namespace EnergyShifter.API.Controllers
{
    [ApiKeyAuthentication]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ITokenGenerator _tokenGenerator;
        private readonly JwtTokenSettings _jwtTokenSettings;
        private readonly ILogger<AuthController> _logger;
        OperationResult _or;
        public AuthController( ITokenGenerator tokenGenerator, IOptions<JwtTokenSettings> jwtTokenSettings, ILogger<AuthController> logger)
        {
            this._tokenGenerator = tokenGenerator;
            this._jwtTokenSettings = jwtTokenSettings.Value;
            this._logger = logger;
        }

        [AllowAnonymous]
        [HttpGet("HealthCheck")]
        public ActionResult HealthCheck()
        {
            _logger.LogInformation("Health Check executed!");
            return Ok();
        }

        [HttpGet()]
        public ActionResult GetToken()
        {
            try
            {
                _logger.LogInformation("GetToken executed!");

                AuthanticationResponse authanticationResponse = _tokenGenerator.GenerateToken(_jwtTokenSettings.JWT_Secret, "UserName", double.Parse(_jwtTokenSettings.TokenLifeTime));

                if (authanticationResponse == null)
                {
                    _or = new OperationResult
                    {
                        Error = "Can not generate the token.",
                        StatusCode = (int)HttpStatusCode.NotFound,
                        Data = null
                    };

                    _logger.LogError("Can not generate the token.", _or);
                    return Unauthorized(_or);
                }

                _or = new OperationResult
                {
                    Message = "token generated.",
                    StatusCode = (int)HttpStatusCode.OK,
                    Data = authanticationResponse
                };
                _logger.LogInformation("token generated.", _or);
            }
            catch (Exception ex)
            {
                _or = new OperationResult
                {
                    Message = "Error: token generation failed.",
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Data = null
                };
                _logger.LogError("Error: token generation failed.", _or);
            }
            return Ok(_or);
        }
    }
}
