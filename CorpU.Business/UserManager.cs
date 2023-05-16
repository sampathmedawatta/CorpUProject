using CorpU.Business.Interfaces;
using CorpU.Common;
using CorpU.Data.Models;
using CorpU.Data.Repository.Interfaces;
using CorpU.Entitiy.Models;
using CorpU.Entitiy.Models.Dto.User;
using Microsoft.Extensions.Options;
using System.Net;

namespace CorpU.Business
{
    public class UserManager : IUserManager
    {
        private IUnitOfWork _unitOfWork;
        readonly AuthenticationOptions _AuthenticationOptions;
        OperationResult _or;
        public UserManager(IUnitOfWork unitOfWork, IOptions<PasswordSettings> passwordSettings)
        {
            _unitOfWork = unitOfWork;
            _AuthenticationOptions = new AuthenticationOptions(passwordSettings.Value);
            this._or = new OperationResult();
        }

        public async Task<OperationResult> CreateUserAsync(UserRegisterDto entity)
        {
            try
            {
               var user =  _unitOfWork.Users.GetByEmailAsync(entity.email);
                if(user != null)
                {
                    _or = new OperationResult
                    {
                        Error = "Error: User account already exsist.",
                        Message = "Error: User account already exsist.",
                        StatusCode = (int)HttpStatusCode.OK,
                        Data = null
                    };
                }

                var _password = _AuthenticationOptions.ConvertPasswordToHash(entity.password);
                UserDto userDto = new()
                {
                    email = entity.email,
                    password = _password.Hash,
                    salt = _password.Salt,
                    user_role_id = entity.user_role_id
                };

                var result = await _unitOfWork.Users.Insert(userDto);

                if (result <= 0)
                {
                    _or = new OperationResult
                    {
                        Error = "Error: Unable to create user account.",
                        Message = "Error: Unable to create user account.",
                        StatusCode = (int)HttpStatusCode.OK,
                        Data = null
                    };
                }

                var _user = await _unitOfWork.Users.GetByIdAsync(userDto.user_id);

                _or = new OperationResult
                {
                    Message = "User account created successfully.",
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Data = _user
                };
            }

            catch (Exception ex)
            {
                _or = new OperationResult
                {
                    Error = "Error: Unable to create user account.",
                    Message = "Error: Unable to create user account.",
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Data = null
                };
            }
            return _or;
        }

        public async Task<OperationResult> GetAllAsync()
        {
            try
            {
                var userList = await _unitOfWork.Users.GetAllAsync();
                if (userList != null)
                {
                    _or = new OperationResult
                    {
                        Message = "User list is available.",
                        StatusCode = (int)HttpStatusCode.OK,
                        Data = userList
                    };
                }
                else
                {
                    _or = new OperationResult
                    {
                        Message = "There are no users in the system.",
                        StatusCode = (int)HttpStatusCode.OK,
                        Data =null
                    };
                }
                
            }
            catch (Exception ex)
            {
                _or = new OperationResult
                {
                    Error = "Error: Unable to get user list.",
                    Message = "Error: Unable to create user list.",
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Data = await _unitOfWork.Users.GetAllAsync()
                };
            }
            return _or;
        }

        public async Task<OperationResult> GetByEmailAndPasswordAsync(string email, string password)
        {
            try
            {
                var user = await _unitOfWork.Users.GetByEmailAsync(email);
                if (user != null)
                {
                    bool isPasswordCorrect = _AuthenticationOptions.ValidatePassword(password, user.password, user.salt);
                    if (isPasswordCorrect)
                    {
                        _or = new OperationResult
                        {
                            Message = "User list is available.",
                            StatusCode = (int)HttpStatusCode.OK,
                            Data = await _unitOfWork.Users.GetByIdAsync(user.user_id)
                        };
                    }
                    else
                    {
                        _or = new OperationResult
                        {
                            Message = "Error: username or password incorrect.",
                            StatusCode = (int)HttpStatusCode.OK,
                            Data = null
                        };
                    }
                }
                else
                {
                    _or = new OperationResult
                    {
                        Message = "Error: username or password incorrect.",
                        StatusCode = (int)HttpStatusCode.OK,
                        Data = null
                    };
                }
            }
            catch (Exception ex)
            {
                _or = new OperationResult
                {
                    Error = "Error: Unable to get user datails.",
                    Message = "Error: Unable to create datails.",
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Data = await _unitOfWork.Users.GetAllAsync()
                };
            }
            return _or;
        }

        public async Task<OperationResult> GetByEmailAsync(string email)
        {
            try
            {
                var user = await _unitOfWork.Users.GetAllAsync();
                if (user != null)
                {
                    _or = new OperationResult
                    {
                        Message = "User data is available.",
                        StatusCode = (int)HttpStatusCode.OK,
                        Data = user
                    };
                }
                else
                {
                    _or = new OperationResult
                    {
                        Message = "User data is not available.",
                        StatusCode = (int)HttpStatusCode.OK,
                        Data = null
                    };
                }
            }
            catch (Exception ex)
            {
                _or = new OperationResult
                {
                    Error = "Error: Unable to get user datails.",
                    Message = "Error: Unable to create user datails.",
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Data = await _unitOfWork.Users.GetAllAsync()
                };
            }
            return _or;
        }

        public async Task<OperationResult> GetByIdAsync(int Id)
        {
            try
            {
                var user = await _unitOfWork.Users.GetByIdAsync(Id);
                if (user != null)
                {
                    _or = new OperationResult
                    {
                        Message = "User data is available.",
                        StatusCode = (int)HttpStatusCode.OK,
                        Data = user
                    };
                }
                else
                {
                    _or = new OperationResult
                    {
                        Message = "User data is not available.",
                        StatusCode = (int)HttpStatusCode.OK,
                        Data = null
                    };
                }
            }
            catch (Exception ex)
            {
                _or = new OperationResult
                {
                    Error = "Error: Unable to get user datails.",
                    Message = "Error: Unable to create user datails.",
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Data = await _unitOfWork.Users.GetAllAsync()
                };
            }
            return _or;
        }
    }
}