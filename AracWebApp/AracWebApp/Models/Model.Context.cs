﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AracWebApp.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AracEntities : DbContext
    {
        public AracEntities()
            : base("name=AracEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tblArac> tblArac { get; set; }
        public virtual DbSet<tblKiralama> tblKiralama { get; set; }
        public virtual DbSet<tblMarka> tblMarka { get; set; }
        public virtual DbSet<tblModel> tblModel { get; set; }
        public virtual DbSet<tblMusteri> tblMusteri { get; set; }
    }
}
