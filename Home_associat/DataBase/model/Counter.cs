//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Home_associat.DataBase.model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Counter
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Counter()
        {
            this.List_of_services = new HashSet<List_of_services>();
        }
    
        public int id_counter { get; set; }
        public System.DateTime date_check { get; set; }
        public System.DateTime installation_date { get; set; }
        public Nullable<bool> is_zip { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<List_of_services> List_of_services { get; set; }
    }
}
