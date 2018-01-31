using ReportingDataBase.DAL.MySQL;
using ReportingDataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using System.Web;
using ReportingDataBase.Mapper;
using System.Data.Entity;

namespace ReportingDataBase.DAL
{
    public class SkillRepository : GenericRepository<DatabaseContext, Skill>
    {
        public SkillRepository()
        {
            context = new DatabaseContext();
        }

        public void copySkills()
        {
            PlatformContext db = new PlatformContext();
            List<PlatformSkill> PlatformSkills = db.Skills.ToList();
            AutoMapper.Mapper.Initialize(cfg => cfg.AddProfile<MapProfile>());
            List<Skill> skills= AutoMapper.Mapper.Map<List<PlatformSkill>, List<Skill>>(PlatformSkills);

            for(int i=0;i<skills.Count;i++)
            {
                AddOrModify(skills[i]);
            }
        }

        public void AddOrModify(Skill entity) 
        {
            if (context.Set<Skill>().Any(e => e.SkillName != entity.SkillName))
            {
                context.Entry(entity).State = EntityState.Added;
            }

            context.SaveChanges();
        }
    }
}