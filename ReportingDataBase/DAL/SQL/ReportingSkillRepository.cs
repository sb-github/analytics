using ReportingDataBase.Models;
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
    }
}