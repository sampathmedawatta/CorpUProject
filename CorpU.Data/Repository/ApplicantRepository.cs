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
    internal class ApplicantRepository : IApplicantRepository<ApplicantDto>
    {
        private readonly DataContext context;
        private readonly DbSet<ApplicantEntity> table;
        private readonly IMapper _mapper;

        public ApplicantRepository(DataContext context, IMapper mapper)
        {
            this.context = context;
            table = context.Set<ApplicantEntity>();
            _mapper = mapper;
        }

        public async Task<ApplicantDto> GetByIdAsync(int id)
        {
            try
            {
                var applicant = await table
                    .Where(e => e.applicant_id == id)
                    .Include(u => u.User)
                    .FirstOrDefaultAsync();

                return _mapper.Map<ApplicantEntity, ApplicantDto>(applicant);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<ApplicantDto> GetByUserIdAsync(int id)
        {
            try
            {
                var applicant = await table
                    .Where(e => e.user_id == id)
                    .Include(u => u.User)
                    .FirstOrDefaultAsync();

                return _mapper.Map<ApplicantEntity, ApplicantDto>(applicant);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<IEnumerable<ApplicantDto>> GetAllAsync()
        {
            try
            { 
                var applicantList = await table
                   .Include(u => u.User)
                   .ToListAsync();

                return _mapper.Map<IEnumerable<ApplicantDto>>(applicantList);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<IEnumerable<ApplicantDto>> SearchApplicantAsync(string name)
        {
            try
            {
                var results = await table
                    .Where(e => e.name.Contains(name))
                    .ToListAsync();

                return _mapper.Map<IEnumerable<ApplicantDto>>(results);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<int> Insert(ApplicantDto entity)
        {
            try
            {
                ApplicantEntity aplicantEntity;
                aplicantEntity = _mapper.Map<ApplicantDto, ApplicantEntity>(entity);

                this.context.Set<ApplicantEntity>().Add(aplicantEntity);
                int excecutedRows = await this.context.SaveChangesAsync();

                entity.applicant_id = aplicantEntity.applicant_id;
                return excecutedRows;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public async Task<int> Update(ApplicantDto entity)
        {
            try
            {
                ApplicantEntity? Applicant = await table.Where(c => c.applicant_id == entity.applicant_id).FirstOrDefaultAsync();

                if (Applicant != null)
                {
                    Applicant.name = entity.name;
                    Applicant.email = entity.email;
                    //Applicant.user_id = entity.user_id;
                    Applicant.status = entity.status;
                    Applicant.resume_url = entity.resume_url;           

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

        //public async Task<IEnumerable<ApplicantDto>> GetAllByEmailAsync(string Email)
        //{
        //    var AplicantList = await table.Where(e => e.email == Email)
        //       .ToListAsync();

        //    return _mapper.Map<IEnumerable<ApplicantDto>>(AplicantList);
        //}

        //public async Task<IEnumerable<ApplicantDto>> GetAllByNameAsync(string Name)
        //{
        //    var AplicantList = await table.Where(e => e.name == Name)
        //       .ToListAsync();

        //    return _mapper.Map<IEnumerable<ApplicantDto>>(AplicantList);
        //}

        //public async Task<IEnumerable<ApplicantDto>> GetAllByStatusAsync(bool Status)
        //{
        //    var AplicantList = await table.Where(e => e.status == Status)
        //       .ToListAsync();

        //    return _mapper.Map<IEnumerable<ApplicantDto>>(AplicantList);
        //}

        //public async Task<int> Insert(ApplicantDto entity)
        //{
        //    ApplicantEntity aplicantEntity;
        //    aplicantEntity = _mapper.Map<ApplicantDto, ApplicantEntity>(entity);

        //    this.context.Set<ApplicantEntity>().Add(aplicantEntity);
        //    int excecutedRows = await this.context.SaveChangesAsync();

        //    entity.applicant_id = aplicantEntity.applicant_id;
        //    return excecutedRows;
        //}

        //public async Task<int> Update(ApplicantDto entity)
        //{
        //    ApplicantEntity aplicant = await table.Where(c => c.applicant_id == entity.applicant_id).FirstOrDefaultAsync();

        //    if (aplicant != null)
        //    {
        //        int excecutedRows = await this.context.SaveChangesAsync();
        //        return excecutedRows;
        //    }
        //    else
        //    {
        //        return 0;
        //    }
        //}

        //public Task<int> Delete(int id)
        //{
        //    throw new NotImplementedException();
        //}

    }
}
