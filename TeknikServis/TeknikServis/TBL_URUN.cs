//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TeknikServis
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBL_URUN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_URUN()
        {
            this.TBL_URUNHAREKET = new HashSet<TBL_URUNHAREKET>();
        }
    
        public int ID { get; set; }
        public string AD { get; set; }
        public string MARKA { get; set; }
        public Nullable<decimal> ALISFIYAT { get; set; }
        public Nullable<decimal> SATISFIYAT { get; set; }
        public Nullable<short> STOK { get; set; }
        public Nullable<byte> KATEGORI { get; set; }
        public Nullable<bool> DURUM { get; set; }
    
        public virtual TBL_KATEGORI TBL_KATEGORI { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_URUNHAREKET> TBL_URUNHAREKET { get; set; }
    }
}
