using AutoMapper;
using CorpU.Data.Models;
using CorpU.Entitiy.Models.Dto.Aplicant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpU.Data.Profiles
{
    public class AplicantProfile : Profile
    {
        public AplicantProfile()
        {
            //Get
            CreateMap<AplicantEntity, AplicantDto>();
            CreateMap<AplicantEntity, AplicantDto>()
              .ForMember(dest =>
             dest.user_id,
             opt => opt.MapFrom(src => src.user_id));

            //Set
            CreateMap<AplicantDto, AplicantEntity>();
            CreateMap<AplicantDto, AplicantEntity>()
              .ForMember(dest =>
             dest.user_id,
             opt => opt.MapFrom(src => src.user_id));
        }
    }
}
