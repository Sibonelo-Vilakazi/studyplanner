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
    
    public partial class Track_Module
    {
        public int track_id { get; set; }
        public int module_id { get; set; }
        public System.DateTime track_date { get; set; }
        public int track_study_hour { get; set; }
    
        public virtual Module Module { get; set; }
    }
}