//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class PavilionsLease
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PavilionsLease()
        {
            this.log = new HashSet<log>();
        }
    
        public int LeaseId { get; set; }
        public Nullable<int> TenantId { get; set; }
        public Nullable<int> MallId { get; set; }
        public Nullable<int> EmployeeId { get; set; }
        public Nullable<int> PavilionId { get; set; }
        public Nullable<System.DateTime> LeaseStart { get; set; }
        public Nullable<System.DateTime> C_LeaseEnd { get; set; }
    
        public virtual Employees Employees { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<log> log { get; set; }
        public virtual Malls Malls { get; set; }
        public virtual Pavilions Pavilions { get; set; }
        public virtual Tenants Tenants { get; set; }
    }
}
