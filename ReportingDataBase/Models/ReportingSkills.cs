using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ReportingDataBase.Models
{
    public class ReportingSkills:IEntity
    {
        [Key]
        public int Id { get; set; }


        public DateTime? ReportingDate { get; set; }
        public int SkillID { get; set; }
        public int Count { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public Skill CurrentSkill { get; set; }
    }
}