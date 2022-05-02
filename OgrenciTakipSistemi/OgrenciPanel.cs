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
    public partial class OgrenciPanel : Form
    {
        public List<string> OgrenciBilgileri = new List<string>();
        public OgrenciPanel(List<string> OgrenciBilgileri)
        {
            InitializeComponent();
            this.OgrenciBilgileri = OgrenciBilgileri;
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        public void Listeleme()
        {
            try
            {
                using (Ogrenci nesne = new Ogrenci())
                {
                    string procedure = "OgrenciNotlar";
                    dgwOgrenci.DataSource = nesne.Listeleme(lblOgrenciNo.Text, procedure);

                    dgwOgrenci.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    //dgwOgrenci.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }    
        }
        private void OgrenciPanel_Load(object sender, EventArgs e)
        {
            lblOgrenciNo.Text = OgrenciBilgileri[1];
            lblOgrenciAd.Text = OgrenciBilgileri[2];
            txtTC.Text = OgrenciBilgileri[3];
            txtOgrenciDogumYer.Text = OgrenciBilgileri[4];
            txtOgrenciDogumTarih.Text = OgrenciBilgileri[5];
            lblOgrenciSinif.Text = $"{OgrenciBilgileri[13]} / {OgrenciBilgileri[14]}";
            txtAnneAdi.Text = OgrenciBilgileri[7];
            txtBabaAdi.Text = OgrenciBilgileri[8];
            txtVeliTel.Text = OgrenciBilgileri[9];
            txtAdres.Text = OgrenciBilgileri[11];

            using (Ogrenci nesne = new Ogrenci())
            {
                string sorgu = "SELECT Fotograf FROM Ogrenciler WHERE OgrenciNo = @No";
                picOgrenci.Image = Image.FromStream(nesne.Fotograf(OgrenciBilgileri[1],sorgu));
            }

            Listeleme();
        }

        private void btnOgrenciGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                if (picOgrenci.ImageLocation == null)
                    throw new Exception("Lütfen resim ekleyiniz.");

                FileStream fs = new FileStream(picOgrenci.ImageLocation, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                byte[] resim = br.ReadBytes((int)fs.Length);              

                DateTime dt = Convert.ToDateTime(txtOgrenciDogumTarih.Text);

                using (Ogrenci nesne = new Ogrenci())
                {
                    MessageBox.Show(nesne.Guncelle("OgrenciGuncelleme", lblOgrenciNo.Text, txtTC.Text, txtOgrenciDogumYer.Text,
                        dt, txtAnneAdi.Text, txtBabaAdi.Text, txtVeliTel.Text, txtAdres.Text, resim));
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            
        }

        private void btnOgrenciFotograf_Click(object sender, EventArgs e)
        {
            //picOgrenci.SizeMode = PictureBoxSizeMode.StretchImage;
            openFileDialog1.ShowDialog();
            picOgrenci.ImageLocation = openFileDialog1.FileName;
        }
    }
}
