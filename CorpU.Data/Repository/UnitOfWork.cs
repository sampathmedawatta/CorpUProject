using AutoMapper;
using CorpU.Common;
using CorpU.Data.Repository.Interfaces;
using CorpU.Entitiy.Models.Dto.Applicant;
using CorpU.Entitiy.Models.Dto.Application;
using CorpU.Entitiy.Models.Dto.Employee;
using CorpU.Entitiy.Models.Dto.Referance;
using CorpU.Entitiy.Models.Dto.Shortlist;
using CorpU.Entitiy.Models.Dto.Unit;
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
        public IShortlistRepository<ShortlistDetailDto> Shortlist { get;private set; }
        public IApplicationRepository<ApplicationDto> Application {  get;private set; }
        public IClassTypeRepository<ClassTypeDto> ClassType { get;private set; }
        public IUnitRepository<UnitDto> Unit { get; private set; }
        public IApplicantAvailabilityRepository<ApplicantAvailabilityDto> ApplicantAvailability { get; private set; }
        public IVacancyTypeRepository<VacancyTypeDto> VacancyType { get; private set; }
        public IVacancyRepository<VacancyDto> Vacancy { get; private set; }
        public IQualificationRepository<QualificationTypeDto> Qualifications { get;private set; }
        public IApplicantQualificationRepository<ApplicantQualificationDto> ApplicantQualification { get; private set; }
        public IApplicantContactRepository<ApplicantContactDetailDto> ApplicantContact {  get; private set; }
        public IApplicantRepository<ApplicantDto> Applicants { get; private set; }
        public IEmployeeRepository<EmployeeDto> Employees { get; private set; }
        public IUserRepository<UserDto> Users { get; private set; }
        public UnitOfWork(IOptions<AppSettings> appSetting, IMapper mapper)
        {
            ConnectionString = appSetting.Value.DBConnection;
            Shortlist = new ShortlistRepository(Context, mapper);
            Qualifications = new QualificationRepository(Context, mapper);
            Unit=new UnitRepository(Context, mapper);
            ClassType=new ClassTypeRepository(Context, mapper);
            Applicants = new ApplicantRepository(Context, mapper);
            Vacancy=new VacancyRepository(Context, mapper);
            VacancyType=new VacancyTypeRepository(Context, mapper);
            ApplicantContact= new ApplicantContactRepository(Context, mapper);
            ApplicantQualification = new ApplicantQualificationRepository(Context, mapper);
            ApplicantAvailability = new ApplicantAvailabilityRepository(Context, mapper);
            Application=new ApplicationRepository(Context, mapper);
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
