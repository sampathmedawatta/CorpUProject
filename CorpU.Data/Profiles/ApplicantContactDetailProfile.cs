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
    public class ApplicantContactDetailProfile : Profile
    {
        public ApplicantContactDetailProfile()
        {
            //Get
            CreateMap<ApplicantContactDetailEntity, ApplicantContactDetailDto>();

            //Set
            CreateMap<ApplicantContactDetailDto, ApplicantContactDetailEntity>();
        }
    }
}
