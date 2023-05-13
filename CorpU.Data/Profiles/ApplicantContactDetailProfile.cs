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
    public class ApplicantContactDetailProfile : Profile
    {
        public ApplicantContactDetailProfile()
        {
            //Get
            CreateMap<ApplicantContactDetailEntity, ApplicantContactDetailDto>();
            CreateMap<ApplicantContactDetailEntity, ApplicantContactDetailDto>()
            .ForPath(dest =>
           dest.applicant.applicant_id,
           opt => opt.MapFrom(src => src.Applicant.applicant_id));


            //Set
            CreateMap<ApplicantContactDetailDto, ApplicantContactDetailEntity>();
            CreateMap<ApplicantContactDetailDto, ApplicantContactDetailEntity>()
            .ForPath(dest =>
           dest.Applicant.applicant_id,
           opt => opt.MapFrom(src => src.applicant.applicant_id));
        }
    }
}
