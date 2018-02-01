using ReportingDataBase.Models;
using ReportingDataBase.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReportingDataBase.DAL
{
    public class ReportingSkillRepository : GenericRepository<DatabaseContext, ReportingSkills>
    {
        public ReportingSkillRepository()
        {
            context = new DatabaseContext();
        }

        public void FormReporting(DateTime date, int id)
        {
            Skill skill = context.Skills.Find(id);
            string QueryData = "skill=" + skill.SkillName + "&subskill=no";
            int count = int.Parse(GetQueries.GET("http://192.168.128.245:8081/extractor/rest/v1/",QueryData, "quantity"));

            ReportingSkills toAdd = new ReportingSkills { SkillID = id, Count = count, ReportingDate = date, CreatedDate=DateTime.Now};
            Add(toAdd);
            Save();
        }
    }
}