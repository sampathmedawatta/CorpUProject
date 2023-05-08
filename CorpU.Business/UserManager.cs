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

        public async Task<UserDto?> GetByEmailAndPasswordAsync(string email, string password)
        {
            //TODO : decript the password
            try
            {
                var result = await _unitOfWork.Users.GetAllByEmailAndPasswordAsync(email, password);
                
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