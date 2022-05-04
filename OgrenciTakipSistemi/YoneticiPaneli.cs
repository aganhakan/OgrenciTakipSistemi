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
using OgrenciTakipBLL;

namespace OgrenciTakipSistemi
{
    public partial class YoneticiPaneli : Form
    {
        public YoneticiPaneli()
        {
            InitializeComponent();
        }
        public void Listeleme()
        {
            #region Yönetici Tablosu
            using (Yonetici nesne = new Yonetici())
            {
                string sorgu = "Select * from Yonetici";

                dgwYonetici.DataSource = nesne.Listeleme(sorgu);
                dgwYonetici.Columns[0].Visible = false;
                dgwYonetici.Columns[6].Visible = false;
                dgwYonetici.Columns[10].Visible = false;
                dgwYonetici.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                //dgwYonetici.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
            #endregion

            #region Öğretmen Tablosu
            using (Ogretmen nesne = new Ogretmen())
            {
                string sorgu = "Select o.*,Sinif + '/' + Sube as 'Sınıf' from Ogretmen o " +
                    "inner join Siniflar s on s.Id = o.SinifId";

                dgwOgretmen.DataSource = nesne.Listeleme(sorgu);
                dgwOgretmen.Columns[0].Visible = false;
                dgwOgretmen.Columns[6].Visible = false;
                dgwOgretmen.Columns[7].Visible = false;
                dgwOgretmen.Columns[10].Visible = false;
                dgwOgretmen.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                //dgwOgretmen.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
            #endregion

            #region Öğrenci Tablosu
            using (Ogrenci nesne = new Ogrenci())
            {
                string sorgu = "Select o.*,Sinif + '/' + Sube as 'Sınıf' from Ogrenciler o " +
                    "inner join Siniflar s on s.Id = o.SinifId";

                dgwOgrenci.DataSource = nesne.Listeleme(sorgu);
                dgwOgrenci.Columns[0].Visible = false;
                dgwOgrenci.Columns[6].Visible = false;
                dgwOgrenci.Columns[10].Visible = false;
                dgwOgrenci.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                //dgwOgrenci.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
            #endregion

        }
        private void YoneticiPaneli_Load(object sender, EventArgs e)
        {
            Listeleme();
        }
        private void btnOgretmenKaydet_Click(object sender, EventArgs e)
        {

        }

        private void yöneticiTablosuToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void sınıfEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SinifEkleme snf = new SinifEkleme();
            snf.ShowDialog();
        }

        private void dgwYonetici_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dgwYonetici.SelectedCells[0].RowIndex;

            txtYoneticiAd.Text = (dgwYonetici.Rows[secilen].Cells[1].Value.ToString());
            txtYoneticiTC.Text = (dgwYonetici.Rows[secilen].Cells[2].Value.ToString());
            txtYoneticiDogumYeri.Text = (dgwYonetici.Rows[secilen].Cells[3].Value.ToString());
            txtYoneticiDogumTarih.Text = (dgwYonetici.Rows[secilen].Cells[4].Value.ToString());
            txtYoneticiiseBaslama.Text = (dgwYonetici.Rows[secilen].Cells[5].Value.ToString());
            txtYoneticiSifre.Text = (dgwYonetici.Rows[secilen].Cells[6].Value.ToString());
            txtYoneticiGorev.Text = (dgwYonetici.Rows[secilen].Cells[7].Value.ToString());
            txtYoneticiEMail.Text = (dgwYonetici.Rows[secilen].Cells[8].Value.ToString());
            txtYoneticiTel.Text = (dgwYonetici.Rows[secilen].Cells[9].Value.ToString());
            txtYoneticiAdres.Text = (dgwYonetici.Rows[secilen].Cells[11].Value.ToString());

            #region Fotoğraf
            if (!string.IsNullOrEmpty(dgwYonetici.Rows[secilen].Cells[10].Value.ToString()))
            {
                using (Yonetici nesne = new Yonetici())
                {
                    string sorgu = "SELECT Fotograf FROM Ogretmen WHERE Id = @No";
                    picOgretmen.Image = Image.FromStream(nesne.Fotograf(dgwYonetici.Rows[secilen].Cells[0].Value.ToString(), sorgu));
                }
            }
            else
                picYonetici.Image = null;
            #endregion
        }

        private void dgwOgretmen_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dgwOgretmen.SelectedCells[0].RowIndex;

            txtOgretmenAd.Text = (dgwOgretmen.Rows[secilen].Cells[1].Value.ToString());
            txtOgretmenTC.Text = (dgwOgretmen.Rows[secilen].Cells[2].Value.ToString());
            txtOgretmenDogumyeri.Text = (dgwOgretmen.Rows[secilen].Cells[3].Value.ToString());
            txtOgretmenDogumTarih.Text = (dgwOgretmen.Rows[secilen].Cells[4].Value.ToString());
            txtOgretmeniseBaslama.Text = (dgwOgretmen.Rows[secilen].Cells[5].Value.ToString());
            txtOgretmenSifre.Text = (dgwOgretmen.Rows[secilen].Cells[6].Value.ToString());
            txtOgretmenSinif.Text = (dgwOgretmen.Rows[secilen].Cells[12].Value.ToString());
            txtOgretmenEMail.Text = (dgwOgretmen.Rows[secilen].Cells[8].Value.ToString());
            txtOgretmenTel.Text = (dgwOgretmen.Rows[secilen].Cells[9].Value.ToString());
            txtOgretmenAdres.Text = (dgwOgretmen.Rows[secilen].Cells[11].Value.ToString());

            #region Fotoğraf
            if (!string.IsNullOrEmpty(dgwOgretmen.Rows[secilen].Cells[10].Value.ToString()))
            {
                using (Ogretmen nesne = new Ogretmen())
                {
                    string sorgu = "SELECT Fotograf FROM Ogretmen WHERE Id = @No";
                    picOgretmen.Image = Image.FromStream(nesne.Fotograf(dgwOgretmen.Rows[secilen].Cells[0].Value.ToString(), sorgu));
                }
            }
            else
                picOgretmen.Image = null;
            #endregion
        }

