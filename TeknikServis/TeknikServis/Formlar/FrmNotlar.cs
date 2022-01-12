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
    public partial class FrmNotlar : Form
    {
        public FrmNotlar()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void FrmNotlar_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = db.TBL_NOTLARIM.Where(x => x.DURUM == false).ToList();
            gridControl2.DataSource = db.TBL_NOTLARIM.Where(y => y.DURUM == true).ToList();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TBL_NOTLARIM t = new TBL_NOTLARIM();
            t.BASLIK = TxtBaslik.Text;
            t.ICERIK = Txticerik.Text;
            t.DURUM = false;
            t.TARIH = DateTime.Parse(TxtTarih.Text);
            db.TBL_NOTLARIM.Add(t);
            db.SaveChanges();
            MessageBox.Show("Not başarılı bir şekilde kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            gridControl1.DataSource = db.TBL_NOTLARIM.Where(x => x.DURUM == false).ToList();
            gridControl2.DataSource = db.TBL_NOTLARIM.Where(y => y.DURUM == true).ToList();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtID.Text);
            var deger = db.TBL_NOTLARIM.Find(id);
            db.TBL_NOTLARIM.Remove(deger);
            db.SaveChanges();
            MessageBox.Show("Not başarıyla silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            if (checkEdit1.Checked == true)
            {
                int id = int.Parse(TxtID.Text);
                var deger = db.TBL_NOTLARIM.Find(id);
                deger.DURUM = true;
                db.SaveChanges();
                MessageBox.Show("Not durumu değiştirildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            TxtID.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
        }
    }
}
