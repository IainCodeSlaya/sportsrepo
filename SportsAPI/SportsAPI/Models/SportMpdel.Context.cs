﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SportsAPI.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SportSafeEntities : DbContext
    {
        public SportSafeEntities()
            : base("name=SportSafeEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Sport> Sports { get; set; }
        public virtual DbSet<SportSeason> SportSeasons { get; set; }
        public virtual DbSet<SportSponsor> SportSponsors { get; set; }
        public virtual DbSet<TypeSport> TypeSports { get; set; }
    }
}
