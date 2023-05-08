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

        public async Task<UserDto> GetByEmailAndPasswordAsync(string Email, string Password)
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
        public async Task<UserDto> GetByEmailAsync(string Email)
        {
            try
            {
                var User = await table
                    .Where(e => e.email == Email)
                  .FirstOrDefaultAsync();

                return _mapper.Map<UserDto>(User);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            try
            {
                var UserList = await table
                   .Include(r => r.UserRole)
                    .ToListAsync();

                return _mapper.Map<IEnumerable<UserDto>>(UserList);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<UserDto> GetByIdAsync(int id)
        {
            try
            {
                var user = await table
                    .Where(e => e.user_id == id)
                    .Include(r => r.UserRole)
                    .FirstOrDefaultAsync();

                return _mapper.Map<UserEntity, UserDto>(user);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<int> Insert(UserDto entity)
        {
            try
            {
                UserEntity userEntity;
                userEntity = _mapper.Map<UserDto, UserEntity>(entity);

                this.context.Set<UserEntity>().Add(userEntity);
                int excecutedRows = await this.context.SaveChangesAsync();

                entity.user_id = userEntity.user_id;
                return excecutedRows;
            }
            catch(Exception ex)
            {
                return 0;
            }
        }
        public async Task<int> Update(UserDto entity)
        {
            try
            {
                UserEntity? User = await table.Where(c => c.user_id == entity.user_id).FirstOrDefaultAsync();

                if (User != null)
                {
                    User.email = entity.email;

                    int excecutedRows = await this.context.SaveChangesAsync();
                    return excecutedRows;
                }
            }
            catch (Exception ex)
            {
               
            }
            return 0;

        }
        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
