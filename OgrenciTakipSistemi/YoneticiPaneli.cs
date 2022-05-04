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
        public void Listeleme()
        {
            using (Yonetici nesne = new Yonetici())
            {
                string sorgu = "Select * from Yonetici";

                dgwYonetici.DataSource = nesne.Listeleme(sorgu);
                dgwYonetici.Columns[0].Visible = false;
                dgwYonetici.Columns[6].Visible = false;
                dgwYonetici.Columns[10].Visible = false;
                dgwYonetici.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                //dgwOgrenciBilgiler.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
        }
        private void YoneticiPaneli_Load(object sender, EventArgs e)
        {
            Listeleme();
        }
        private void btnOgretmenKaydet_Click(object sender, EventArgs e)
        {

        }

        private void yöneticiTablosuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnCikis yonbil = new btnCikis();
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
