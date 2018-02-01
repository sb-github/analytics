using ReportingDataBase.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ReportingDataBase.DAL.MySQL
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class PlatformContext : DbContext
    {

        public PlatformContext() : base("MySQLEntities")
        {

        }

        public DbSet<PlatformSkill> PlatformSkills { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlatformSkill>().ToTable("skills");

            modelBuilder.Entity<PlatformSkill>()
                .Property(t => t.Id)
                .HasColumnName("id");
        }
    }
}