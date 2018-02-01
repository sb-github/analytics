using ReportingDataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReportingDataBase.DAL.SQL
{
    public class UnityOfwork
    {
        private DatabaseContext context = new DatabaseContext();
        private GenericRepository<Skill> skillRepository;
        private GenericRepository<ReportingSkills> reportingSkillRepository;

        public GenericRepository<Skill> SkillRepository
        {
            get
            {
                return this.skillRepository ?? new GenericRepository<Skill>(context);
            }
        }
        public GenericRepository<ReportingSkills> ReportingSkillRepository
        {
            get
            {
                return this.reportingSkillRepository ?? new GenericRepository<ReportingSkills>(context);
            }
        }
  



        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}