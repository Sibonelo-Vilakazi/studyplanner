using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyPlannerWebApplication.Models
{
    public class Module
    {
        public string moduleCode { get; set; }
        public string moduleName { get; set; }
        public int numCredit { get; set; }
        public int numClassHour { get; set; }
        public int selftStudyHouurs { get; set; }
        
        public int calcSelfStudyHours(int numWeeks, int numHours)
        {
            return ((numCredit * 10) / numWeeks) - numHours;
        }
    }
}
