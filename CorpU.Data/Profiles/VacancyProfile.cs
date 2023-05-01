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
            .ForMember(dest =>
            dest.vacancyType.vacancy_type_id,
            opt => opt.MapFrom(src => src.VacancyType.vacancy_type_id));

            CreateMap<VacancyEntity, VacancyDto>()
            .ForMember(dest =>
            dest.classType.class_type_id,
            opt => opt.MapFrom(src => src.ClassType.class_type_id));

            CreateMap<VacancyEntity, VacancyDto>()
            .ForMember(dest =>
            dest.employee.emp_id,
            opt => opt.MapFrom(src => src.Employee.emp_id));

            CreateMap<VacancyEntity, VacancyDto>()
            .ForMember(dest =>
            dest.unit.unit_id,
            opt => opt.MapFrom(src => src.Unit.unit_id));

            //Set
            CreateMap<VacancyDto, VacancyEntity>();

            CreateMap<VacancyDto, VacancyEntity>()
            .ForMember(dest =>
            dest.VacancyType.vacancy_type_id,
            opt => opt.MapFrom(src => src.vacancyType.vacancy_type_id));

            CreateMap<VacancyDto, VacancyEntity>()
            .ForMember(dest =>
            dest.ClassType.class_type_id,
            opt => opt.MapFrom(src => src.classType.class_type_id));

            CreateMap<VacancyDto, VacancyEntity>()
            .ForMember(dest =>
            dest.Employee.emp_id,
            opt => opt.MapFrom(src => src.employee.emp_id));

            CreateMap<VacancyDto, VacancyEntity>()
            .ForMember(dest =>
            dest.Unit.unit_id,
            opt => opt.MapFrom(src => src.unit.unit_id));

        }
    }
}
