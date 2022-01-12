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
    public partial class FrmPersonel : Form
    {
        public FrmPersonel()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();

        void liste()
        {
            var degerler = from u in db.TBL_PERSONEL
                           select new
                           {
                               u.ID,
                               u.AD,
                               u.SOYAD,
                               u.MAIL,
                               u.TELEFON
                           };
            gridControl1.DataSource = degerler.ToList();
        }
        private void FrmPersonel_Load(object sender, EventArgs e)
        {
            liste();

            lookUpEdit1.Properties.DataSource = (from x in db.TBL_DEPARTMAN
                                                 select new
                                                 {
                                                     x.ID,
                                                     x.AD
                                                 }).ToList();

            string ad1, soyad1, ad2, soyad2, ad3, soyad3, ad4, soyad4;

            ad1 = db.TBL_PERSONEL.First(x => x.ID == 1).AD;
            soyad1 = db.TBL_PERSONEL.First(x => x.ID == 1).SOYAD;
            labelControl3.Text = ad1 + " " + soyad1;
            labelControl4.Text = db.TBL_PERSONEL.First(x => x.ID == 1).TBL_DEPARTMAN.AD;
            labelControl6.Text = db.TBL_PERSONEL.First(x => x.ID == 1).MAIL;

            ad2 = db.TBL_PERSONEL.First(x => x.ID == 2).AD;
            soyad2 = db.TBL_PERSONEL.First(x => x.ID == 2).SOYAD;
            labelControl18.Text = ad2 + " " + soyad2;
            labelControl16.Text = db.TBL_PERSONEL.First(x => x.ID == 2).TBL_DEPARTMAN.AD;
            labelControl2.Text = db.TBL_PERSONEL.First(x => x.ID == 2).MAIL;

            ad3 = db.TBL_PERSONEL.First(x => x.ID == 3).AD;
            soyad3 = db.TBL_PERSONEL.First(x => x.ID == 3).SOYAD;
            labelControl24.Text = ad3 + " " + soyad3;
            labelControl22.Text = db.TBL_PERSONEL.First(x => x.ID == 3).TBL_DEPARTMAN.AD;
            labelControl20.Text = db.TBL_PERSONEL.First(x => x.ID == 3).MAIL;

            ad4 = db.TBL_PERSONEL.First(x => x.ID == 4).AD;
            soyad4 = db.TBL_PERSONEL.First(x => x.ID == 4).SOYAD;
            labelControl30.Text = ad4 + " " + soyad4;
            labelControl28.Text = db.TBL_PERSONEL.First(x => x.ID == 4).TBL_DEPARTMAN.AD;
            labelControl26.Text = db.TBL_PERSONEL.First(x => x.ID == 4).MAIL;


        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TBL_PERSONEL t = new TBL_PERSONEL();
            t.AD = TxtAd.Text;
            t.SOYAD = TxtSoyad.Text;
            t.DEPARTMAN = byte.Parse(lookUpEdit1.EditValue.ToString());
            t.MAIL = TxtMail.Text;
            t.TELEFON = TxtTelefon.Text;
            db.TBL_PERSONEL.Add(t);
            db.SaveChanges();
            MessageBox.Show("Personel Sisteme Eklendi.");
            liste();
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            liste();
        }
    }
}
