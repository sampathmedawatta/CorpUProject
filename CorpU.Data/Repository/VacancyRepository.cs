using AutoMapper;
using CorpU.Data.Models;
using CorpU.Data.Repository.Interfaces;
using CorpU.Entitiy.Models.Dto.Applicant;
using CorpU.Entitiy.Models.Dto.Employee;
using CorpU.Entitiy.Models.Dto.User;
using CorpU.Entitiy.Models.Dto.Referance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorpU.Entitiy.Models.Dto.Unit;

namespace CorpU.Data.Repository
{
    internal class VacancyRepository : IVacancyRepository<VacancyDto>
    {
        private readonly DataContext context;
        private readonly DbSet<VacancyEntity> table;
        private readonly IMapper _mapper;

        public VacancyRepository(DataContext context, IMapper mapper)
        {
            this.context = context;
            table = context.Set<VacancyEntity>();
            _mapper = mapper;
        }
        public async Task<VacancyDto> GetByIdAsync(int id)
        {
            try
            {
                var vacancy = await table
                    .Where(e => e.vacancy_id == id)
                    .Include(u => u.VacancyType)
                    .Include(c => c.ClassType)
                    .Include(d => d.Employee)
                    .Include(e => e.Unit)
                    .FirstOrDefaultAsync();

                return _mapper.Map<VacancyEntity, VacancyDto>(vacancy);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<IEnumerable<VacancyDto>> GetAllAsync()
        {
            try
            {
                var vacancyList = await table
                   .Include(u => u.VacancyType)
                   .Include(c => c.ClassType)
                   .Include(d => d.Employee)
                   .Include(e => e.Unit)
                   .ToListAsync();

                return _mapper.Map<IEnumerable<VacancyDto>>(vacancyList);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<int> Insert(VacancyDto entity)
        {
            try
            {
                VacancyEntity vacancyEntity;
                vacancyEntity = _mapper.Map<VacancyDto, VacancyEntity>(entity);

                this.context.Set<VacancyEntity>().Add(vacancyEntity);
                int excecutedRows = await this.context.SaveChangesAsync();

                entity.vacancy_id = vacancyEntity.vacancy_id;
                return excecutedRows;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public Task<int> Update(VacancyDto entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
