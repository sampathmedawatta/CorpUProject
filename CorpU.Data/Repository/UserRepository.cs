using AutoMapper;
using CorpU.Data.Models;
using CorpU.Data.Repository.Interfaces;
using CorpU.Entitiy.Models.Dto.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpU.Data.Repository
{
    internal class UserRepository : IUserRepository<UserDto>
    {
        private readonly DataContext context;
        private readonly DbSet<UserEntity> table;
        private readonly IMapper _mapper;

        public UserRepository(DataContext context, IMapper mapper)
        {
            this.context = context;
            table = context.Set<UserEntity>();
            _mapper = mapper;
        }

        public async Task<UserDto> GetAllByEmailAndPasswordAsync(string Email, string Password)
        {
            var User = await table
                .Where(e => e.email == Email)
                .Where(e => e.password == Password)
              .FirstOrDefaultAsync();

            return _mapper.Map<UserDto>(User);
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
              

        public Task<UserDto> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> Insert(UserDto entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(UserDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
