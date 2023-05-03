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

        public async Task<UserDto> GetByEmailAndPasswordAsync(string email, string password)
        {
            //TODO : decript the password
            var res = await _unitOfWork.Users.GetAllByEmailAndPasswordAsync(email, password);
            return res;
        }
    }
}