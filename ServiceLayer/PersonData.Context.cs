﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServiceLayer
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ReqprojectEntities : DbContext
    {
        public ReqprojectEntities()
            : base("name=ReqprojectEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Address_T> Address_T { get; set; }
        public virtual DbSet<Person_T> Person_T { get; set; }
        public virtual DbSet<Phone_T> Phone_T { get; set; }
    }
}
