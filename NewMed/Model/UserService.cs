//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NewMed.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserService
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UserService()
        {
            this.BloodService = new HashSet<BloodService>();
        }
    
        public int UserServiceId { get; set; }
        public Nullable<int> UserId { get; set; }
        public int ServiceId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BloodService> BloodService { get; set; }
        public virtual Service Service { get; set; }
        public virtual User User { get; set; }
    }
}