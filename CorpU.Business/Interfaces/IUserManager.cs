﻿using CorpU.Data.Models;
using CorpU.Entitiy.Models.Dto.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpU.Business.Interfaces
{
    public interface IUserManager : IBaseManager
    {
        Task<UserDto> GetByEmailAndPasswordAsync(string email, string password);
        Task<UserDto> GetByEmailAsync(string email);
        Task<IEnumerable<UserDto>> GetAllAsync();
        Task<UserDto> CreateUserAsync(UserRegisterDto entity);


    }
}
