using CorpU.Business.Interfaces;
using CorpU.Data.Models;
using CorpU.Data.Repository.Interfaces;
using CorpU.Entitiy.Models.Dto.User;

namespace CorpU.Business
{
    public class UserManager : IUserManager
    {
        private IUnitOfWork _unitOfWork;

        public UserManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<UserDto> CreateUserAsync(UserRegisterDto entity)
        {
            try
            {

                UserDto userDto = new UserDto();
                userDto.email = entity.email;
                userDto.password = entity.password;
                userDto.user_role_id = entity.user_role_id;

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

        public async Task<UserDto?> GetByEmailAndPasswordAsync(string email, string password)
        {
            //TODO : decript the password
            try
            {
                var result = await _unitOfWork.Users.GetByEmailAndPasswordAsync(email, password);
                
                if(result == null)
                {
                    return null;
                }

                return await _unitOfWork.Users.GetByIdAsync(result.user_id);
            }
            catch (Exception ex)
            {
               //TODO log error and haddle the error
            }
            return null;
        }
    }
}