//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StudyPlannerWebApplication.DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class Module_Hours
    {
        public int module_hour_id { get; set; }
        public int module_id { get; set; }
        public int hours_remaining { get; set; }
        public System.DateTime week_start_date { get; set; }
        public System.DateTime week_end_date { get; set; }
        public int self_studying_hours { get; set; }
    
        public virtual Module Module { get; set; }
    }
}
