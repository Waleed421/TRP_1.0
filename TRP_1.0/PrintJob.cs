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
    
    public partial class PrintJob
    {
        public int Id { get; set; }
        public string Printer_Name { get; set; }
        public string Document_Name { get; set; }
        public string Document_Pages { get; set; }
        public string Submitted_By { get; set; }
        public Nullable<System.DateTime> Submitted_At { get; set; }
        public string Username { get; set; }
        public Nullable<int> Customer_Id { get; set; }
    
        public virtual Customer Customer { get; set; }
    }
}
