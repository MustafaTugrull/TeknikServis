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
    
    public partial class TBL_URUNHAREKET
    {
        public int HAREKETID { get; set; }
        public Nullable<int> URUN { get; set; }
        public Nullable<int> MUSTERI { get; set; }
        public Nullable<short> PERSONEL { get; set; }
        public Nullable<System.DateTime> TARIH { get; set; }
        public Nullable<short> ADET { get; set; }
        public Nullable<decimal> FIYAT { get; set; }
    
        public virtual TBL_CARI TBL_CARI { get; set; }
        public virtual TBL_PERSONEL TBL_PERSONEL { get; set; }
        public virtual TBL_URUN TBL_URUN { get; set; }
    }
}