using AutoMapper;
using CorpU.Data.Models;
using CorpU.Data.Repository.Interfaces;
using CorpU.Entitiy.Models.Dto.Aplicant;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpU.Data.Repository
{
    internal class AplicantRepository : IAplicantRepository<ApplicantDto>
    {
        private readonly DataContext context;
        private readonly DbSet<ApplicantEntity> table;
        private readonly IMapper _mapper;

        public AplicantRepository(DataContext context, IMapper mapper)
        {
            this.context = context;
            table = context.Set<ApplicantEntity>();
            _mapper = mapper;
        }

        public async Task<IEnumerable<ApplicantDto>> GetAllAsync()
        {
            var AplicantList = await table
                .ToListAsync();
            return _mapper.Map<IEnumerable<ApplicantDto>>(AplicantList);
        }

        public async Task<IEnumerable<ApplicantDto>> GetAllByEmailAsync(string Email)
        {
            var AplicantList = await table.Where(e => e.email == Email)
               .ToListAsync();

            return _mapper.Map<IEnumerable<ApplicantDto>>(AplicantList);
        }

        public async Task<IEnumerable<ApplicantDto>> GetAllByNameAsync(string Name)
        {
            var AplicantList = await table.Where(e => e.name == Name)
               .ToListAsync();

            return _mapper.Map<IEnumerable<ApplicantDto>>(AplicantList);
        }

        public async Task<IEnumerable<ApplicantDto>> GetAllByStatusAsync(bool Status)
        {
            var AplicantList = await table.Where(e => e.status == Status)
               .ToListAsync();

            return _mapper.Map<IEnumerable<ApplicantDto>>(AplicantList);
        }

        public async Task<ApplicantDto> GetByIdAsync(int id)
        {
            var Aplicant = await table.Where(e => e.applicant_id == id)
              .ToListAsync();

            return _mapper.Map<ApplicantDto>(Aplicant);
        }

        public async Task<int> Insert(ApplicantDto entity)
        {
            ApplicantEntity aplicantEntity;
            aplicantEntity = _mapper.Map<ApplicantDto, ApplicantEntity>(entity);

            this.context.Set<ApplicantEntity>().Add(aplicantEntity);
            int excecutedRows = await this.context.SaveChangesAsync();

            entity.applicant_id = aplicantEntity.applicant_id;
            return excecutedRows;
        }

        public async Task<int> Update(ApplicantDto entity)
        {
            ApplicantEntity aplicant = await table.Where(c => c.applicant_id == entity.applicant_id).FirstOrDefaultAsync();

            if (aplicant != null)
            {
                int excecutedRows = await this.context.SaveChangesAsync();
                return excecutedRows;
            }
            else
            {
                return 0;
            }
        }

        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

    }
}
