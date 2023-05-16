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
    internal class VacancyTypeRepository : IVacancyTypeRepository<VacancyTypeDto>
    {
        private readonly DataContext context;
        private readonly DbSet<VacancyTypeEntity> table;
        private readonly IMapper _mapper;
        public VacancyTypeRepository(DataContext context, IMapper mapper)
        {
            this.context = context;
            table = context.Set<VacancyTypeEntity>();
            _mapper = mapper;
        }
        public async Task<VacancyTypeDto> GetByIdAsync(int id)
        {
            try
            {
                var vacancyType = await table
                    .Where(e => e.vacancy_type_id == id)
                    .FirstOrDefaultAsync();

                return _mapper.Map<VacancyTypeEntity, VacancyTypeDto>(vacancyType);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<IEnumerable<VacancyTypeDto>> GetAllAsync()
        {
            try
            {
                var vacancyTypeList = await table
                   .ToListAsync();

                return _mapper.Map<IEnumerable<VacancyTypeDto>>(vacancyTypeList);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Task<int> Insert(VacancyTypeDto entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(VacancyTypeDto entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
