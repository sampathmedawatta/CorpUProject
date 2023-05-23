using AutoMapper;
using CorpU.Data.Models;
using CorpU.Data.Repository.Interfaces;
using CorpU.Entitiy.Models.Dto.Referance;
using CorpU.Entitiy.Models.Dto.Employee;
using CorpU.Entitiy.Models.Dto.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorpU.Entitiy.Models.Dto.Applicant;

namespace CorpU.Data.Repository
{
    internal class EmployeeRoleRepository : IEmployeeRoleRepository<EmployeeRoleDto>
    {
        private readonly DataContext context;
        private readonly DbSet<EmployeeRoleEntity> table;
        private readonly IMapper _mapper;
        public EmployeeRoleRepository(DataContext context, IMapper mapper)
        {
            this.context = context;
            table = context.Set<EmployeeRoleEntity>();
            _mapper = mapper;
        }
        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<EmployeeRoleDto>> GetAllAsync()
        {
            try
            {
                var employeeRoleList = await table
                   .ToListAsync();

                return _mapper.Map<IEnumerable<EmployeeRoleDto>>(employeeRoleList);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<EmployeeRoleDto> GetByIdAsync(int id)
        {
            try
            {
                var employeeRole = await table
                    .Where(e => e.emp_role_id == id)
                    .FirstOrDefaultAsync();

                return _mapper.Map<EmployeeRoleEntity, EmployeeRoleDto>(employeeRole);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Task<int> Insert(EmployeeRoleDto entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(EmployeeRoleDto entity)
        {
            throw new NotImplementedException();
        }

    }
}
