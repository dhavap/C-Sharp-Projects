﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
//C:\Users\Student\Desktop\C-Sharp Coding Projects\CarInsuranceMvc\CarInsuranceMvc\Models\
namespace CarInsuranceMvc.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CarInsurance_CustomersEntities : DbContext
    {
        public CarInsurance_CustomersEntities()
            : base("name=CarInsurance_CustomersEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CarInsurance_Customers> CarInsurance_Customers { get; set; }
    }
}
