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
    public partial class OgrenciGiris : Form
    {
        public OgrenciGiris()
        {
            InitializeComponent();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            try
            {
                using (Ogrenci nesne = new Ogrenci())
                {
                    nesne.TCNo = txtTcNo.Text;
                    nesne.DogumTarihi = txtDogumTarihi.Text;

                    string sorgu = "SELECT * FROM Ogrenciler o inner join Siniflar s on s.Id = o.SinifId Where TC = @p1";

                    List<string> OgrenciBilgileri = nesne.Giris(sorgu, txtTcNo.Text);

                    if (OgrenciBilgileri.Count != 0)
                    {
                        if (OgrenciBilgileri[5] == txtDogumTarihi.Text + " 00:00:00")
                        {
                            OgrenciPanel ogr = new OgrenciPanel(OgrenciBilgileri);
                            this.Hide();
                            ogr.ShowDialog();
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Hatalı doğum tarihi girdiniz. Lütfen tekrar deneyiniz.");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Öğrenci bulunamadı!" +
                        "\nLütfen TC numarasını kontrol ediniz.");
                    } 
                }              
            }
            catch (ArgumentException exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void OgrenciGiris_Load(object sender, EventArgs e)
        {

        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            Anaform ana = new Anaform();
            this.Hide();
            ana.ShowDialog();
        }
    }
}
