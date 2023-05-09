using AutoMapper;
using CorpU.Data.Models;
using CorpU.Data.Repository.Interfaces;
using CorpU.Entitiy.Models.Dto.Employee;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpU.Data.Repository
{
    public class EmployeeRepository : IEmployeeRepository<EmployeeDto>
    {
        private readonly DataContext context;
        private readonly DbSet<EmployeeEntity> table;
        private readonly IMapper _mapper;
        public EmployeeRepository(DataContext context, IMapper mapper)
        {
            this.context = context;
            table = context.Set<EmployeeEntity>();
            _mapper = mapper;
        }

        public Task<IEnumerable<EmployeeDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<EmployeeDto> GetByEmailAsync(string Email)
        {
            throw new NotImplementedException();
        }

        public Task<EmployeeDto> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Insert(EmployeeDto entity)
        {
            try
            {
                EmployeeEntity employeeEntity;
                employeeEntity = _mapper.Map<EmployeeDto, EmployeeEntity>(entity);

                this.context.Set<EmployeeEntity>().Add(employeeEntity);
                int excecutedRows = await this.context.SaveChangesAsync();

                entity.emp_id = employeeEntity.emp_id;
                return excecutedRows;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public Task<int> Update(EmployeeDto entity)
        {
            throw new NotImplementedException();
        }
        public  Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
