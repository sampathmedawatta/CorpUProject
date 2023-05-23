using AutoMapper;
using CorpU.Data.Models;
using CorpU.Data.Repository.Interfaces;
using CorpU.Entitiy.Models.Dto.Shortlist;
using CorpU.Entitiy.Models.Dto.Unit;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CorpU.Data.Repository
{
    public class OfferRepository:IOfferRepository<OfferDetailDto>
    {
        private readonly DataContext context;
        private readonly DbSet<OfferDetailEntity> table;
        private readonly IMapper _mapper;
        public OfferRepository(DataContext context, IMapper mapper)
        {
            this.context = context;
            table = context.Set<OfferDetailEntity>();
            _mapper = mapper;
        }
        public async Task<OfferDetailDto> GetByIdAsync(int id)
        {
            try
            {
                var offer = await table
                    .Where(e => e.Application_id == id)
                    .FirstOrDefaultAsync();

                return _mapper.Map<OfferDetailEntity, OfferDetailDto>(offer);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<IEnumerable<OfferDetailDto>> GetAllAsync()
        {
            try
            {
                var offerList = await table
                   .Include(u => u.application)
                   .ToListAsync();

                return _mapper.Map<IEnumerable<OfferDetailDto>>(offerList);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<int> Insert(OfferDetailDto entity)
        {
            try
            {
                OfferDetailEntity offerEntity;
                offerEntity = _mapper.Map<OfferDetailDto, OfferDetailEntity>(entity);

                this.context.Set<OfferDetailEntity>().Add(offerEntity);
                int excecutedRows = await this.context.SaveChangesAsync();

                entity.offer_id = offerEntity.offer_id;
                return excecutedRows;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public Task<int> Update(OfferDetailDto entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
