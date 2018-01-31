using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReportingDataBase.Models
{
    public class Skill:IEntity
    {
        public int ID { get; set; }
        public string SkillName { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}