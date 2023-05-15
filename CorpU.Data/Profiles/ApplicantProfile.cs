using AutoMapper;
using CorpU.Data.Models;
using CorpU.Entitiy.Models.Dto.Applicant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpU.Data.Profiles
{
    public class ApplicantProfile : Profile
    {
        public ApplicantProfile()
        {
            //Get
            CreateMap<ApplicantEntity, ApplicantDto>();
            CreateMap<ApplicantEntity, ApplicantDto>()
              .ForPath(dest =>
             dest.user.user_id,
             opt => opt.MapFrom(src => src.user_id));

            //Set
            CreateMap<ApplicantDto, ApplicantEntity>();
     
        }
    }
}
