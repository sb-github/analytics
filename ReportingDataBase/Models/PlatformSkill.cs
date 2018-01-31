using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReportingDataBase.Models
{
    public class PlatformSkill:IEntity
    {
        public int ID { get; set; }
        public string title { get; set; }
        public string image { get; set; }
        public int? difficulty { get; set; }
        public string description { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
    }
}