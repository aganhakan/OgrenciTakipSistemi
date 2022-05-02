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
    public partial class OgretmenOgrenciDetaycs : Form
    {
        string no;
        public OgretmenOgrenciDetaycs(string no)
        {
            InitializeComponent();
            this.no = no;
        }

        private void OgretmenOgrenciDetaycs_Load(object sender, EventArgs e)
        {

        }
    }
}
