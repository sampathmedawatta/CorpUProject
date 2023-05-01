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
    public class UnitProfile : Profile
    {
        public UnitProfile()
        {
            //Get
            CreateMap<UnitEntity, UnitDto>();

            //Set
            CreateMap<UnitDto, UnitEntity>();

        }
    }
}
