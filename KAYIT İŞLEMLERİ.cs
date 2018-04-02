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
    public partial class rezervasyon : Form
    {
        
        REZERVASYONKAYITLARI kyt;// kayıtları local bir değişken yapıyoruz
        MÜŞTERİ_KAYITLARI kayıt;
        public rezervasyon()
        {
            InitializeComponent();
        }
       public void temizle(){
       textBox1.Text="" ;
       textBox2.Text="" ;
       textBox3.Text="" ;
       textBox4.Text="" ;
       comboBox1.Text="" ;
       dateTimePicker1.Value = DateTime.Today;
       dateTimePicker2.Value = DateTime.Today;
     
          }
        SqlConnection baglanti = new SqlConnection("Data Source=SAMSUNGPC;Initial Catalog=OTEL;Integrated Security=true;");
      
        private void button1_Click(object sender, EventArgs e)
        {//rezervasyonu tabloya KAYDETder

            baglanti.Open();

            if(textBox1.Text!="" && textBox2.Text!="" && textBox3.Text!="" && textBox4.Text!="" && comboBox1.Text!="" /*&& dateTimePicker1.Value!=null && dateTimePicker2.Value!=null*/){
            if (dateTimePicker1.Value < dateTimePicker2.Value)
            {
                SqlCommand komut = new SqlCommand("insert into  REZERVASYON(AD,SOYAD,TELEFON_NO,TC_KİMLİK_NO,CİNSİYET,YETİSKİN,COCUK,GİRİS_TARİHİ,CIKIS_TARİHİ)values('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + textBox4.Text.ToString() + "','" + comboBox1.Text.ToString() + "','" + numericUpDown2.Value.ToString() + "','" + numericUpDown1.Value.ToString() + "','" +dateTimePicker1.Text+ "','" + dateTimePicker2.Text+ "')", baglanti);
                komut.ExecuteNonQuery();
                temizle();
                MessageBox.Show("Rezervasyon Yapıldı..");
            }
            else MessageBox.Show("Tarihleri kontrol ediniz..");
            }
            else MessageBox.Show("Lütfen tüm bilgilerinizi doldurunuz.!");
                    
            baglanti.Close();
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Char.IsLetterOrDigit(e.KeyChar) || Char.IsSymbol(e.KeyChar) || Char.IsPunctuation(e.KeyChar) || Char.IsWhiteSpace(e.KeyChar) || Char.IsControl(e.KeyChar) || Char.IsNumber(e.KeyChar);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Char.IsLetter(e.KeyChar) || Char.IsSymbol(e.KeyChar) || Char.IsPunctuation(e.KeyChar) || Char.IsWhiteSpace(e.KeyChar) ;
           // if (MinimumSize != 10) { MessageBox.Show("eksik"); }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Char.IsLetter(e.KeyChar) || Char.IsSymbol(e.KeyChar) || Char.IsPunctuation(e.KeyChar) || Char.IsWhiteSpace(e.KeyChar)  ;
           // if (MinimumSize != 11) { MessageBox.Show("eksik"); }
        }

        private void button4_Click(object sender, EventArgs e)
        {//cıkıs
            this.Close();
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {// rezervasyon kayıtları tablosunu gösterir...
            kyt = new REZERVASYONKAYITLARI();
            kyt.Show();
            this.Hide();

            cıkısislemleri.sayi = 1;
        }

        private void rezervasyon_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {// geri
            İŞLEMSEÇ islem = new İŞLEMSEÇ();
            islem.Show();
            this.Hide();

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Char.IsDigit(e.KeyChar) || Char.IsSymbol(e.KeyChar) || Char.IsPunctuation(e.KeyChar) ;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Char.IsDigit(e.KeyChar) || Char.IsSymbol(e.KeyChar) || Char.IsPunctuation(e.KeyChar) ;
        }

        private void button3_Click(object sender, EventArgs e)
        {//İPTAL
            temizle();
        }

        private void button6_Click(object sender, EventArgs e)
        {// müşteriyi tabloya kaydeder

             baglanti.Open();

            if(textBox1.Text!="" && textBox2.Text!="" && textBox3.Text!="" && textBox4.Text!="" && comboBox1.Text!="" /*&& dateTimePicker1.Value!=null && dateTimePicker2.Value!=null*/){
            if (dateTimePicker1.Value < dateTimePicker2.Value)
            {
                SqlCommand komut = new SqlCommand("insert into  MÜSTERİtablosu(AD,SOYAD,TELEFON,TC,CİNSİYET,YETİSKİN,COCUK,GİRİS,CIKIS)values('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + textBox4.Text.ToString() + "','" + comboBox1.Text.ToString() + "','" + numericUpDown2.Value.ToString() + "','" + numericUpDown1.Value.ToString() + "','" +dateTimePicker1.Text+ "','" + dateTimePicker2.Text+ "')", baglanti);
                komut.ExecuteNonQuery();
                temizle();
                MessageBox.Show("MÜŞTERİ KAYDI YAPILDI..");
            }
            else MessageBox.Show("Tarihleri kontrol ediniz..");
            }
            else MessageBox.Show("Lütfen tüm bilgilerinizi doldurunuz.!");
                baglanti.Close();
        
        }

        private void button7_Click(object sender, EventArgs e)
        {// müşteri kayıtlarrrııı
            kayıt = new MÜŞTERİ_KAYITLARI();
            kayıt.Show();
            this.Hide();
            cıkısislemleri.sayi = 1;
        }

        
        }

    

      
    }

