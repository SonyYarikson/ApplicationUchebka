﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ApplicationUchebka
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PavilionsEntities : DbContext
    {
        private static PavilionsEntities _context;
        public static PavilionsEntities GetContext()
        {
            if (_context == null)
                _context = new PavilionsEntities();
            return _context;
        }
        public PavilionsEntities()
            : base("name=PavilionsEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Cities> Cities { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<Malls> Malls { get; set; }
        public virtual DbSet<MallStatuses> MallStatuses { get; set; }
        public virtual DbSet<Pavilions> Pavilions { get; set; }
        public virtual DbSet<PavilionsLease> PavilionsLease { get; set; }
        public virtual DbSet<PavilionStatuses> PavilionStatuses { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Tenants> Tenants { get; set; }
        public virtual DbSet<MallsListView> MallsListView { get; set; }
    }
}