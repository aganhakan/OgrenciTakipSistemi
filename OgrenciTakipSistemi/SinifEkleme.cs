using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OgrenciTakipBLL;

namespace OgrenciTakipSistemi
{
    public partial class SinifEkleme : Form
    {
        public SinifEkleme()
        {
            InitializeComponent();
        }
        public void Listeleme()
        {
            try
            {
                using (Siniflar nesne = new Siniflar())
                {
                    dgwSiniflar.DataSource = nesne.Listeleme();
                    dgwSiniflar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    //dgwOgrenci.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void SinifEkleme_Load(object sender, EventArgs e)
        {
            using (Siniflar nesne = new Siniflar())
            {
                CmbSinif.DataSource = nesne.sinif;
                CmbSube.DataSource = Enum.GetValues(typeof(Siniflar.Subeler));
            }
            Listeleme();
        }
        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                using (Siniflar nesne = new Siniflar())
                {
                    MessageBox.Show(nesne.Ekle(CmbSinif.Text, CmbSube.Text));

                }
                Listeleme();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                using (Siniflar nesne = new Siniflar())
                {
                    MessageBox.Show(nesne.Delete(CmbSinif.Text, CmbSube.Text));
                }
                Listeleme();
            }
            catch (Exception)
            {
                MessageBox.Show("Bu sınıf silinemez." +
                    "\nBu sınıfta öğrenci veya öğretmen bulunmaktadır.");
            }
        }
    }
}
