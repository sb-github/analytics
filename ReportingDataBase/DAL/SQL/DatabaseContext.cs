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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
         {
             modelBuilder.Entity<ReportingSkills>().HasKey<int>(s => s.ID)
                 .Property(p => p.ID).IsRequired();
             modelBuilder.Entity<ReportingSkills>()
                 .HasRequired<Skill>(s => s.CurrentSkill)
                 .WithMany(d => d.Reporings)
                 .HasForeignKey<int>(s => s.SkillID); 
         }
}
}