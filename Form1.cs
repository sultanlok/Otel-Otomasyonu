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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
          private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           if (textBox1.Text == "nuran" && textBox2.Text == "123nuran*" || textBox1.Text == "sultan" && textBox2.Text == "571610")
            {
                İŞLEMSEÇ frm = new İŞLEMSEÇ();
                frm.Show();
                this.Hide();
            }
         else MessageBox.Show("kullanıcı adı veya şifre yanlış girildi.");
        }
    }
}
