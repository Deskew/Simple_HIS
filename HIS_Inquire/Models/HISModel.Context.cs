﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HIS_Inquire.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Health_service_DBEntities : DbContext
    {
        public Health_service_DBEntities()
            : base("name=Health_service_DBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<医务人员信息表> 医务人员信息表 { get; set; }
        public virtual DbSet<医疗设备信息表> 医疗设备信息表 { get; set; }
        public virtual DbSet<药品信息表> 药品信息表 { get; set; }
        public virtual DbSet<诊疗方案信息表> 诊疗方案信息表 { get; set; }
    }
}