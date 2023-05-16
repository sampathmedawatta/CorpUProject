using AutoMapper;
using CorpU.Data.Models;
using CorpU.Entitiy.Models.Dto.Unit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpU.Data.Profiles
{
    public class VacancyProfile : Profile
    {
        public VacancyProfile()
        {
            //Get
            CreateMap<VacancyEntity, VacancyDto>();

            CreateMap<VacancyEntity, VacancyDto>()
            .ForPath(dest =>
            dest.vacancyType.vacancy_type_id,
            opt => opt.MapFrom(src => src.VacancyType.vacancy_type_id));

            CreateMap<VacancyEntity, VacancyDto>()
            .ForPath(dest =>
            dest.classType.class_type_id,
            opt => opt.MapFrom(src => src.ClassType.class_type_id));

            CreateMap<VacancyEntity, VacancyDto>()
            .ForPath(dest =>
            dest.employee.emp_id,
            opt => opt.MapFrom(src => src.Employee.emp_id));

            CreateMap<VacancyEntity, VacancyDto>()
            .ForPath(dest =>
            dest.unit.unit_id,
            opt => opt.MapFrom(src => src.Unit.unit_id));

            //Set
            CreateMap<VacancyDto, VacancyEntity>();

        }
    }
}
