using AutoMapper;
using CorpU.Data.Models;
using CorpU.Entitiy.Models.Dto.Shortlist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpU.Data.Profiles
{
    public class ShortlistedApplicantProfile : Profile
    {
        public ShortlistedApplicantProfile()
        {
            //Get
            CreateMap<ShortlistedApplicantEntity, ShortlistDetailDto>();
            CreateMap<ShortlistedApplicantEntity, ShortlistDetailDto>()
            .ForPath(dest =>
           dest.application.Application_id,
           opt => opt.MapFrom(src => src.Application_id));
            CreateMap<ShortlistedApplicantEntity, ShortlistDetailDto>()
            .ForPath(dest =>
           dest.employee.emp_id,
           opt => opt.MapFrom(src => src.emp_id));
            //Set
            CreateMap<ShortlistDetailDto, ShortlistedApplicantEntity>();

        }
    }
}
