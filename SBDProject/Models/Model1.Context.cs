﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SBDProject.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Appointment> Appointment { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Coach> Coach { get; set; }
        public virtual DbSet<Game_time> Game_time { get; set; }
        public virtual DbSet<Ligue> Ligue { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<Player> Player { get; set; }
        public virtual DbSet<Position> Position { get; set; }
        public virtual DbSet<Referee> Referee { get; set; }
        public virtual DbSet<RefereeSqad> RefereeSqad { get; set; }
        public virtual DbSet<RefereeType> RefereeType { get; set; }
        public virtual DbSet<Squad> Squad { get; set; }
        public virtual DbSet<Statistic> Statistic { get; set; }
        public virtual DbSet<Statistic_detail> Statistic_detail { get; set; }
        public virtual DbSet<Team> Team { get; set; }
    }
}
