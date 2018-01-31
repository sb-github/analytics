using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReportingDataBase.Models
{
    public class ReportingSkills:IEntity
    {
        public int ID { get; set; }
        public DateTime? ReportingDate { get; set; }
        public int SkillID { get; set; }
        public int Count { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}