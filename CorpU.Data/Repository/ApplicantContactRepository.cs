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
    internal class ApplicantContactRepository : IApplicantContactRepository<ApplicantContactDetailDto>
    {
        private readonly DataContext context;
        private readonly DbSet<ApplicantContactDetailEntity> table;
        private readonly IMapper _mapper;

        public ApplicantContactRepository(DataContext context, IMapper mapper)
        {
            this.context = context;
            table = context.Set<ApplicantContactDetailEntity>();
            _mapper = mapper;
        }

        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ApplicantContactDetailDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ApplicantContactDetailDto> GetByIdAsync(int id)
        {
            try
            {
                var applicantContact = await table
                    .Where(e => e.Applicant.applicant_id == id)
                    .Include(u => u.Applicant)
                    .FirstOrDefaultAsync();

                return _mapper.Map<ApplicantContactDetailEntity, ApplicantContactDetailDto>(applicantContact);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<int> Insert(ApplicantContactDetailDto entity)
        {
            try
            {
                ApplicantContactDetailEntity aplicantContactEntity;
                aplicantContactEntity = _mapper.Map<ApplicantContactDetailDto, ApplicantContactDetailEntity>(entity);

                this.context.Set<ApplicantContactDetailEntity>().Add(aplicantContactEntity);
                int excecutedRows = await this.context.SaveChangesAsync();

                entity.app_contact_id = aplicantContactEntity.app_contact_id;
                return excecutedRows;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public async Task<int> Update(ApplicantContactDetailDto entity)
        {
            try
            {
                ApplicantContactDetailEntity? ApplicantContact = await table
                    .Where(c => c.app_contact_id == entity.app_contact_id)
                    .Where(c => c.applicant_id == entity.applicant_id)
                    .FirstOrDefaultAsync();

                if (ApplicantContact != null)
                {
                    //ApplicantContact.app_contact_id=entity.app_contact_id;
                    //ApplicantContact.applicant_id=entity.applicant_id;
                    ApplicantContact.phone= entity.phone;
                    ApplicantContact.address_line1 = entity.address_line1;
                    ApplicantContact.address_line2 = entity.address_line2;
                    ApplicantContact.postcode = entity.postcode;
                    ApplicantContact.state = entity.state;
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
