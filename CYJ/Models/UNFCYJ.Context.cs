﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CYJ.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class cyjdatabaseEntities : DbContext
    {
        public cyjdatabaseEntities()
            : base("name=cyjdatabaseEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ABOUT> ABOUTs { get; set; }
        public virtual DbSet<CALENDAR> CALENDARs { get; set; }
        public virtual DbSet<CATEGORy> CATEGORIES { get; set; }
        public virtual DbSet<CHART> CHARTS { get; set; }
        public virtual DbSet<FISCALYEAR> FISCALYEARS { get; set; }
        public virtual DbSet<GOALACTUAL> GOALACTUALS { get; set; }
        public virtual DbSet<QUARTERLYUPDATE> QUARTERLYUPDATEs { get; set; }
        public virtual DbSet<QUARTEROPTION> QUARTEROPTIONS { get; set; }
        public virtual DbSet<SUBCATEGORy> SUBCATEGORIES { get; set; }
        public virtual DbSet<TEAM> TEAMS { get; set; }
        public virtual DbSet<WORKSTREAM> WORKSTREAMS { get; set; }
    }
}