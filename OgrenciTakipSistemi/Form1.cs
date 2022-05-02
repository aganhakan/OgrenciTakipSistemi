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
    public partial class Anaform : Form
    {
        public Anaform()
        {
            InitializeComponent();
        }
        private void Anaform_Load(object sender, EventArgs e)
        {

        }
        private void btnOgrenci_Click(object sender, EventArgs e)
        {
            OgrenciGiris ogr = new OgrenciGiris();
            this.Hide();
            ogr.ShowDialog();
        }

        private void btnOgretmen_Click(object sender, EventArgs e)
        {
            OgretmenGiris ogr = new OgretmenGiris();
            this.Hide();
            ogr.ShowDialog();
        }

        private void btnYonetici_Click(object sender, EventArgs e)
        {
            YoneticiGiris ynt = new YoneticiGiris();
            this.Hide();
            ynt.ShowDialog();
        }
    }
}
