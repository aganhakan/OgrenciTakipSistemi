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
    public partial class OgretmenSifreUnuttumForm : Form
    {
        public OgretmenSifreUnuttumForm()
        {
            InitializeComponent();
        }

        private void btnSifreyiGoster_Click(object sender, EventArgs e)
        {
            try
            {
                using (Ogretmen nesne = new Ogretmen())
                {
                    nesne.AdSoyad = txtAdSoyad.Text;
                    nesne.TCNo = txtTCNo.Text;
                    nesne.DogumTarihi = txtDogumTarihi.Text;
                    nesne.email = txtEMail.Text;
                    nesne.tel = txtTel.Text;

                    string sorgu = "SELECT * FROM Ogretmen Where TC = @p1";

                    List<string> OgretmenBilgileri = nesne.Giris(sorgu, txtTCNo.Text);

                    if (OgretmenBilgileri.Count != 0)
                    {
                        if (OgretmenBilgileri[1] == nesne.AdSoyad &&
                            OgretmenBilgileri[2] == nesne.TCNo &&
                            OgretmenBilgileri[4] == nesne.DogumTarihi + " 00:00:00" &&
                            OgretmenBilgileri[8] == nesne.email &&
                            OgretmenBilgileri[9] == nesne.tel
                            )
                        {
                            MessageBox.Show("Şifreniz: " + OgretmenBilgileri[6]);
                        }
                        else
                        {
                            MessageBox.Show("Bilgiler hatalıdır. Lütfen tekrar deneyiniz.");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("öğretmen bulunamadı!" +
                        "\nLütfen TC Numaranızı ediniz.");
                    }
                }
            }
            catch (ArgumentException exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
        private void btnGeri_Click(object sender, EventArgs e)
        {
            OgretmenGiris ogr = new OgretmenGiris();
            this.Hide();
            ogr.ShowDialog();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
