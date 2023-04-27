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
    internal class AplicantRepository : IAplicantRepository<AplicantDto>
    {
        private readonly DataContext context;
        private readonly DbSet<AplicantEntity> table;
        private readonly IMapper _mapper;

        public AplicantRepository(DataContext context, IMapper mapper)
        {
            this.context = context;
            table = context.Set<AplicantEntity>();
            _mapper = mapper;
        }

        public async Task<IEnumerable<AplicantDto>> GetAllAsync()
        {
            var AplicantList = await table
                .ToListAsync();
            return _mapper.Map<IEnumerable<AplicantDto>>(AplicantList);
        }

        public async Task<IEnumerable<AplicantDto>> GetAllByEmailAsync(string Email)
        {
            var AplicantList = await table.Where(e => e.email == Email)
               .ToListAsync();

            return _mapper.Map<IEnumerable<AplicantDto>>(AplicantList);
        }

        public async Task<IEnumerable<AplicantDto>> GetAllByNameAsync(string Name)
        {
            var AplicantList = await table.Where(e => e.name == Name)
               .ToListAsync();

            return _mapper.Map<IEnumerable<AplicantDto>>(AplicantList);
        }

        public async Task<IEnumerable<AplicantDto>> GetAllByStatusAsync(bool Status)
        {
            var AplicantList = await table.Where(e => e.status == Status)
               .ToListAsync();

            return _mapper.Map<IEnumerable<AplicantDto>>(AplicantList);
        }

        public async Task<AplicantDto> GetByIdAsync(int id)
        {
            var Aplicant = await table.Where(e => e.aplicant_id == id)
              .ToListAsync();

            return _mapper.Map<AplicantDto>(Aplicant);
        }

        public async Task<int> Insert(AplicantDto entity)
        {
            AplicantEntity aplicantEntity;
            aplicantEntity = _mapper.Map<AplicantDto, AplicantEntity>(entity);

            this.context.Set<AplicantEntity>().Add(aplicantEntity);
            int excecutedRows = await this.context.SaveChangesAsync();

            entity.aplicant_id = aplicantEntity.aplicant_id;
            return excecutedRows;
        }

        public async Task<int> Update(AplicantDto entity)
        {
            AplicantEntity aplicant = await table.Where(c => c.aplicant_id == entity.aplicant_id).FirstOrDefaultAsync();

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

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

    }
}
