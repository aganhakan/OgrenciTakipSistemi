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
    public partial class OgretmenOgrenciDetaycs : Form
    {
        public List<string> bilgiler = new List<string>();
        public OgretmenOgrenciDetaycs(List<string> bilgiler)
        {
            InitializeComponent();
            this.bilgiler = bilgiler;
        }
        public void listeleme()
        {
            using (Ogretmen nesne = new Ogretmen())
            {
                string sorgu = "Select o.OgrenciNo as 'Öğrenci No', o.AdSoyad as 'Ad Soyad',d.DersAdi as 'Ders Adı'," +
                    "n.Sinav1 as '1. Sınav',n.Sinav2 as '2. Sınav',n.KanaatNot as 'Kanaat Notu'," +
                    "n.Ortalama as 'Ortalama',n.Durum as 'Durumu'from Ogrenciler o inner join Notlar n" +
                    " on n.OgrenciId = o.Id inner join Dersler d on d.Id = n.DersId Where o.Id = " + int.Parse(bilgiler[0]);

                dgwOgrenciDetay.DataSource = nesne.Listeleme(sorgu);
                dgwOgrenciDetay.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                //dgwOgrenciDetay.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
        }

        private void OgretmenOgrenciDetaycs_Load(object sender, EventArgs e)
        {
            #region Tablo
            listeleme();
            #endregion

            #region Bilgiler
            lblOgrenciNo.Text = bilgiler[1];
            lblAdSoyad.Text = bilgiler[2];
            lblTCNo.Text = bilgiler[3];
            lblAnneAdi.Text = bilgiler[4];
            lblBabaAdi.Text = bilgiler[5];
            lblVeliTel.Text = bilgiler[6];
            cmbDers.DataSource = Enum.GetValues(typeof(Dersler.Dersler1));
            #endregion

            #region Fotoğraf
            using (Ogrenci nesne = new Ogrenci())
            {
                string sorgu = "SELECT Fotograf FROM Ogrenciler WHERE Id = @No";
                picOgrenci.Image = Image.FromStream(nesne.Fotograf(bilgiler[0], sorgu));
            }
            #endregion

        }

        private void dgwOgrenciDetay_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dgwOgrenciDetay.SelectedCells[0].RowIndex;
            cmbDers.Text = dgwOgrenciDetay.Rows[secilen].Cells[2].Value.ToString();
            txtSinav1.Text = dgwOgrenciDetay.Rows[secilen].Cells[3].Value.ToString();
            txtSinav2.Text = dgwOgrenciDetay.Rows[secilen].Cells[4].Value.ToString();
            txtKanaatNot.Text = dgwOgrenciDetay.Rows[secilen].Cells[5].Value.ToString();
        }

        private void txtKanaatNot_TextChanged(object sender, EventArgs e)
        {
            #region Ortalama ve Durum
            try
            {
                using (Notlar nesne = new Notlar())
                {
                    lblOrtalama.Text = null;
                    if (!string.IsNullOrEmpty(txtSinav1.Text) && !string.IsNullOrEmpty(txtSinav2.Text) && !string.IsNullOrEmpty(txtKanaatNot.Text))
                    {
                        lblOrtalama.Text = nesne.ortalama(txtSinav1.Text, txtSinav2.Text, txtKanaatNot.Text);
                    }
                    else if (!string.IsNullOrEmpty(txtSinav1.Text) && !string.IsNullOrEmpty(txtSinav2.Text))
                    {
                        nesne.sinav1 = txtSinav1.Text;
                        nesne.sinav2 = txtSinav2.Text;
                    }
                    else if (!string.IsNullOrEmpty(txtSinav1.Text))
                    {
                        nesne.sinav1 = txtSinav1.Text;
                    }
                    else if (!string.IsNullOrEmpty(txtSinav2.Text))
                    {
                        nesne.sinav1 = txtSinav2.Text;
                    }

                    lblDurum.Text = nesne.durum(lblOrtalama.Text);
                }
            }
            catch (ArgumentException exc)
            {
                MessageBox.Show(exc.Message);
                txtKanaatNot.Clear();
            }
            #endregion
            //try
            //{
            //    using (Notlar nesne = new Notlar())
            //    {
            //        lblDurum.Text = nesne.Kanaat(txtSinav1.Text, txtSinav2.Text, txtKanaatNot.Text, lblOrtalama.Text);
            //    }
            //}
            //catch (Exception)
            //{
            //    throw;
            //}
        }
        private void txtSinav1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                using (Notlar nesne = new Notlar())
                {
                    if (!string.IsNullOrEmpty(txtSinav1.Text))
                        nesne.sinav1 = txtSinav1.Text;
                }
                txtKanaatNot_TextChanged(this, null);
            }
            catch (ArgumentException exc)
            {
                MessageBox.Show(exc.Message);
                txtSinav1.Clear();
            }
        }

        private void txtSinav2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                using (Notlar nesne = new Notlar())
                {
                    if (!string.IsNullOrEmpty(txtSinav2.Text))
                        nesne.sinav2 = txtSinav2.Text;
                }
                txtKanaatNot_TextChanged(this, null);
            }
            catch (ArgumentException exc)
            {
                MessageBox.Show(exc.Message);
                txtSinav2.Clear();
            }
        }
        private void btnGeri_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnOgrenciKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(cmbDers.Text))
                    throw new ArgumentException("Lütfen sınav girişi yapacağınız derse tıklayınız.");
                if (string.IsNullOrEmpty(txtSinav1.Text))
                    throw new ArgumentException("Lütfen ilk sınav notunu giriniz.");
                else if (string.IsNullOrEmpty(txtSinav2.Text) && !string.IsNullOrEmpty(txtKanaatNot.Text))
                    throw new ArgumentException("Lütfen kanaat notundan önce 2. sınav notunu giriniz.");
                //else if(string.IsNullOrEmpty(txtKanaatNot.Text))
                //    throw new ArgumentException("Lütfen kanaat notunu giriniz.");

                string sorgu = $"Update Notlar set Sinav1 = {txtSinav1.Text}, Sinav2 = '{txtSinav2.Text}', " +
                               $"KanaatNot = '{txtKanaatNot.Text}', Ortalama = '{lblOrtalama.Text}', Durum = '{lblDurum.Text}' " +
                               $" where OgrenciId = {int.Parse(bilgiler[0])} and " +
                               $"DersId = (Select Id from Dersler where DersAdi = '{cmbDers.Text}')";

                using (Notlar nesne = new Notlar())
                {
                    MessageBox.Show(nesne.Ekle(sorgu));
                }
                listeleme();
            }
            catch (ArgumentException exc)
            {
                MessageBox.Show(exc.Message);
            }  
        }
        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                string sorgu = $"insert into Notlar (DersId, OgrenciId) " +
                    $"values ((select Id from Dersler where DersAdi = '{cmbDers.Text}'),{int.Parse(bilgiler[0])})";
                using (Dersler nesne = new Dersler())
                {
                    MessageBox.Show(nesne.Ekle(sorgu));
                }
                listeleme();
            }
            catch (ArgumentException exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void cmbDers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
