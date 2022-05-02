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
    public partial class YoneticiSifreUnuttum : Form
    {
        public YoneticiSifreUnuttum()
        {
            InitializeComponent();
        }

        private void btnSifreyiGoster_Click(object sender, EventArgs e)
        {
            try
            {
                using (Yonetici nesne = new Yonetici())
                {
                    nesne.AdSoyad = txtAdSoyad.Text;
                    nesne.TCNo = txtTCNo.Text;
                    nesne.DogumTarihi = txtDogumTarihi.Text;
                    nesne.email = txtEMail.Text;
                    nesne.tel = txtTel.Text;

                    string sorgu = "SELECT * FROM Yonetici Where TC = @p1";

                    List<string> YoneticiBilgileri = nesne.Giris(sorgu, txtTCNo.Text);

                    if (YoneticiBilgileri.Count != 0)
                    {
                        if (YoneticiBilgileri[1] == nesne.AdSoyad &&
                            YoneticiBilgileri[2] == nesne.TCNo &&
                            YoneticiBilgileri[4] == nesne.DogumTarihi + " 00:00:00" &&
                            YoneticiBilgileri[8] == nesne.email &&
                            YoneticiBilgileri[9] == nesne.tel
                            )
                        {
                            MessageBox.Show("Şifreniz: " + YoneticiBilgileri[6]);
                        }
                        else
                        {
                            MessageBox.Show("Bilgiler hatalıdır. Lütfen tekrar deneyiniz.");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Yönetici bulunamadı!" +
                        "\nLütfen TC numaranızı kontrol ediniz.");
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

        private void btnGeri_Click(object sender, EventArgs e)
        {
            YoneticiGiris yon = new YoneticiGiris();
            this.Hide();
            yon.ShowDialog();
        }
    }
}
