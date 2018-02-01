using ReportingDataBase.DAL.MySQL;
using ReportingDataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using System.Web;
using ReportingDataBase.MapperSettings;
using System.Data.Entity;

namespace ReportingDataBase.DAL
{
    public class SkillRepository : GenericRepository<Skill>
    {
        public SkillRepository(DatabaseContext context) : base (context)
        {
           
        }

        public void copySkills()
        {
            PlatformContext db = new PlatformContext();
            List<PlatformSkill> PlatformSkills = db.PlatformSkills.ToList();
            List<Skill> Platform = AutoMapper.Mapper.Map<List<PlatformSkill>, List<Skill>>(PlatformSkills);
            List < Skill > Database = GetAll().ToList();

            var toAdd = Platform.Where(d => !Database.Any(p => p.SkillName == d.SkillName));
            
            context.Skills.AddRange(toAdd);
            context.SaveChanges();
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