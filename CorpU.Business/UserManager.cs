using CorpU.Business.Interfaces;
using CorpU.Common;
using CorpU.Data.Models;
using CorpU.Data.Repository.Interfaces;
using CorpU.Entitiy.Models.Dto.User;
using Microsoft.Extensions.Options;

namespace CorpU.Business
{
    public class UserManager : IUserManager
    {
        private IUnitOfWork _unitOfWork;
        readonly AuthenticationOptions _AuthenticationOptions;
        public UserManager(IUnitOfWork unitOfWork, IOptions<PasswordSettings> passwordSettings)
        {
            _unitOfWork = unitOfWork;
            _AuthenticationOptions = new AuthenticationOptions(passwordSettings.Value);
        }

        public async Task<UserDto> CreateUserAsync(UserRegisterDto entity)
        {
            try
            {
                var _password = _AuthenticationOptions.ConvertPasswordToHash(entity.password);
                UserDto userDto = new()
                {
                    email = entity.email,
                    password = _password.Hash,
                    salt = _password.Salt,
                    user_role_id = entity.user_role_id//  applicant
            };

                var result = await _unitOfWork.Users.Insert(userDto);

                if (result <= 0)
                {
                    return null;
                }

                return await _unitOfWork.Users.GetByIdAsync(userDto.user_id);
            }
            catch (Exception ex)
            {
                //TODO log error and haddle the error
            }
            return null;
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            try
            {
                return await _unitOfWork.Users.GetAllAsync();
            }
            catch (Exception ex)
            {
                //TODO log error and haddle the error
            }
            return null;
        }

        public async Task<UserDto> GetByEmailAndPasswordAsync(string email, string password)
        {
            try
            {
                var user = await _unitOfWork.Users.GetByEmailAsync(email);
                if (user != null)
                {
                    bool isPasswordCorrect = _AuthenticationOptions.ValidatePassword(password, user.password, user.salt);
                    if (isPasswordCorrect)
                    {
                        return await _unitOfWork.Users.GetByIdAsync(user.user_id);
                    }
                }
            }
            catch (Exception ex)
            {
               //TODO log error and haddle the error
            }
            return null;
        }

        public async Task<UserDto> GetByEmailAsync(string email)
        {
            try
            {
                return await _unitOfWork.Users.GetByEmailAsync(email);
              
            }
            catch (Exception ex)
            {
                //TODO log error and haddle the error
            }
            return null;
        }

        public async Task<UserDto> GetByIdAsync(int Id)
        {
            try
            {
                return await _unitOfWork.Users.GetByIdAsync(Id);

            }
            catch (Exception ex)
            {
                //TODO log error and haddle the error
            }
            return null;
        }
    }
}