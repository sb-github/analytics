using ReportingDataBase.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ReportingDataBase.DAL
{
    public class DatabaseContext : DbContext
    {

        public DatabaseContext() : base("SQLEntities")
        {

        }

        public DbSet<Skill> Skills { get; set; }
        public DbSet<ReportingSkills> ReportingSkills { get; set; }
    }
}