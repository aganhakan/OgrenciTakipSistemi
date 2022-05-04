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
                    string sorgu = "Select Sinif + ' / ' + Sube as 'Mevcut Sınıflar' from Siniflar order by Sinif asc";

                    dgwSiniflar.DataSource = nesne.Listeleme(sorgu);
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
                    string sorgu = $"Insert Into Siniflar(Sinif,Sube) Values ('{CmbSinif.Text}','{CmbSube.Text}')";

                    MessageBox.Show(nesne.Ekle(sorgu));

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
                    string sorgu = $"Delete from Siniflar Where Sinif = '{CmbSinif.Text}' and Sube = '{CmbSube.Text}'";

                    MessageBox.Show(nesne.Ekle(sorgu));

                }
                Listeleme();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}
