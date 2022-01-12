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
    public partial class FrmCariListesi : Form
    {
        public FrmCariListesi()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        int secilen;
        void liste()
        {
            var degerler = from x in db.TBL_CARI
                           select new
                           {
                               x.ID,
                               x.AD,
                               x.SOYAD,
                               x.IL,
                               x.ILCE
                           };
            gridControl1.DataSource = degerler.ToList();
        }
        private void FrmCariListesi_Load(object sender, EventArgs e)
        {
            liste();

            labelControl12.Text = db.TBL_CARI.Count().ToString();

            lookUpEdit1.Properties.DataSource = (from x in db.TBL_ILLER
                                                 select new
                                                 {
                                                     x.id,
                                                     x.sehir
                                                 }).ToList();
            labelControl16.Text = db.TBL_CARI.Select(x => x.IL).Distinct().Count().ToString();
            labelControl18.Text = db.TBL_CARI.Select(x => x.ILCE).Distinct().Count().ToString();
            labelControl14.Text = db.makscari().FirstOrDefault();

        }

        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            secilen = int.Parse(lookUpEdit1.EditValue.ToString());
            lookUpEdit2.Properties.DataSource = (from y in db.TBL_ILCELER
                                                 select new
                                                 {
                                                     y.id,
                                                     y.ilce,
                                                     y.sehir
                                                 }).Where(z => z.sehir == secilen).ToList();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (TxtAd.Text != "" & TxtSoyad.Text != "" & TxtAd.Text.Length <= 20)
            {
                TBL_CARI t = new TBL_CARI();
                t.AD = TxtAd.Text;
                t.ADRES = TxtSoyad.Text;
                t.IL = lookUpEdit1.Text;
                t.ILCE = lookUpEdit2.Text;
                db.TBL_CARI.Add(t);
                db.SaveChanges();
                MessageBox.Show("Cari Sisteme Eklendi");
                liste();
            }
            else
            {
                MessageBox.Show("Hatalı Giriş Yeniden Deneyiniz.");
            }
        }
    }
}
