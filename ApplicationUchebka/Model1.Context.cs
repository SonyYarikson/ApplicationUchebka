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
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
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
        public virtual DbSet<log> log { get; set; }
        public virtual DbSet<Malls> Malls { get; set; }
        public virtual DbSet<MallStatuses> MallStatuses { get; set; }
        public virtual DbSet<Pavilions> Pavilions { get; set; }
        public virtual DbSet<PavilionsLease> PavilionsLease { get; set; }
        public virtual DbSet<PavilionStatuses> PavilionStatuses { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Tenants> Tenants { get; set; }
        public virtual DbSet<MallsListView> MallsListView { get; set; }
        public virtual DbSet<PavilionsInMalls> PavilionsInMalls { get; set; }
        public virtual DbSet<EmployeesDataGrid> EmployeesDataGrid { get; set; }
    
        public virtual int RentPavilion(Nullable<int> pavilionId, Nullable<System.DateTime> leaseStart, Nullable<System.DateTime> leaseEnd, Nullable<int> tenantId, Nullable<int> empId)
        {
            var pavilionIdParameter = pavilionId.HasValue ?
                new ObjectParameter("PavilionId", pavilionId) :
                new ObjectParameter("PavilionId", typeof(int));
    
            var leaseStartParameter = leaseStart.HasValue ?
                new ObjectParameter("LeaseStart", leaseStart) :
                new ObjectParameter("LeaseStart", typeof(System.DateTime));
    
            var leaseEndParameter = leaseEnd.HasValue ?
                new ObjectParameter("LeaseEnd", leaseEnd) :
                new ObjectParameter("LeaseEnd", typeof(System.DateTime));
    
            var tenantIdParameter = tenantId.HasValue ?
                new ObjectParameter("TenantId", tenantId) :
                new ObjectParameter("TenantId", typeof(int));
    
            var empIdParameter = empId.HasValue ?
                new ObjectParameter("EmpId", empId) :
                new ObjectParameter("EmpId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("RentPavilion", pavilionIdParameter, leaseStartParameter, leaseEndParameter, tenantIdParameter, empIdParameter);
        }
    
        public virtual int RescheduleLease()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("RescheduleLease");
        }
    
        public virtual int CalculateROI(string tCName, string city, Nullable<decimal> pt, Nullable<decimal> pa)
        {
            var tCNameParameter = tCName != null ?
                new ObjectParameter("TCName", tCName) :
                new ObjectParameter("TCName", typeof(string));
    
            var cityParameter = city != null ?
                new ObjectParameter("City", city) :
                new ObjectParameter("City", typeof(string));
    
            var ptParameter = pt.HasValue ?
                new ObjectParameter("Pt", pt) :
                new ObjectParameter("Pt", typeof(decimal));
    
            var paParameter = pa.HasValue ?
                new ObjectParameter("Pa", pa) :
                new ObjectParameter("Pa", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CalculateROI", tCNameParameter, cityParameter, ptParameter, paParameter);
        }
    }
}
