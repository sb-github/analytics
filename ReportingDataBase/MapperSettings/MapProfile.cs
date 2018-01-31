using AutoMapper;
using ReportingDataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReportingDataBase.Mapper
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<PlatformSkill, Skill>()
                .ForMember(dest => dest.SkillName, map => map.MapFrom(source => source.title))
                .ForMember(dest => dest.CreatedDate, map => map.MapFrom(source => DateTime.Now));
        }
    }
}