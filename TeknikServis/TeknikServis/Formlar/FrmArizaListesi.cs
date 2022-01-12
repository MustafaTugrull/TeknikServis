using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeknikServis.Formlar
{
    public partial class FrmArizaListesi : Form
    {
        public FrmArizaListesi()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void FrmArizaListesi_Load(object sender, EventArgs e)
        {
            var degerler = from x in db.TBL_URUNKABUL
                           select new
                           {
                               x.ISLEMID,
                               CARi = x.TBL_CARI.AD + " " + x.TBL_CARI.SOYAD,
                               PERSONEL = x.TBL_PERSONEL.AD + " " + x.TBL_PERSONEL.SOYAD,
                               x.GELISTARIH,
                               x.CIKISTARIHI,
                               x.URUNSERINO,
                               x.URUNDURUMDETAY
                           };
            gridControl1.DataSource = degerler.ToList();
            labelControl5.Text = db.TBL_URUNKABUL.Count(x => x.URUNDURUM == true).ToString();
            labelControl3.Text = db.TBL_URUNKABUL.Count(x => x.URUNDURUM == false).ToString();
            labelControl1.Text = db.TBL_URUN.Count().ToString();
            labelControl7.Text = db.TBL_URUNKABUL.Count(x=>x.URUNDURUMDETAY=="Parça bekliyor.").ToString();
            labelControl13.Text = db.TBL_URUNKABUL.Count(x=>x.URUNDURUMDETAY=="Mesaj bekliyor.").ToString();
            labelControl11.Text = db.TBL_URUNKABUL.Count(x=>x.URUNDURUMDETAY=="İptal bekliyor.").ToString();

            SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-AO5K0VF;Initial Catalog=DbTeknikServis;Integrated Security=True");
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT URUNDURUMDETAY, COUNT(*) FROM TBL_URUNKABUL GROUP BY URUNDURUMDETAY", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                chartControl1.Series["Series 1"].Points.AddPoint(Convert.ToString(dr[0]), int.Parse(dr[1].ToString()));
            }
            baglanti.Close();

        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmArizaDetaylar fr = new FrmArizaDetaylar();
            fr.id = gridView1.GetFocusedRowCellValue("ISLEMID").ToString();
            fr.serino = gridView1.GetFocusedRowCellValue("URUNSERINO").ToString();
            fr.Show();
        }
    }
}
