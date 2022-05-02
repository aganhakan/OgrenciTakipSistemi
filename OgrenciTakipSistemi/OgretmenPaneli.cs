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
                string sorgu = "Select Sinif + '/' + Sube from Siniflar s inner join Ogretmen o " +
                    "on o.SinifId = s.Id where o.TC = @p1";
                lblSinif.Text = (nesne.Giris(sorgu, lblOgretmenTC.Text))[0];

                dgwOgrenciBilgiler.DataSource = nesne.Listeleme(lblOgretmenTC.Text, "OgretmenDetay");
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

            if (!string.IsNullOrEmpty(OgretmenBilgileri[10]))
            {
                using (Ogretmen nesne = new Ogretmen())
                {
                    string sorgu = "SELECT Fotograf FROM Ogretmen WHERE TC = @No";
                    picOgretmen.Image = Image.FromStream(nesne.Fotograf(OgretmenBilgileri[2], sorgu));
                }
            }
            #endregion

            #region Sınıf Bilgileri

            lblOgretmenAd.Text = lblAdiSoyadi.Text;
            lblSinif.Text = OgretmenBilgileri[7];

            listeleme();
            #endregion
        }

        private void btnOgretmenFotograf_Click(object sender, EventArgs e)
        {
            //picOgrenci.SizeMode = PictureBoxSizeMode.StretchImage;
            openFileDialog1.ShowDialog();
            picOgretmen.ImageLocation = openFileDialog1.FileName;
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                if (picOgretmen.ImageLocation == null)
                    throw new Exception("Lütfen resim ekleyiniz.");

                FileStream fs = new FileStream(picOgretmen.ImageLocation, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                byte[] resim = br.ReadBytes((int)fs.Length);

                DateTime dt = Convert.ToDateTime(txtOgretmenDogumTarih.Text);

                using (Ogretmen nesne = new Ogretmen())
                {
                    MessageBox.Show(nesne.Guncelle("OgreTMENGuncelleme", txtOgretmenDogumyeri.Text, dt, txtSifre.Text,
                        txtOgretmenEMail.Text, txtOgretmenTel.Text, txtOgretmenAdres.Text, resim, lblOgretmenTC.Text));
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void dgwOgrenciBilgiler_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dgwOgrenciBilgiler.SelectedCells[0].RowIndex;

            string no = dgwOgrenciBilgiler.Rows[secilen].Cells[0].Value.ToString();

            txtOgrenciNo.Text = dgwOgrenciBilgiler.Rows[secilen].Cells[1].Value.ToString();
            txtOgrenciAd.Text = dgwOgrenciBilgiler.Rows[secilen].Cells[2].Value.ToString(); 

            OgretmenOgrenciDetaycs frm = new OgretmenOgrenciDetaycs(no);
            frm.ShowDialog();
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            try
            {
                using (Ogretmen nesne = new Ogretmen())
                {
                    string sorgu = "";
                    if (!string.IsNullOrEmpty(txtOgrenciNo.Text))
                        sorgu = $"Select o.* from Ogrenciler o inner join Siniflar s on s.Id = o.SinifId inner join Ogretmen og on og.SinifId = s.Id where o.OgrenciNo = '{txtOgrenciNo.Text}'";
                    else if (!string.IsNullOrEmpty(txtOgrenciAd.Text))
                        sorgu = $"Select o.* from Ogrenciler o inner join Siniflar s on s.Id = o.SinifId inner join Ogretmen og on og.SinifId = s.Id where o.AdSoyad = '{txtOgrenciAd.Text}'";
                    else
                        throw new Exception("Lütfen aranacak öğrenci bilgisini giriniz!");

                    dgwOgrenciBilgiler.DataSource = nesne.Listeleme(sorgu);
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
    }
}
