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
    
    public partial class Pavilions
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pavilions()
        {
            this.PavilionsLease = new HashSet<PavilionsLease>();
        }
    
        public int PavilionId { get; set; }
        public string PavilionNumber { get; set; }
        public Nullable<int> MallId { get; set; }
        public Nullable<int> LevelNumber { get; set; }
        public Nullable<int> PavilionStatusId { get; set; }
        public Nullable<int> Area { get; set; }
        public Nullable<int> SquareMeterCost { get; set; }
        public Nullable<double> ValueAddedFactor { get; set; }
    
        public virtual Malls Malls { get; set; }
        public virtual PavilionStatuses PavilionStatuses { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PavilionsLease> PavilionsLease { get; set; }
    }
}
