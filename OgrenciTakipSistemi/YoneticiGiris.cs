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
            using (YoneticiPaneli yon = new YoneticiPaneli())
            {
                this.Hide();
                yon.ShowDialog();
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
    }
}