        private void dgwOgrenci_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dgwOgrenci.SelectedCells[0].RowIndex;

            txtOgrenciNo.Text = (dgwOgrenci.Rows[secilen].Cells[1].Value.ToString());
            txtOgrenciAd.Text = (dgwOgrenci.Rows[secilen].Cells[2].Value.ToString());
            txtOgrenciTC.Text = (dgwOgrenci.Rows[secilen].Cells[3].Value.ToString());
            txtOgrenciDogumYer.Text = (dgwOgrenci.Rows[secilen].Cells[4].Value.ToString());
            txtOgrenciDogumTarih.Text = (dgwOgrenci.Rows[secilen].Cells[5].Value.ToString());
            txtOgrenciSinif.Text = (dgwOgrenci.Rows[secilen].Cells[12].Value.ToString());
            txtAnneAdi.Text = (dgwOgrenci.Rows[secilen].Cells[7].Value.ToString());
            txtBabaAdi.Text = (dgwOgrenci.Rows[secilen].Cells[8].Value.ToString());
            txtVeliTel.Text = (dgwOgrenci.Rows[secilen].Cells[9].Value.ToString());
            txtAdres.Text = (dgwOgrenci.Rows[secilen].Cells[11].Value.ToString());

            #region Fotoğraf
            if (!string.IsNullOrEmpty(dgwOgrenci.Rows[secilen].Cells[10].Value.ToString()))
            {
                using (Ogretmen nesne = new Ogretmen())
                {
                    string sorgu = "SELECT Fotograf FROM Ogrenciler WHERE Id = @No";
                    picOgrenci.Image = Image.FromStream(nesne.Fotograf(dgwOgrenci.Rows[secilen].Cells[0].Value.ToString(), sorgu));
                }
            }
            else
                picOgrenci.Image = null;
            #endregion
        }
    }
}
