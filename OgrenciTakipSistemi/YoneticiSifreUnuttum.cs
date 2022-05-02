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
