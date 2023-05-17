using AutoMapper;
using CorpU.Data.Models;
using CorpU.Data.Repository.Interfaces;
using CorpU.Entitiy.Models.Dto.Applicant;
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
    internal class ApplicantAvailabilityRepository : IApplicantAvailabilityRepository<ApplicantAvailabilityDto>
    {
        private readonly DataContext context;
        private readonly DbSet<ApplicantAvailabilityEntity> table;
        private readonly IMapper _mapper;

        public ApplicantAvailabilityRepository(DataContext context, IMapper mapper)
        {
            this.context = context;
            table = context.Set<ApplicantAvailabilityEntity>();
            _mapper = mapper;
        }

        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ApplicantAvailabilityDto>> GetAllAsync()
        {
            try
            {
                var applicantAvailabilityList = await table
                   .Include(u => u.Applicant)
                   .ToListAsync();

                return _mapper.Map<IEnumerable<ApplicantAvailabilityDto>>(applicantAvailabilityList);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<ApplicantAvailabilityDto> GetByIdAsync(int id)
        {
            try
            {
                var applicantAvailability = await table
                    .Where(e => e.Applicant.applicant_id == id)
                    .Include(u => u.Applicant)
                    .FirstOrDefaultAsync();

                return _mapper.Map<ApplicantAvailabilityEntity, ApplicantAvailabilityDto>(applicantAvailability);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<int> Insert(ApplicantAvailabilityDto entity)
        {
            try
            {
                ApplicantAvailabilityEntity applicantAvailabilityEntity;
                applicantAvailabilityEntity = _mapper.Map<ApplicantAvailabilityDto, ApplicantAvailabilityEntity>(entity);

                this.context.Set<ApplicantAvailabilityEntity>().Add(applicantAvailabilityEntity);
                int excecutedRows = await this.context.SaveChangesAsync();

                entity.app_availability_id = applicantAvailabilityEntity.app_availability_id;
                return excecutedRows;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public async Task<int> Update(ApplicantAvailabilityDto entity)
        {
            try
            {
                ApplicantAvailabilityEntity? ApplicantAvailability = await table
                    .Where(c => c.app_availability_id == entity.app_availability_id)
                    .Where(c => c.applicant_id == entity.applicant_id)
                    .FirstOrDefaultAsync();

                if (ApplicantAvailability != null)
                {
                    ApplicantAvailability.start_date = entity.start_date;
                    ApplicantAvailability.end_date = entity.end_date;
                    int excecutedRows = await this.context.SaveChangesAsync();

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
