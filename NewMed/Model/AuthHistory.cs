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
    
    public partial class AuthHistory
    {
        public int AuthHistoryId { get; set; }
        public Nullable<int> UserLogin { get; set; }
        public Nullable<System.TimeSpan> AuthTime { get; set; }
        public System.DateTime AuthDate { get; set; }
        public bool IsSuccessfull { get; set; }
    
        public virtual User User { get; set; }
    }
}
