//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcStok.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class TBLMUSTERILER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBLMUSTERILER()
        {
            this.TBLSATISLARs = new HashSet<TBLSATISLAR>();
        }
    
        public int ID { get; set; }

        [Required(ErrorMessage ="Bu Alan Bo� B�rak�lamaz.")]
        [StringLength(50 , ErrorMessage ="En Fazla 50 Karakter Girebilirsiniz...")]
        public string AD { get; set; }

        [Required(ErrorMessage = "Bu Alan Bo� B�rak�lamaz.")]
        [StringLength(50, ErrorMessage = "En Fazla 50 Karakter Girebilirsiniz...")]
        public string SOYAD { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBLSATISLAR> TBLSATISLARs { get; set; }
    }
}
