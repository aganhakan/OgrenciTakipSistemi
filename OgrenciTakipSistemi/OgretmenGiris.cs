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
    public partial class OgretmenGiris : Form
    {
        public OgretmenGiris()
        {
            InitializeComponent();
        }

        private void OgretmenGiris_Load(object sender, EventArgs e)
        {

        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            try
            {
                using (Ogretmen nesne = new Ogretmen())
                {
                    List<string> OgretmenBilgileri = nesne.Giris(txtKullaniciAdi.Text, txtSifre.Text);

                    if (OgretmenBilgileri.Count != 0)
                    {
                        if (OgretmenBilgileri[6] == txtSifre.Text)
                        {
                            OgretmenPaneli ogr = new OgretmenPaneli(OgretmenBilgileri);
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
                        MessageBox.Show("Öğretmen bulunamadı!" +
                        "\nLütfen TC numaranızı kontrol ediniz.");
                    }
                }
            }
            catch (ArgumentException exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void btnSifremiUnuttum_Click(object sender, EventArgs e)
        {
            OgretmenSifreUnuttumForm ogr = new OgretmenSifreUnuttumForm();
            this.Hide();
            ogr.ShowDialog();
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            Anaform ana = new Anaform();
            this.Hide();
            ana.ShowDialog();
        }
    }
}
