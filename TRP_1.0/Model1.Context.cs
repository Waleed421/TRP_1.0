﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PrintJobDbEntities : DbContext
    {
        public PrintJobDbEntities()
            : base("name=PrintJobDbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Case> Cases { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<PrintJob> PrintJobs { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TimeRegistration> TimeRegistrations { get; set; }
        public virtual DbSet<TypeofCas> TypeofCases { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}
