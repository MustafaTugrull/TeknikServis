﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class DbTeknikServisEntities : DbContext
    {
        public DbTeknikServisEntities()
            : base("name=DbTeknikServisEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TBL_ADMIN> TBL_ADMIN { get; set; }
        public virtual DbSet<TBL_ARIZADETAY> TBL_ARIZADETAY { get; set; }
        public virtual DbSet<TBL_CARI> TBL_CARI { get; set; }
        public virtual DbSet<TBL_DEPARTMAN> TBL_DEPARTMAN { get; set; }
        public virtual DbSet<TBL_FATURABILGI> TBL_FATURABILGI { get; set; }
        public virtual DbSet<TBL_FATURADETAY> TBL_FATURADETAY { get; set; }
        public virtual DbSet<TBL_GIDER> TBL_GIDER { get; set; }
        public virtual DbSet<TBL_KATEGORI> TBL_KATEGORI { get; set; }
        public virtual DbSet<TBL_NOTLARIM> TBL_NOTLARIM { get; set; }
        public virtual DbSet<TBL_PERSONEL> TBL_PERSONEL { get; set; }
        public virtual DbSet<TBL_URUN> TBL_URUN { get; set; }
        public virtual DbSet<TBL_URUNHAREKET> TBL_URUNHAREKET { get; set; }
        public virtual DbSet<TBL_URUNKABUL> TBL_URUNKABUL { get; set; }
        public virtual DbSet<TBL_URUNTAKIP> TBL_URUNTAKIP { get; set; }
        public virtual DbSet<TBL_HAKKIMIZDA> TBL_HAKKIMIZDA { get; set; }
        public virtual DbSet<TBL_ILETISIM> TBL_ILETISIM { get; set; }
        public virtual DbSet<TBL_ILCELER> TBL_ILCELER { get; set; }
        public virtual DbSet<TBL_ILLER> TBL_ILLER { get; set; }
    
        public virtual ObjectResult<urunkategori_Result> urunkategori()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<urunkategori_Result>("urunkategori");
        }
    
        public virtual ObjectResult<string> makskategoriurun()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("makskategoriurun");
        }
    
        public virtual ObjectResult<string> maksurunmarka()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("maksurunmarka");
        }
    
        public virtual ObjectResult<string> makscari()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("makscari");
        }
    }
}
