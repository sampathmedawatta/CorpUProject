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
            dest.emp_role_id,
            opt => opt.MapFrom(src => src.emp_role_id));

            CreateMap<EmployeeEntity, EmployeeDto>()
            .ForPath(dest =>
            dest.user_id,
            opt => opt.MapFrom(src => src.user_id));

            CreateMap<EmployeeEntity, EmployeeDto>()
           .ForPath(dest =>
            dest.faculty_id,
            opt => opt.MapFrom(src => src.faculty_id));


            //Set
            CreateMap<EmployeeDto, EmployeeEntity>();

          
        }
    }
}
