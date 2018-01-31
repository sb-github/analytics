using ReportingDataBase.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ReportingDataBase.DAL.MySQL
{
    public class PlatformContext : DbContext
    {

        public PlatformContext() : base("MySQLEntities")
        {

        }

        public DbSet<PlatformSkill> Skills { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Skill>().ToTable("skills");

            modelBuilder.Entity<PlatformSkill>()
                .Property(t => t.ID)
                .HasColumnName("id");
        }
    }
}