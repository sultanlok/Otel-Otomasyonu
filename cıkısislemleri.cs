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
    public partial class cıkısislemleri : Form
    {
        public cıkısislemleri()
        {
            InitializeComponent();
        }
       public static int sayi ;
        private void button1_Click(object sender, EventArgs e)
        {// REZERVASYONDA DÜZENLEME İŞLEMLERİ
         
            REZERVASYONKAYITLARI kayıt = new REZERVASYONKAYITLARI();
            kayıt.Show();
            this.Hide();
           sayi = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {//MÜŞTERİ DÜZENLEME İŞLEMLERİ
            MÜŞTERİ_KAYITLARI musteri = new MÜŞTERİ_KAYITLARI();
            musteri.Show();
            this.Hide();
            sayi = 0;
        }
    }
}
