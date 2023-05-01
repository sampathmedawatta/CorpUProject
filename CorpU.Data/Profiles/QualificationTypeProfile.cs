using AutoMapper;
using CorpU.Data.Models;
using CorpU.Entitiy.Models.Dto.Referance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpU.Data.Profiles
{
    public class QualificationTypeProfile : Profile
    {
        public QualificationTypeProfile()
        {
            //Get
            CreateMap<QualificationTypeEntity, QualificationTypeDto>();

            //Set
            CreateMap<QualificationTypeDto, QualificationTypeEntity>();

        }
    }
}
