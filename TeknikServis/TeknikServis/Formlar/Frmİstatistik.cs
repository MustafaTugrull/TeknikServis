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
    public partial class Frmİstatistik : Form
    {
        public Frmİstatistik()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void Frmİstatistik_Load(object sender, EventArgs e)
        {
            labelControl2.Text = db.TBL_URUN.Count().ToString();
            labelControl3.Text = db.TBL_KATEGORI.Count().ToString();
            labelControl5.Text = db.TBL_URUN.Sum(x => x.STOK).ToString();
            labelControl7.Text = "10";
            labelControl19.Text = (from x in db.TBL_URUN
                                   orderby x.STOK descending
                                   select x.AD).FirstOrDefault();
            labelControl18.Text = (from x in db.TBL_URUN
                                   orderby x.STOK ascending
                                   select x.AD).FirstOrDefault();
            labelControl13.Text = (from x in db.TBL_URUN
                                   orderby x.SATISFIYAT descending
                                   select x.AD).FirstOrDefault();
            labelControl12.Text = (from x in db.TBL_URUN
                                   orderby x.SATISFIYAT ascending
                                   select x.AD).FirstOrDefault();
            labelControl25.Text = db.TBL_URUN.Count(x => x.KATEGORI == 4).ToString();
            labelControl27.Text = db.TBL_URUN.Count(x => x.KATEGORI == 1).ToString();
            labelControl29.Text = db.TBL_URUN.Count(x => x.KATEGORI == 3).ToString();
            labelControl35.Text = (from x in db.TBL_URUN
                                   select x.AD).Distinct().Count().ToString();
            labelControl33.Text = db.TBL_URUNKABUL.Count().ToString();
            labelControl16.Text = db.makskategoriurun().FirstOrDefault();
        }
    }
}
