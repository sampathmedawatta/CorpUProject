using AutoMapper;
using CorpU.Data.Models;
using CorpU.Data.Repository.Interfaces;
using CorpU.Entitiy.Models.Dto.Applicant;
using CorpU.Entitiy.Models.Dto.Application;
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
    internal class ApplicationRepository : IApplicationRepository<ApplicationDto>
    {
        private readonly DataContext context;
        private readonly DbSet<ApplicationEntity> table;
        private readonly IMapper _mapper;

        public ApplicationRepository(DataContext context, IMapper mapper)
        {
            this.context = context;
            table = context.Set<ApplicationEntity>();
            _mapper = mapper;
        }

        public async Task<IEnumerable<ApplicationDto>> GetAllAsync()
        {
            try
            {
                var applicationList = await table
                   .Include(u => u.Applicant)
                   .ToListAsync();

                return _mapper.Map<IEnumerable<ApplicationDto>>(applicationList);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<int> Insert(ApplicationDto entity)
        {
            try
            {
                ApplicationEntity applicationEntity;
                applicationEntity = _mapper.Map<ApplicationDto, ApplicationEntity>(entity);

                this.context.Set<ApplicationEntity>().Add(applicationEntity);
                int excecutedRows = await this.context.SaveChangesAsync();

                entity.Application_id = applicationEntity.Application_id;
                return excecutedRows;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationDto> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Update(ApplicationDto entity)
        {
            try
            {
                ApplicationEntity? Application = await table
                    .Where(c => c.Application_id == entity.Application_id)
                    .Where(e => e.applicant_id == entity.applicant_id)
                    .FirstOrDefaultAsync();

                if (Application != null)
                {
                    Application.resume_url = entity.resume_url;
                    Application.status = entity.status;
                    int excecutedRows = await this.context.SaveChangesAsync();

                    return excecutedRows;
                }
            }
            catch (Exception ex)
            {

            }
            return 0;
        }

        public async Task<ApplicationDto> GetByApplicantIdAsync(int id)
        {
            try
            {
                var application = await table
                    .Where(e => e.applicant_id == id)
                    .Include(u => u.Applicant)
                    .FirstOrDefaultAsync();

                return _mapper.Map<ApplicationEntity, ApplicationDto>(application);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<ApplicationDto> GetByApplicationIdAsync(int id)
        {
            try
            {
                var application = await table
                    .Where(e => e.Application_id == id)
                    .Include(u => u.Applicant)
                    .FirstOrDefaultAsync();

                return _mapper.Map<ApplicationEntity, ApplicationDto>(application);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
