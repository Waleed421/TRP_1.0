//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TRP_1._0
{
    using System;
    using System.Collections.Generic;
    
    public partial class TimeRegistration
    {
        public int Id { get; set; }
        public Nullable<int> Case_No { get; set; }
        public Nullable<System.DateTime> Start_Date_Time { get; set; }
        public Nullable<System.DateTime> Stop_Date_Time { get; set; }
        public string Action_Comment { get; set; }
        public string Invoice { get; set; }
        public string Time_In_Minutes { get; set; }
        public Nullable<int> User_Id { get; set; }
    
        public virtual Case Case { get; set; }
        public virtual User User { get; set; }
    }
}
