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
    public partial class YoneticiPaneli : Form
    {
        public YoneticiPaneli()
        {
            InitializeComponent();
        }

        private void öğretmenTablosuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void öğrenciTablosuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btnOgretmenKaydet_Click(object sender, EventArgs e)
        {

        }

        private void yöneticiTablosuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            YoneticiBilgileri yonbil = new YoneticiBilgileri();
            yonbil.ShowDialog();
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
    }
}
