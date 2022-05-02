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
