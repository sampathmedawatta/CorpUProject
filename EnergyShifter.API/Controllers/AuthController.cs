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
        OperationResult _or;
        public AuthController( ITokenGenerator tokenGenerator,  IOptions<JwtTokenSettings> jwtTokenSettings)
        {
            this._tokenGenerator = tokenGenerator;
            this._jwtTokenSettings = jwtTokenSettings.Value;
        }

        [AllowAnonymous]
        [HttpGet("HealthCheck")]
        public ActionResult HealthCheck()
        {
            return Ok();
        }

        [HttpGet()]
        public ActionResult GetToken()
        {
            try
            {
                AuthanticationResponse authanticationResponse = _tokenGenerator.GenerateToken(_jwtTokenSettings.JWT_Secret, "UserName", double.Parse(_jwtTokenSettings.TokenLifeTime));

                if (authanticationResponse == null)
                {
                    _or = new OperationResult
                    {
                        Error = "Can not generate the token.",
                        StatusCode = (int)HttpStatusCode.NotFound,
                        Data = null
                    };
                    return Unauthorized(_or);
                }

                _or = new OperationResult
                {
                    Message = "token generated.",
                    StatusCode = (int)HttpStatusCode.OK,
                    Data = authanticationResponse
                };
            }
            catch (Exception ex)
            {
                _or = new OperationResult
                {
                    Message = "Error: token generation failed.",
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Data = null
                };
            }
            return Ok(_or);
        }
    }
}
