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
    public partial class MÜŞTERİ_KAYITLARI : Form
    {
        public MÜŞTERİ_KAYITLARI()
        {
            InitializeComponent();
        }
        public static int tası = 0;
        SqlConnection baglanti = new SqlConnection("Data Source=SAMSUNGPC;Initial Catalog=OTEL;Integrated Security=true;");
       
        public void bul()
        {
            baglanti.Open();
            SqlCommand kmt = new SqlCommand("select TC from MÜSTERİtablosu", baglanti);
            kmt.ExecuteNonQuery();
            baglanti.Close();
        }
     public void verilerigoster()
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }

            SqlCommand kmt = new SqlCommand("select * from MÜSTERİtablosu", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(kmt);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;           
            baglanti.Close();


        }
        private void MÜŞTERİ_KAYITLARI_Load(object sender, EventArgs e)
        {
            verilerigoster();
          
        }

        private void sil_Click(object sender, EventArgs e)
        {//silme
            baglanti.Open();
            SqlCommand kmt = new SqlCommand("DELETE FROM MÜSTERİtablosu WHERE TC=@TC",baglanti);         
            kmt.Parameters.AddWithValue("@TC", dataGridView1.CurrentRow.Cells[3].Value.ToString());
            kmt.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Silme İşlemi Başarılı", "Silindi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            verilerigoster();
        }

        private void button1_Click(object sender, EventArgs e)
        {// GERİİ(MÜŞTERİ KAYITLARI)
            if (cıkısislemleri.sayi == 1)
            {
                rezervasyon RF = new rezervasyon();
                RF.Show();
                this.Hide();
            }
            else
            {
                cıkısislemleri islem = new cıkısislemleri();
                islem.Show();
                this.Hide();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {// çıkış
            cik ck = new cik(this);// this ile kayıtları form olarak elimizde tutuyoruz.
            ck.Show();  
        }

        private void button2_Click(object sender, EventArgs e)
        {//güncellemee
            baglanti.Open();

            SqlCommand cmd = new SqlCommand("UPDATE MÜSTERİtablosu SET Ad=@AD,SOYAD=@SOYAD,TELEFON=@TELEFON,TC=@TC,CİNSİYET=@CİNSİYET ,YETİSKİN=@YETİSKİN ,COCUK=@COCUK,GİRİS=@GİRİS ,CIKIS=@CIKIS,oda_no=@oda_no  WHERE TC=@TC ", baglanti);
            cmd.Parameters.AddWithValue("@TC", dataGridView1.CurrentRow.Cells[3].Value);
            cmd.Parameters.AddWithValue("@AD", dataGridView1.CurrentRow.Cells[0].Value.ToString());
            cmd.Parameters.AddWithValue("@SOYAD", dataGridView1.CurrentRow.Cells[1].Value.ToString());
            cmd.Parameters.AddWithValue("@TELEFON", dataGridView1.CurrentRow.Cells[2].Value.ToString());
            cmd.Parameters.AddWithValue("@CİNSİYET", dataGridView1.CurrentRow.Cells[4].Value.ToString());
            cmd.Parameters.AddWithValue("@YETİSKİN", dataGridView1.CurrentRow.Cells[5].Value.ToString());
            cmd.Parameters.AddWithValue("@COCUK", dataGridView1.CurrentRow.Cells[6].Value.ToString());
            cmd.Parameters.AddWithValue("@GİRİS", dataGridView1.CurrentRow.Cells[7].Value.ToString());
            cmd.Parameters.AddWithValue("@CIKIS", dataGridView1.CurrentRow.Cells[8].Value.ToString());
            cmd.Parameters.AddWithValue("@oda_no", dataGridView1.CurrentRow.Cells[9].Value.ToString());
            cmd.ExecuteNonQuery();
            baglanti.Close();

            MessageBox.Show("Güncelleme İşlemi Başarılı Oldu...", "Tamam", MessageBoxButtons.OK, MessageBoxIcon.Question);
            verilerigoster();
        }
       
       
        private void button4_Click(object sender, EventArgs e)
        {//oda secimii
            REZERVASYONKAYITLARI.deger = "müşş";
           if (tası==0) { MessageBox.Show("Lütfen bir müşteri seçiniz.."); }
          else
            {
                odaa br = new odaa();
                br.buuton();
                br.Show();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {// oda seçimini kaydet
            baglanti.Open();

            SqlCommand cmd = new SqlCommand("UPDATE MÜSTERİtablosu SET oda_no=@oda_no  WHERE TC=@TC ", baglanti);
            cmd.Parameters.AddWithValue("@TC", dataGridView1.CurrentRow.Cells[3].Value);       
            cmd.Parameters.AddWithValue("@oda_no", dataGridView1.CurrentRow.Cells[9].Value.ToString());
            cmd.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Oda Numarası Kaydedildi");
            verilerigoster();

        }

        private void button6_Click(object sender, EventArgs e)
        {// FATURAA
            if (textBox1.Text == "")
            {
                MessageBox.Show("Lütfen Fiyatı Giriniz.");

            } if (textBox1.Text != "")
            {
                int fiyat = Convert.ToInt32(textBox1.Text);

                DateTime sayı1 = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[8].Value);
                DateTime sayı2 = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[7].Value);
                TimeSpan zaman;
                zaman = sayı1.Subtract(sayı2);
                int toplamgün = Convert.ToInt32(zaman.TotalDays);

                int sayı3 = Convert.ToInt32(dataGridView1.CurrentRow.Cells[5].Value);
                int sayı4 = Convert.ToInt32(dataGridView1.CurrentRow.Cells[6].Value);
                int sonuc1 = (toplamgün * sayı3) * fiyat;
                int sonuc2 = (toplamgün * sayı4) * (fiyat / 2);
                int sonuc = sonuc1 + sonuc2;
                MessageBox.Show("Ödenmesi gereken tutar==>" + sonuc + " TL");
            }
            textBox1.Text = "";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            tası = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value);

           // MessageBox.Show("" + tası);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Char.IsLetter(e.KeyChar) || Char.IsSymbol(e.KeyChar) || Char.IsPunctuation(e.KeyChar) || Char.IsWhiteSpace(e.KeyChar);
        }

       

      
    }
}
