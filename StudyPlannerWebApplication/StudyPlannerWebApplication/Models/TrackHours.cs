using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyPlannerWebApplication.Models
{
    public class TrackHours
    {
        public string moduleCode { get; set; }
        public int studiedHours { get; set; }
        public DateTime studiedDate { get; set; }
    }
}
