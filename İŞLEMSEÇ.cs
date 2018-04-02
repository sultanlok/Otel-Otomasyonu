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
namespace otel_otomasyonu
{
    public partial class İŞLEMSEÇ : Form
    {
        public İŞLEMSEÇ()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            rezervasyon res = new rezervasyon();
            res.Show();
            this.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {// güncelleme ve çıkış işlemleri

            SqlConnection baglanti = new SqlConnection("Data Source=SAMSUNGPC;Initial Catalog=OTEL;Integrated Security=true;");
            cıkısislemleri kyt = new cıkısislemleri();
            kyt.Show();
            this.Hide();
        }

        private void İŞLEMSEÇ_Load(object sender, EventArgs e)
        {
            
        }

       
    }
}
