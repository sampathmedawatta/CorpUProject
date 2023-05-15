﻿using AutoMapper;
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

        public Task<int> Insert(ApplicantContactDetailDto entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(ApplicantContactDetailDto entity)
        {
            throw new NotImplementedException();
        }
    }
}