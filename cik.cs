using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace otel_otomasyonu
{
    public partial class cik : Form
    {
        Form ctx; // form oluşturuyoruz
        public cik(Form cntx)
        {
            InitializeComponent();
            ctx = cntx; //cntx(cik formunu) yeni oluşturdugumuz forma aktarıyoruz.
        }

        private void button1_Click(object sender, EventArgs e)
        {//EVET
            İŞLEMSEÇ sç = new İŞLEMSEÇ();
            this.Hide();
            ctx.Hide();//kayıtlar formunu kapatıyoruz
            sç.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {//HAYIRRR
            Application.Exit();

        }
    }
}
