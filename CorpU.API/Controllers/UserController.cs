using CorpU.API.Auth;
using CorpU.API.Auth.Interfaces;
using CorpU.Business.Interfaces;
using CorpU.Common;
using CorpU.Entitiy.Models;
using CorpU.Entitiy.Models.Auth;
using CorpU.Entitiy.Models.Dto.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Net;

namespace CorpU.API.Controllers
{
    [ApiKeyAuthentication]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ITokenGenerator _tokenGenerator;
        private readonly JwtTokenSettings _jwtTokenSettings;
        private readonly ILogger<UserController> _logger;
        private readonly IUserManager _userManager;
        OperationResult _or;

        public UserController(IUserManager userManager, ITokenGenerator tokenGenerator, IOptions<JwtTokenSettings> jwtTokenSettings, ILogger<UserController> logger)
        {
            this._userManager = userManager;
            this._tokenGenerator = tokenGenerator;
            this._jwtTokenSettings = jwtTokenSettings.Value;
            this._logger = logger;
            this._or = new OperationResult();
        }

        [HttpGet("Login")]
        public async Task<ActionResult> UserLogin([FromQuery] UserLoginDto userLogin)
        {
            try
            {
                var user =  await _userManager.GetByEmailAndPasswordAsync(userLogin.email, userLogin.password);

                if (user == null)
                {
                    _or = new OperationResult
                    {
                        Message = "Error: token generation failed.",
                        StatusCode = (int)HttpStatusCode.InternalServerError,
                        Data = null
                    };
                    _logger.LogError("Error: token generation failed.", _or);
                }
                else
                {
                    _logger.LogInformation("GetToken executed!");
                    AuthanticationResponse authanticationResponse = getToken();

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

                    authanticationResponse.User = user;
                    _or = new OperationResult
                    {
                        Message = "token generated.",
                        StatusCode = (int)HttpStatusCode.OK,
                        Data = authanticationResponse
                    };
                    _logger.LogInformation("token generated.", _or);

                }
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

        [HttpGet()]
        public async Task<ActionResult> UserGet([FromQuery] UserLoginDto userLogin)
        {
            //TODO
            UserDto userDto = new UserDto();
            userDto.email = "sss@sss.com";
            userDto.password = "11212121221212121";
            userDto.user_role_id = 1;

            _or = new OperationResult
            {
                Message = "user details",
                StatusCode = (int)HttpStatusCode.InternalServerError,
                Data = userDto
            };

            return Ok(_or);
        }
            
        [HttpPost]
        public async Task<ActionResult> UserAdd([FromQuery] UserRegisterDto userRegisterDto)
        {
            try
            {
                var user = await _userManager.CreateUserAsync(userRegisterDto);
            }
            catch (Exception ex) { 
                _or = new OperationResult
                {
                    Message = "Error: user registration failed.",
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Data = null
                };
                _logger.LogError("Error: token generation failed.", _or);
            }
            return Ok(_or);
        }

        private AuthanticationResponse getToken()
        {
            _logger.LogInformation("GetToken executed!");

            return  _tokenGenerator.GenerateToken(_jwtTokenSettings.JWT_Secret, "UserName", double.Parse(_jwtTokenSettings.TokenLifeTime));
        }
    }
}
