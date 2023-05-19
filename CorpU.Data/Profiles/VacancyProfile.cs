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
            dest.vacancy_type_id,
            opt => opt.MapFrom(src => src.vacancy_type_id));

            CreateMap<VacancyEntity, VacancyDto>()
            .ForPath(dest =>
            dest.class_type_id,
            opt => opt.MapFrom(src => src.class_type_id));

            CreateMap<VacancyEntity, VacancyDto>()
            .ForPath(dest =>
            dest.emp_id,
            opt => opt.MapFrom(src => src.emp_id));

            CreateMap<VacancyEntity, VacancyDto>()
            .ForPath(dest =>
            dest.unit_id,
            opt => opt.MapFrom(src => src.unit_id));

            //Set
            CreateMap<VacancyDto, VacancyEntity>();

        }
    }
}
