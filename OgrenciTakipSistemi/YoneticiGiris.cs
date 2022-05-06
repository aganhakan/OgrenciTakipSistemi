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
    public partial class YoneticiGiris : Form
    {
        public YoneticiGiris()
        {
            InitializeComponent();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            try
            {
                using (Yonetici nesne = new Yonetici())
                {
                    List<string> YoneticiBilgieri = nesne.Giris( txtKullaniciAdi.Text, txtSifre.Text);

                    if (YoneticiBilgieri.Count != 0)
                    {
                        if (YoneticiBilgieri[6] == txtSifre.Text)
                        {
                            YoneticiPaneli ogr = new YoneticiPaneli();
                            this.Hide();
                            ogr.ShowDialog();
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Hatalı şifre girdiniz. Lütfen tekrar deneyiniz.");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Yönetici bulunamadı!" +
                        "\nLütfen TC Numaranızı kontrol ediniz.");
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
            Anaform ana = new Anaform();
            this.Hide();
            ana.ShowDialog();
        }

        private void btnSifremiUnuttum_Click(object sender, EventArgs e)
        {
            YoneticiSifreUnuttum yon = new YoneticiSifreUnuttum();
            this.Hide();
            yon.ShowDialog();
        }

        private void YoneticiGiris_Load(object sender, EventArgs e)
        {
           
        }
    }
}
