﻿using System;
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

            #region Sınıflar
            try
            {
                using (Siniflar nesne = new Siniflar())
                {
                    cmbOgretmenSinif.DataSource = cmbOgrenciSinif.DataSource = nesne.sinif;
                }
                cmbOgretmenSube.DataSource = cmbOgrenciSube.DataSource = Enum.GetValues(typeof(Siniflar.Subeler));
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

            #endregion
        }
        private void YoneticiPaneli_Load(object sender, EventArgs e)
        {
            Listeleme();
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
                    string sorgu = "SELECT Fotograf FROM Yonetici WHERE TC = @No";
                    picYonetici.Image = Image.FromStream(nesne.Fotograf(dgwYonetici.Rows[secilen].Cells[2].Value.ToString(), sorgu));
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
            if (!string.IsNullOrEmpty(dgwOgretmen.Rows[secilen].Cells[12].Value.ToString()))
            {
                cmbOgretmenSinif.Text = (dgwOgretmen.Rows[secilen].Cells[12].Value.ToString())[0].ToString();
                cmbOgretmenSube.Text = (dgwOgretmen.Rows[secilen].Cells[12].Value.ToString())[2].ToString();
            }
            txtOgretmenEMail.Text = (dgwOgretmen.Rows[secilen].Cells[8].Value.ToString());
            txtOgretmenTel.Text = (dgwOgretmen.Rows[secilen].Cells[9].Value.ToString());
            txtOgretmenAdres.Text = (dgwOgretmen.Rows[secilen].Cells[11].Value.ToString());

            #region Fotoğraf
            if (!string.IsNullOrEmpty(dgwOgretmen.Rows[secilen].Cells[10].Value.ToString()))
            {
                using (Ogretmen nesne = new Ogretmen())
                {
                    string sorgu = "SELECT Fotograf FROM Ogretmen WHERE TC = @No";
                    picOgretmen.Image = Image.FromStream(nesne.Fotograf(dgwOgretmen.Rows[secilen].Cells[2].Value.ToString(), sorgu));
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
            if (!string.IsNullOrEmpty(dgwOgrenci.Rows[secilen].Cells[12].Value.ToString()))
            {
                cmbOgrenciSinif.Text = (dgwOgrenci.Rows[secilen].Cells[12].Value.ToString())[0].ToString();
                cmbOgrenciSube.Text = (dgwOgrenci.Rows[secilen].Cells[12].Value.ToString())[2].ToString();
            }
            txtAnneAdi.Text = (dgwOgrenci.Rows[secilen].Cells[7].Value.ToString());
            txtBabaAdi.Text = (dgwOgrenci.Rows[secilen].Cells[8].Value.ToString());
            txtVeliTel.Text = (dgwOgrenci.Rows[secilen].Cells[9].Value.ToString());
            txtAdres.Text = (dgwOgrenci.Rows[secilen].Cells[11].Value.ToString());

            #region Fotoğraf
            if (!string.IsNullOrEmpty(dgwOgrenci.Rows[secilen].Cells[10].Value.ToString()))
            {
                using (Ogrenci nesne = new Ogrenci())
                {
                    string sorgu = "SELECT Fotograf FROM Ogrenciler WHERE TC = @No";
                    picOgrenci.Image = Image.FromStream(nesne.Fotograf(dgwOgrenci.Rows[secilen].Cells[3].Value.ToString(), sorgu));
                }
            }
            else
                picOgrenci.Image = null;
            #endregion
        }

        private void btnYoneticiFotograf_Click(object sender, EventArgs e)
        {
            //picOgrenci.SizeMode = PictureBoxSizeMode.StretchImage;
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != "openFileDialog1")
                picYonetici.ImageLocation = openFileDialog1.FileName;
        }

        private void btnOgretmenFotograf_Click(object sender, EventArgs e)
        {
            //picOgrenci.SizeMode = PictureBoxSizeMode.StretchImage;
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != "openFileDialog1")
                picOgretmen.ImageLocation = openFileDialog1.FileName;
        }
        private void btnOgrenciFotograf_Click(object sender, EventArgs e)
        {
            //picOgrenci.SizeMode = PictureBoxSizeMode.StretchImage;
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != "openFileDialog1")
                picOgrenci.ImageLocation = openFileDialog1.FileName;
        }
        private void btnYoneticiFotografGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                if (picYonetici.ImageLocation == null || picYonetici.ImageLocation == "openFileDialog1")
                    throw new Exception("Lütfen resim ekleyiniz.");

                FileStream fs = new FileStream(picYonetici.ImageLocation, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                byte[] resim = br.ReadBytes((int)fs.Length);

                using (Ogretmen nesne = new Ogretmen())
                {
                    MessageBox.Show(nesne.FotoGuncelle("Update Yonetici set Fotograf = @p1 where TC = " + txtYoneticiTC.Text +
                        "", resim));
                    Listeleme();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
        private void btnOgretmenFotografGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                if (picOgretmen.ImageLocation == null || picOgretmen.ImageLocation == "openFileDialog1")
                    throw new Exception("Lütfen resim ekleyiniz.");

                FileStream fs = new FileStream(picOgretmen.ImageLocation, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                byte[] resim = br.ReadBytes((int)fs.Length);

                using (Ogretmen nesne = new Ogretmen())
                {
                    MessageBox.Show(nesne.FotoGuncelle("Update Ogretmen set Fotograf = @p1 where TC = " + txtOgretmenTC.Text +
                        "", resim));
                    Listeleme();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
        private void btnOgrenciFotografGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                if (picOgrenci.ImageLocation == null || picOgrenci.ImageLocation == "openFileDialog1")
                    throw new Exception("Lütfen resim ekleyiniz.");

                FileStream fs = new FileStream(picOgrenci.ImageLocation, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                byte[] resim = br.ReadBytes((int)fs.Length);

                using (Ogrenci nesne = new Ogrenci())
                {
                    MessageBox.Show(nesne.FotoGuncelle("Update Ogrenciler set Fotograf = @p1 where OgrenciNo = " + txtOgrenciNo.Text +
                        "", resim));
                    Listeleme();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
        private void btnYonKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dt = Convert.ToDateTime(txtYoneticiDogumTarih.Text);
                DateTime ib = Convert.ToDateTime(txtYoneticiiseBaslama.Text);
                using (Yonetici nesne = new Yonetici())
                {
                    MessageBox.Show(nesne.Guncelle("YoneticiEkleme", txtYoneticiAd.Text, txtYoneticiTC.Text, txtYoneticiDogumYeri.Text,
                    dt, ib, txtYoneticiSifre.Text, txtYoneticiGorev.Text,
                    txtYoneticiEMail.Text, txtYoneticiTel.Text, txtYoneticiAdres.Text,"id"));

                    Listeleme();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
        private void btnOgretmenKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dt = Convert.ToDateTime(txtOgretmenDogumTarih.Text);
                DateTime ib = Convert.ToDateTime(txtOgretmeniseBaslama.Text);
                using (Ogretmen nesne = new Ogretmen())
                {
                    MessageBox.Show(nesne.Guncelle("OgretmenEkleme", txtOgretmenAd.Text, txtOgretmenTC.Text, txtOgretmenDogumyeri.Text,
                        dt, ib, txtOgretmenSifre.Text, cmbOgrenciSinif.Text, cmbOgrenciSube.Text,
                        txtOgretmenEMail.Text, txtOgretmenTel.Text, txtOgretmenAdres.Text, "id"));

                    Listeleme();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
        private void btnOgrenciKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dt = Convert.ToDateTime(txtOgrenciDogumTarih.Text);
                using (Ogrenci nesne = new Ogrenci())
                {
                    string id = dgwOgrenci.Rows[dgwOgrenci.SelectedCells[0].RowIndex].Cells[0].Value.ToString();

                    MessageBox.Show(nesne.Guncelle2("OgrenciEkleme", txtOgrenciNo.Text, txtOgrenciAd.Text, txtOgrenciTC.Text,
                        txtOgrenciDogumYer.Text, dt, cmbOgrenciSinif.Text, cmbOgrenciSube.Text,
                        txtAnneAdi.Text, txtBabaAdi.Text, txtVeliTel.Text, txtAdres.Text, id));

                    Listeleme();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
        private void btnYoneticiGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dt = Convert.ToDateTime(txtYoneticiDogumTarih.Text);
                DateTime ib = Convert.ToDateTime(txtYoneticiiseBaslama.Text);
                using (Yonetici nesne = new Yonetici())
                {
                    string id = dgwYonetici.Rows[dgwYonetici.SelectedCells[0].RowIndex].Cells[0].Value.ToString();

                    MessageBox.Show(nesne.Guncelle("YoneticiGuncelleme", txtYoneticiAd.Text, txtYoneticiTC.Text, txtYoneticiDogumYeri.Text,
                    dt, ib, txtYoneticiSifre.Text, txtYoneticiGorev.Text,
                    txtYoneticiEMail.Text, txtYoneticiTel.Text, txtYoneticiAdres.Text, id));

                    Listeleme();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
        private void btnOgretmenGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dt = Convert.ToDateTime(txtOgretmenDogumTarih.Text);
                DateTime ib = Convert.ToDateTime(txtOgretmeniseBaslama.Text);
                using (Ogretmen nesne = new Ogretmen())
                {
                    string id = dgwOgretmen.Rows[dgwOgretmen.SelectedCells[0].RowIndex].Cells[0].Value.ToString();

                    MessageBox.Show(nesne.Guncelle("OgretmenGuncelleme2", txtOgretmenAd.Text, txtOgretmenTC.Text, txtOgretmenDogumyeri.Text,
                        dt, ib, txtOgretmenSifre.Text, cmbOgrenciSinif.Text, cmbOgrenciSube.Text,
                        txtOgretmenEMail.Text, txtOgretmenTel.Text, txtOgretmenAdres.Text, id));

                    Listeleme();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
        private void btnOgrenciGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dt = Convert.ToDateTime(txtOgrenciDogumTarih.Text);
                using (Ogrenci nesne = new Ogrenci())
                {
                    string id = dgwOgrenci.Rows[dgwOgrenci.SelectedCells[0].RowIndex].Cells[0].Value.ToString();

                    MessageBox.Show(nesne.Guncelle2("OgrenciGuncelleme2", txtOgrenciNo.Text, txtOgrenciAd.Text, txtOgrenciTC.Text,
                        txtOgrenciDogumYer.Text, dt, cmbOgrenciSinif.Text, cmbOgrenciSube.Text,
                        txtAnneAdi.Text, txtBabaAdi.Text, txtVeliTel.Text, txtAdres.Text, id));

                    Listeleme();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}
