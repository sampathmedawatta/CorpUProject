using AutoMapper;
using CorpU.Data.Models;
using CorpU.Data.Repository.Interfaces;
using CorpU.Entitiy.Models.Dto.Applicant;
using CorpU.Entitiy.Models.Dto.Shortlist;
using CorpU.Entitiy.Models.Dto.Employee;
using CorpU.Entitiy.Models.Dto.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CorpU.Data.Repository
{
    internal class ShortlistRepository : IShortlistRepository<ShortlistDetailDto>
    {
        private readonly DataContext context;
        private readonly DbSet<ShortlistedApplicantEntity> table;
        private readonly IMapper _mapper;

        public ShortlistRepository(DataContext context, IMapper mapper)
        {
            this.context = context;
            table = context.Set<ShortlistedApplicantEntity>();
            _mapper = mapper;
        }
        public async Task<ShortlistDetailDto> GetByIdAsync(int id)
        {
            try
            {
                var shortlist = await table
                    .Where(e => e.Application_id == id)
                    .Include(u => u.application)
                    .Include(c=>c.employee)
                    .FirstOrDefaultAsync();

                return _mapper.Map<ShortlistedApplicantEntity, ShortlistDetailDto>(shortlist);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<IEnumerable<ShortlistDetailDto>> GetAllAsync()
        {
            try
            {
                var shortlistedList = await table
                   .Include(u => u.application)
                   .Include(c => c.employee)
                   .ToListAsync();

                return _mapper.Map<IEnumerable<ShortlistDetailDto>>(shortlistedList);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<int> Insert(ShortlistDetailDto entity)
        {
            try
            {
                ShortlistedApplicantEntity shortlistEntity;
                shortlistEntity = _mapper.Map<ShortlistDetailDto, ShortlistedApplicantEntity>(entity);

                this.context.Set<ShortlistedApplicantEntity>().Add(shortlistEntity);
                int excecutedRows = await this.context.SaveChangesAsync();

                entity.shortlist_id = shortlistEntity.shortlist_id;
                return excecutedRows;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public async Task<int> Update(ShortlistDetailDto entity)
        {
            try
            {
                ShortlistedApplicantEntity? Shortlist = await table
                    .Where(c => c.shortlist_id == entity.shortlist_id)
                    .Where(d => d.Application_id == entity.Application_id)
                    .FirstOrDefaultAsync();

                if (Shortlist != null)
                {
                    //Shortlist.Application_id = entity.Application_id;
                    Shortlist.emp_id = entity.emp_id;
                    Shortlist.interview_date = entity.interview_date;
                    Shortlist.status= entity.status;
                    Shortlist.comments = entity.comments;

                    int excecutedRows = await this.context.SaveChangesAsync();

                    return excecutedRows;
                }
            }
            catch (Exception ex)
            {

            }
            return 0;
        }

        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
