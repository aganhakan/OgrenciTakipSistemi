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
using System.IO;

namespace OgrenciTakipSistemi
{
    public partial class OgretmenPaneli : Form
    {
        public List<string> OgretmenBilgileri = new List<string>();
        public OgretmenPaneli(List<string> OgretmenBilgileri)
        {
            InitializeComponent();
            this.OgretmenBilgileri = OgretmenBilgileri;
        }
        public void listeleme()
        {
            using (Ogretmen nesne = new Ogretmen())
            {

                lblSinif.Text = (nesne.Sinif(lblOgretmenTC.Text))[0];

                dgwOgrenciBilgiler.DataSource = nesne.Listeleme(lblOgretmenTC.Text);
                dgwOgrenciBilgiler.Columns[0].Visible = false;
                dgwOgrenciBilgiler.Columns[6].Visible = false;
                dgwOgrenciBilgiler.Columns[10].Visible = false;
                dgwOgrenciBilgiler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                //dgwOgrenciBilgiler.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
        }

        private void OgretmenPaneli_Load(object sender, EventArgs e)
        {
            #region Bilgilerim
            lblAdiSoyadi.Text = OgretmenBilgileri[1];
            lblOgretmenTC.Text = OgretmenBilgileri[2];
            txtOgretmenDogumyeri.Text = OgretmenBilgileri[3];
            txtOgretmenDogumTarih.Text = OgretmenBilgileri[4];
            txtSifre.Text = OgretmenBilgileri[6];
            txtOgretmenEMail.Text = OgretmenBilgileri[8];
            txtOgretmenTel.Text = OgretmenBilgileri[9];
            txtOgretmenAdres.Text = OgretmenBilgileri[11];
            #endregion

            #region Fotoğraf
            if (!string.IsNullOrEmpty(OgretmenBilgileri[10]))
            {
                using (Ogretmen nesne = new Ogretmen())
                {
                    picOgretmen.Image = Image.FromStream(nesne.Fotograf(OgretmenBilgileri[2]));
                }
            }
            #endregion

            #region Sınıf Bilgileri

            lblOgretmenAd.Text = lblAdiSoyadi.Text;
            listeleme();

            #endregion
        }

        private void btnOgretmenFotograf_Click(object sender, EventArgs e)
        {
            try
            {
                if (picOgretmen.ImageLocation == null || picOgretmen.ImageLocation == "openFileDialog1" && picOgretmen.Image == null)
                    throw new Exception("Lütfen resim ekleyiniz.");

                FileStream fs = new FileStream(picOgretmen.ImageLocation, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                byte[] resim = br.ReadBytes((int)fs.Length);

                using (Ogretmen nesne = new Ogretmen())
                {
                    MessageBox.Show(nesne.FotoGuncelle(lblOgretmenTC.Text, resim));
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }     
        }
        private void btnFotografSec_Click(object sender, EventArgs e)
        {
            //picOgrenci.SizeMode = PictureBoxSizeMode.StretchImage;
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != "openFileDialog1")
                picOgretmen.ImageLocation = openFileDialog1.FileName;
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                using (Ogretmen nesne = new Ogretmen())
                {
                    MessageBox.Show(nesne.Guncelle(txtOgretmenDogumyeri.Text, txtOgretmenDogumTarih.Text, txtSifre.Text,
                        txtOgretmenEMail.Text, txtOgretmenTel.Text, txtOgretmenAdres.Text, lblOgretmenTC.Text));
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
        
        private void dgwOgrenciBilgiler_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            List<string> bilgiler = new List<string>();

            int secilen = dgwOgrenciBilgiler.SelectedCells[0].RowIndex;
            bilgiler.Add(dgwOgrenciBilgiler.Rows[secilen].Cells[0].Value.ToString()); 
            bilgiler.Add(dgwOgrenciBilgiler.Rows[secilen].Cells[1].Value.ToString()); 
            bilgiler.Add(dgwOgrenciBilgiler.Rows[secilen].Cells[2].Value.ToString()); 
            bilgiler.Add(dgwOgrenciBilgiler.Rows[secilen].Cells[3].Value.ToString()); 
            bilgiler.Add(dgwOgrenciBilgiler.Rows[secilen].Cells[7].Value.ToString()); 
            bilgiler.Add(dgwOgrenciBilgiler.Rows[secilen].Cells[8].Value.ToString()); 
            bilgiler.Add(dgwOgrenciBilgiler.Rows[secilen].Cells[9].Value.ToString());

            if (string.IsNullOrEmpty(bilgiler[1]))
            {
                MessageBox.Show("Lütfen notlarını görmek istediğiniz öğrenciye tıklayınız");
            }
            else
            {
                OgretmenOgrenciDetaycs frm = new OgretmenOgrenciDetaycs(bilgiler);
                frm.ShowDialog();
            }

        }
        private void dgwOgrenciBilgiler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dgwOgrenciBilgiler.SelectedCells[0].RowIndex;
            txtOgrenciNo.Text = dgwOgrenciBilgiler.Rows[secilen].Cells[1].Value.ToString();
            txtOgrenciAd.Text = dgwOgrenciBilgiler.Rows[secilen].Cells[2].Value.ToString();
        }
        private void btnAra_Click(object sender, EventArgs e)
        {
            try
            {
                using (Ogretmen nesne = new Ogretmen())
                {
                    dgwOgrenciBilgiler.DataSource = nesne.Listeleme(txtOgrenciNo.Text, txtOgrenciAd.Text);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            listeleme();
            txtOgrenciAd.Clear();
            txtOgrenciNo.Clear();
        }
        private void btnCikis_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
