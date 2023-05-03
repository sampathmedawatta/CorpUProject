using AutoMapper;
using CorpU.Data.Models;
using CorpU.Entitiy.Models.Dto.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpU.Data.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            //Get
            CreateMap<EmployeeEntity, EmployeeDto>();

            CreateMap<EmployeeEntity, EmployeeDto>()
            .ForPath(dest =>
            dest.employeeRole.emp_role_id,
            opt => opt.MapFrom(src => src.EmployeeRole.emp_role_id));

            CreateMap<EmployeeEntity, EmployeeDto>()
            .ForPath(dest =>
            dest.user.user_id,
            opt => opt.MapFrom(src => src.User.user_id));

            CreateMap<EmployeeEntity, EmployeeDto>()
           .ForPath(dest =>
            dest.faculty.faculty_id,
            opt => opt.MapFrom(src => src.Faculty.faculty_id));


            //Set
            CreateMap<EmployeeDto, EmployeeEntity>();

            CreateMap<EmployeeDto, EmployeeEntity>()
            .ForPath(dest =>
            dest.EmployeeRole.emp_role_id,
            opt => opt.MapFrom(src => src.employeeRole.emp_role_id));

            CreateMap<EmployeeDto, EmployeeEntity>()
            .ForPath(dest =>
            dest.User.user_id,
            opt => opt.MapFrom(src => src.user.user_id));

            CreateMap<EmployeeDto, EmployeeEntity>()
           .ForPath(dest =>
            dest.Faculty.faculty_id,
            opt => opt.MapFrom(src => src.faculty.faculty_id));
        }
    }
}
