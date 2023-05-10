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

        public async Task<IEnumerable<EmployeeDto>> GetAllAsync()
        {
            try
            {
                var EmployeeList = await table
                   .Include(r => r.EmployeeRole)
                   .Include(u => u.User)
                   .Include(f => f.Faculty)
                    .ToListAsync();

                return _mapper.Map<IEnumerable<EmployeeDto>>(EmployeeList);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<EmployeeDto> GetByEmailAsync(string Email)
        {
            try
            {
                var Employee = await table
                    .Where(e => e.email == Email)
                    .Include(r => r.EmployeeRole)
                    .Include(u => u.User)
                    .Include(f => f.Faculty)
                  .FirstOrDefaultAsync();

                return _mapper.Map<EmployeeDto>(Employee);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<EmployeeDto> GetByIdAsync(int id)
        {
            try
            {
                var Employee = await table
                    .Where(e => e.emp_id == id)
                    .Include(r => r.EmployeeRole)
                    .Include(u => u.User)
                    .Include(f => f.Faculty)
                    .FirstOrDefaultAsync();

                return _mapper.Map<EmployeeEntity, EmployeeDto>(Employee);
            }
            catch (Exception ex)
            {
                return null;
            }
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
        public async Task<int> Update(EmployeeDto entity)
        {
            try
            {
                EmployeeEntity? Employee = await table.Where(c => c.emp_id == entity.emp_id).FirstOrDefaultAsync();

                if (Employee != null)
                {
                    Employee.emp_name = entity.emp_name;
                    Employee.phone = entity.phone;
                    Employee.faculty_id = entity.faculty_id;
                    Employee.emp_role_id = entity.emp_role_id;
                    Employee.status = entity.status;

                    int excecutedRows = await this.context.SaveChangesAsync();

                    return excecutedRows;
                }
            }
            catch (Exception ex)
            {

            }
            return 0;
        }
        public async Task<int> Delete(int id)
        {
            try
            {
                EmployeeEntity? User = await table.Where(c => c.emp_id == id).FirstOrDefaultAsync();

                if (User != null)
                {
                    this.context.Remove(User);
                    int excecutedRows = await context.SaveChangesAsync();
                    return excecutedRows;
                }
            }
            catch (Exception ex)
            {

            }
            return 0;
        }
    }
}
