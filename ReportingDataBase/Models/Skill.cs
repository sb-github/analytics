using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ReportingDataBase.Models
{
    public class Skill : IEntity
    {
        [Key]
        public int Id { get; set; }

        public string SkillName { get; set; }
        [DataType(DataType.Date)]
        public DateTime? CreatedDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? UpdatedDate { get; set; }

        public ICollection<ReportingSkills> Reporings { get; set; }
    }
}