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
    
    public partial class Apartment_number
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Apartment_number()
        {
            this.Flat = new HashSet<Flat>();
        }
    
        public int id_apartment_number { get; set; }
        public string apartment_number1 { get; set; }
        public Nullable<bool> is_zip { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Flat> Flat { get; set; }
    }
}
