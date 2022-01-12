using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace TeknikServis.Formlar
{
    public partial class FrmCariiller : Form
    {
        public FrmCariiller()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-AO5K0VF;Initial Catalog=DbTeknikServis;Integrated Security=True");
        private void FrmCariiller_Load(object sender, EventArgs e)
        {
            chartControl1.Series["Series 1"].Points.AddPoint("Ankara", 22);
            chartControl1.Series["Series 1"].Points.AddPoint("İstanbul", 12);
            chartControl1.Series["Series 1"].Points.AddPoint("İzmir", 8);
            chartControl1.Series["Series 1"].Points.AddPoint("Bursa", 14);

            gridControl1.DataSource = db.TBL_CARI.OrderBy(x => x.IL).
                GroupBy(y => y.IL).
                Select(z => new { İL = z.Key, TOPLAM = z.Count() }).ToList();

            baglanti.Open();
            SqlCommand komut = new SqlCommand("select IL,Count(*) FROM TBL_CARI group by IL", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while(dr.Read())
            {
                chartControl1.Series["Series 1"].Points.AddPoint(Convert.ToString(dr[0]),int.Parse(dr[1].ToString()));
            }
        }
    }
}
