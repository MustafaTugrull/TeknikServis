using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeknikServis.Formlar
{
    public partial class FrmSatislar : Form
    {
        public FrmSatislar()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void FrmSatislar_Load(object sender, EventArgs e)
        {
            var degerler = from x in db.TBL_URUNHAREKET
                           select new
                           {
                               x.HAREKETID,
                               x.TBL_URUN.AD,
                               MUSTERI = x.TBL_CARI.AD + " " + x.TBL_CARI.SOYAD,
                               PERSONEL = x.TBL_PERSONEL.AD + " " + x.TBL_PERSONEL.SOYAD,
                               x.TARIH,
                               x.ADET,
                               x.FIYAT,
                               x.URUNSERINO
                           };
            gridControl1.DataSource = degerler.ToList();
        }
    }
}
