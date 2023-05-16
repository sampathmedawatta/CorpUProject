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
                _or =  await _userManager.GetByEmailAndPasswordAsync(userLogin.email, userLogin.password);

                if (_or.Data != null)
                { 
                    _logger.LogInformation("GetToken executed!");
                    AuthanticationResponse authanticationResponse = getToken();

                    if (authanticationResponse == null)
                    {
                        _or = new OperationResult
                        {
                            Error = "Can not generate the token.",
                            StatusCode = (int)HttpStatusCode.InternalServerError,
                            Data = null
                        };

                        _logger.LogError("Can not generate the token.", _or);
                        return Unauthorized(_or);
                    }

                    authanticationResponse.User = _or.Data;
                    _or.Data = authanticationResponse;

                    _logger.LogInformation("token generated.", _or);
                }
                else
                {
                    _logger.LogError("User login faild.", _or);
                }
            }
            catch (Exception ex)
            {
                _or = new OperationResult
                {
                    Message = "Error: user creation failed.",
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Data = null
                };
                _logger.LogError("Error: token generation failed.", _or);
            }
            return Ok(_or);
        }

        [HttpGet("GetByEmail")]
        public async Task<ActionResult> GetUserByEmail(string email)
        {
            try
            {
                _or = await _userManager.GetByEmailAsync(email);
            }
            catch (Exception ex)
            {
                _or = new OperationResult
                {
                    Message = "Error: Exception occurred.",
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Data = null
                };
                _logger.LogError("Error: Exception occurred.", _or);
            }

            return Ok(_or);
        }

        [HttpGet("GetById")]
        public async Task<ActionResult> GetUserById(int id)
        {
            try
            {
                _or = await _userManager.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                _or = new OperationResult
                {
                    Message = "Error: Exception occurred.",
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Data = null
                };
                _logger.LogError("Error: Exception occurred.", _or);
            }

            return Ok(_or);
        }

        [HttpGet("All")]
        public async Task<ActionResult> GetAllUsers()
        {
            try
            {
                _or = await _userManager.GetAllAsync();
            }
            catch (Exception ex)
            {
                _or = new OperationResult
                {
                    Message = "Error: Exception occurred.",
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Data = null
                };
                _logger.LogError("Error: Exception occurred.", _or);
            }

            return Ok(_or);
        }

        [HttpPost("Register")]
        public async Task<ActionResult> AddUser( UserRegisterDto userRegisterDto)
        {
            try
            {
                _or = await _userManager.CreateUserAsync(userRegisterDto);
                _logger.LogError("User registration success.", _or);
            }
            catch (Exception ex) { 
                _or = new OperationResult
                {
                    Message = "Error: Exception occurred.",
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Data = null
                };
                _logger.LogError("Error: Exception occurred.", _or);
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
