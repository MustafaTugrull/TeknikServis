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
    public partial class FrmFaturaKalemleri : Form
    {
        public FrmFaturaKalemleri()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void BtnAra_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Txtid.Text);

            var degerler = (from u in db.TBL_FATURADETAY
                            select new
                            {
                                u.FATURADETAYID,
                                u.URUN,
                                u.FIYAT,
                                u.TUTAR,
                                u.FATURAID
                            }).Where(x => x.FATURAID == id);
            gridControl1.DataSource = degerler.ToList();

        }
    }
}
