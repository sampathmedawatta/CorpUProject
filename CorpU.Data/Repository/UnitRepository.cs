using AutoMapper;
using CorpU.Data.Models;
using CorpU.Data.Repository.Interfaces;
using CorpU.Entitiy.Models.Dto.Unit;
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
    internal class UnitRepository : IUnitRepository<UnitDto>
    {
        private readonly DataContext context;
        private readonly DbSet<UnitEntity> table;
        private readonly IMapper _mapper;
        public UnitRepository(DataContext context, IMapper mapper)
        {
            this.context = context;
            table = context.Set<UnitEntity>();
            _mapper = mapper;
        }
        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UnitDto>> GetAllAsync()
        {
            try
            {
                var UnitList = await table
                   .ToListAsync();

                return _mapper.Map<IEnumerable<UnitDto>>(UnitList);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<UnitDto> GetByIdAsync(int id)
        {
            try
            {
                var unit = await table
                    .Where(e => e.unit_id == id)
                    .FirstOrDefaultAsync();

                return _mapper.Map<UnitEntity, UnitDto>(unit);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Task<int> Insert(UnitDto entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(UnitDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
