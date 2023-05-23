using AutoMapper;
using CorpU.Data.Models;
using CorpU.Data.Repository.Interfaces;
using CorpU.Entitiy.Models.Dto.Referance;
using CorpU.Entitiy.Models.Dto.Employee;
using CorpU.Entitiy.Models.Dto.User;
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
    internal class FacultyRepository : IFacultyRepository<FacultyDto>
    {
        private readonly DataContext context;
        private readonly DbSet<FacultyEntity> table;
        private readonly IMapper _mapper;
        public FacultyRepository(DataContext context, IMapper mapper)
        {
            this.context = context;
            table = context.Set<FacultyEntity>();
            _mapper = mapper;
        }
        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<FacultyDto>> GetAllAsync()
        {
            try
            {
                var facultyList = await table
                   .ToListAsync();

                return _mapper.Map<IEnumerable<FacultyDto>>(facultyList);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<FacultyDto> GetByIdAsync(int id)
        {
            try
            {
                var faculty = await table
                    .Where(e => e.faculty_id == id)
                    .FirstOrDefaultAsync();

                return _mapper.Map<FacultyEntity, FacultyDto>(faculty);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Task<int> Insert(ClassTypeDto entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> Insert(FacultyDto entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(ClassTypeDto entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(FacultyDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
