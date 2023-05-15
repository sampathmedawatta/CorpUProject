using AutoMapper;
using CorpU.Common;
using CorpU.Data.Repository.Interfaces;
using CorpU.Entitiy.Models.Dto.Applicant;
using CorpU.Entitiy.Models.Dto.Employee;
using CorpU.Entitiy.Models.Dto.User;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpU.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly string ConnectionString;
        private DataContext Context
        {
            get
            {
                return new DataContext(ConnectionString);
            }
        }
        public IApplicantQualificationRepository<ApplicantQualificationDto> ApplicantQualification { get; private set; }
        public IApplicantContactRepository<ApplicantContactDetailDto> ApplicantContact {  get; private set; }
        public IApplicantRepository<ApplicantDto> Applicants { get; private set; }
        public IEmployeeRepository<EmployeeDto> Employees { get; private set; }
        public IUserRepository<UserDto> Users { get; private set; }
        public UnitOfWork(IOptions<AppSettings> appSetting, IMapper mapper)
        {

            ConnectionString = appSetting.Value.DBConnection;
            Applicants = new ApplicantRepository(Context, mapper);
            ApplicantContact= new ApplicantContactRepository(Context, mapper);
            ApplicantQualification = new ApplicantQualificationRepository(Context, mapper);
            Employees = new EmployeeRepository(Context, mapper);
            Users = new UserRepository(Context, mapper);
        }

        public int Complete()
        {
            return Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
