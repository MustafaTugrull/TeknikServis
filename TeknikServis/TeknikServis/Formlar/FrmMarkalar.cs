using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TeknikServis.Formlar
{
    public partial class FrmMarkalar : Form
    {
        public FrmMarkalar()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void FrmMarkalar_Load(object sender, EventArgs e)
        {
            var degerler = db.TBL_URUN.OrderBy(x => x.MARKA).GroupBy(y => y.MARKA).Select(z => new
            {
                Marka = z.Key,
                Toplam = z.Count()
            });
            gridControl1.DataSource = degerler.ToList();
            labelControl2.Text = db.TBL_URUN.Count().ToString();
            labelControl3.Text = (from x in db.TBL_URUN
                                   select x.AD).Distinct().Count().ToString();
            labelControl5.Text = db.maksurunmarka().FirstOrDefault();
            labelControl7.Text = (from x in db.TBL_URUN
                                  orderby x.SATISFIYAT descending
                                  select x.MARKA).FirstOrDefault();

            SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-AO5K0VF;Initial Catalog=DbTeknikServis;Integrated Security=True");
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT MARKA, COUNT(*) FROM TBL_URUN GROUP BY MARKA", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                chartControl1.Series["Series 1"].Points.AddPoint(Convert.ToString(dr[0]), int.Parse(dr[1].ToString()));
            }
            baglanti.Close();

            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("SELECT TBL_KATEGORI.AD,COUNT(*) FROM TBL_URUN INNER JOIN TBL_KATEGORI ON TBL_KATEGORI.ID = TBL_URUN.KATEGORI GROUP BY TBL_KATEGORI.AD ", baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                chartControl2.Series["Kategoriler"].Points.AddPoint(Convert.ToString(dr2[0]), int.Parse(dr2[1].ToString()));
            }
            baglanti.Close();


        }
    }
}
