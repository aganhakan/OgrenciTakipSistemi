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
            using (Ogrenci nesne = new Ogrenci())
            {
                dgwOgrenciDetay.DataSource = nesne.Listeleme1(bilgiler[0]);
                dgwOgrenciDetay.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                //dgwOgrenciDetay.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
        }
        public bool EminMisiniz()
        {
            bool cevap = false;
            if (MessageBox.Show("Bu işlemi yapmak istediğinize emin misiniz ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                cevap = true;
            }
            return cevap;
        }
        public void NotKontrol()
        {
            using (Notlar nesne = new Notlar())
            {
                lblOrtalama.Text = null;
                if (!string.IsNullOrEmpty(txtSinav1.Text) && !string.IsNullOrEmpty(txtSinav2.Text) && !string.IsNullOrEmpty(txtKanaatNot.Text))
                {
                    lblOrtalama.Text = nesne.Ortalama(txtSinav1.Text, txtSinav2.Text, txtKanaatNot.Text);
                }
                lblDurum.Text = nesne.Kanaat(txtSinav1.Text, txtSinav2.Text, txtKanaatNot.Text);
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
                picOgrenci.Image = Image.FromStream(nesne.Fotograf(bilgiler[1]));
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
            try
            {
                NotKontrol();
            }
            catch (ArgumentException exc)
            {
                MessageBox.Show(exc.Message);
                txtKanaatNot.Clear();
            }   
        }
        private void txtSinav1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                NotKontrol();
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
                NotKontrol();
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
                if (EminMisiniz())
                {
                    if (string.IsNullOrEmpty(cmbDers.Text))
                        throw new ArgumentException("Lütfen sınav girişi yapacağınız derse tıklayınız.");
                    if (string.IsNullOrEmpty(txtSinav1.Text))
                        throw new ArgumentException("Lütfen ilk sınav notunu giriniz.");
                    else if (string.IsNullOrEmpty(txtSinav2.Text) && !string.IsNullOrEmpty(txtKanaatNot.Text))
                        throw new ArgumentException("Lütfen kanaat notundan önce 2. sınav notunu giriniz.");
                    using (Notlar nesne = new Notlar())
                    {
                        MessageBox.Show(nesne.Ekle(txtSinav1.Text, txtSinav2.Text, txtKanaatNot.Text, lblOrtalama.Text, lblDurum.Text,
                            bilgiler[0], cmbDers.Text));
                    }
                    listeleme();
                }   
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
                if (true)
                {
                    using (Dersler nesne = new Dersler())
                    {
                        MessageBox.Show(nesne.Ekle(cmbDers.Text, bilgiler[0]));
                    }
                    listeleme();
                }           
            }
            catch (Exception)
            {
                MessageBox.Show("Bu ders tabloya eklenmiştir. Tekrar aynı dersi ekleyemezsiniz!");
            }
        }

        private void cmbDers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
