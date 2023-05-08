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
            try
            {
                var User = await table
                    .Where(e => e.email == Email)
                    .Where(e => e.password == Password)
                  .FirstOrDefaultAsync();

                return _mapper.Map<UserDto>(User);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
              

        public async Task<UserDto> GetByIdAsync(int id)
        {
            try
            {
                var user = await table.Where(c => c.user_id == id)
                    .Include(r => r.UserRole)
                    .FirstOrDefaultAsync();

                return _mapper.Map<UserEntity, UserDto>(user);
            }
            catch(Exception ex)
            {
                return null;
            }
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
