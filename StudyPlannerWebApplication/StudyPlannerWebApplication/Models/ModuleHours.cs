using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyPlannerWebApplication.Models
{
    public class ModuleHours
    {
        public string moduleCode { get; set; }
        public int selfStudyHours { get; set; }
        public int remainingHours { get; set; }

        public int calcRemaining(int studied)
        {
            return remainingHours - studied;

        }
    }
}
