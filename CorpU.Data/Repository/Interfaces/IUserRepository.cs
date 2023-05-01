using CorpU.Entitiy.Models.Dto.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpU.Data.Repository.Interfaces
{
    public interface IUserRepository<T> : IRepository<T> where T : class
    {
        Task<UserDto> GetAllByEmailAndPasswordAsync(string Email, string Password);
    }
}
