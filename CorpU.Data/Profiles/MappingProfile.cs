using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpU.Data.Profiles
{
    public class MappingProfile
    {
        private readonly ApplicantProfile _ApplicantProfile;
        private readonly ApplicantAvailabilityProfile _ApplicantAvailabilityProfile;
        private readonly ApplicantClassPreferanceProfile _ApplicantClassPreferanceProfile;
        private readonly ApplicantQualificationProfile _ApplicantQualificationProfile;
        private readonly ApplicantContactDetailProfile _ApplicantContactDetailProfile;
        private readonly ApplicationProfile _ApplicationProfile;
        private readonly UserProfile _UserProfile;
        private readonly EmployeeProfile _EmployeeProfile;
        private readonly UnitProfile _UnitProfile;
        private readonly VacancyProfile _VacancyProfile;
        private readonly ClassTypeProfile _ClassTypeProfile;
        private readonly EmployeeRoleProfile _EmployeeRoleProfile;
        private readonly FacultyProfile _FacultyProfile;
        private readonly QualificationTypeProfile _QualificationTypeProfile;
        private readonly UserRoleProfile _UserRoleProfile;
        private readonly VacancyTypeProfile _VacancyTypeProfile;

        public MappingProfile()
        {
            _ApplicantProfile = new ApplicantProfile();
            _ApplicantAvailabilityProfile = new ApplicantAvailabilityProfile();
            _ApplicantClassPreferanceProfile = new ApplicantClassPreferanceProfile();
            _ApplicantContactDetailProfile = new ApplicantContactDetailProfile();
            _ApplicantQualificationProfile = new ApplicantQualificationProfile();
            _ApplicationProfile = new ApplicationProfile();
            _UserProfile = new UserProfile();
            _EmployeeProfile = new EmployeeProfile();
            _UnitProfile = new UnitProfile();
            _VacancyProfile = new VacancyProfile();

            _ClassTypeProfile = new ClassTypeProfile();
            _EmployeeRoleProfile = new EmployeeRoleProfile();
            _FacultyProfile = new FacultyProfile();
            _QualificationTypeProfile = new QualificationTypeProfile();
            _UserRoleProfile = new UserRoleProfile();
            _VacancyTypeProfile = new VacancyTypeProfile();
        }
    }
}
