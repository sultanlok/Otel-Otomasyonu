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
    public partial class REZERVASYONKAYITLARI : Form
    {
          public REZERVASYONKAYITLARI(){            InitializeComponent();
           
        }
          public static string deger = "rezz";
        SqlConnection baglanti = new SqlConnection("Data Source=SAMSUNGPC;Initial Catalog=OTEL;Integrated Security=true;");
        private void verilerigoster()
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }

            SqlCommand kmt = new SqlCommand("select * from REZERVASYON", baglanti);    
            SqlDataAdapter da = new SqlDataAdapter(kmt);            
            DataTable dt = new DataTable();
            da.Fill(dt);            
            dataGridView1.DataSource = dt;            
            baglanti.Close();        
              
             
        }

        private void Kayıtlar_Load(object sender, EventArgs e)
        {
            verilerigoster();
        }
        
        private void SİL_Click(object sender, EventArgs e)
        {
             baglanti.Open();
             SqlCommand kmt = new SqlCommand("DELETE FROM REZERVASYON WHERE TC_KİMLİK_NO=@TC_KİMLİK_NO",baglanti);               
            kmt.Parameters.AddWithValue("@TC_KİMLİK_NO", dataGridView1.CurrentRow.Cells[3].Value.ToString());
            kmt.ExecuteNonQuery();
           baglanti.Close();
            MessageBox.Show("Silme İşlemi Başarılı", "Silindi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            verilerigoster();
        }

        private void button1_Click(object sender, EventArgs e)
        {//KAYITLARDA GERİ
            if (cıkısislemleri.sayi == 1)
            {
                rezervasyon RF = new rezervasyon();
                RF.Show();
                this.Hide();
            }
            else { cıkısislemleri islem = new cıkısislemleri();
            islem.Show();
            this.Hide();
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {//KAYITLARDA ÇIKIŞ
            cik ck = new cik(this);// this ile kayıtları form olarak elimizde tutuyoruz.
            ck.Show();       
        
        }

        private void button2_Click(object sender, EventArgs e)
        {// güncelle
            baglanti.Open();

            SqlCommand cmd = new SqlCommand("UPDATE  REZERVASYON SET Ad=@AD,SOYAD=@SOYAD,TELEFON_NO=@TELEFON_NO,TC_KİMLİK_NO=@TC_KİMLİK_NO,CİNSİYET=@CİNSİYET ,YETİSKİN=@YETİSKİN ,COCUK=@COCUK,GİRİS_TARİHİ=@GİRİS_TARİHİ ,CIKIS_TARİHİ=@CIKIS_TARİHİ  WHERE TC_KİMLİK_NO=@TC_KİMLİK_NO ", baglanti);
 
                // Fare ile seçilmiş satırın değeri @id'ye aktarılır:
 cmd.Parameters.AddWithValue("@TC_KİMLİK_NO ",dataGridView1.CurrentRow.Cells[3].Value);
 
                // TextBox'lardan alınan bilgiler etiketlere, oradan da sorguya gönderilir:
 cmd.Parameters.AddWithValue("@AD", dataGridView1.CurrentRow.Cells[0].Value.ToString());
 cmd.Parameters.AddWithValue("@SOYAD", dataGridView1.CurrentRow.Cells[1].Value.ToString());
 cmd.Parameters.AddWithValue("@TELEFON_NO", dataGridView1.CurrentRow.Cells[2].Value.ToString());
 //cmd.Parameters.AddWithValue("@TC_KİMLİK_NO", dataGridView1.CurrentRow.Cells[3].Value);
 cmd.Parameters.AddWithValue("@CİNSİYET", dataGridView1.CurrentRow.Cells[4].Value.ToString());
 cmd.Parameters.AddWithValue("@YETİSKİN", dataGridView1.CurrentRow.Cells[5].Value.ToString());
 cmd.Parameters.AddWithValue("@COCUK", dataGridView1.CurrentRow.Cells[6].Value.ToString());
 cmd.Parameters.AddWithValue("@GİRİS_TARİHİ", dataGridView1.CurrentRow.Cells[7].Value.ToString());
 cmd.Parameters.AddWithValue("@CIKIS_TARİHİ", dataGridView1.CurrentRow.Cells[8].Value.ToString());
 
                     
                // Sorgu çalıştırılır:
                cmd.ExecuteNonQuery();
 
                // Bağlantı kapatılır:
                baglanti.Close();
                MessageBox.Show("Güncellendi.");
                verilerigoster();
             }

        private void button4_Click(object sender, EventArgs e)
        {///oda seçimii
            if (MÜŞTERİ_KAYITLARI.tası == 0) { MessageBox.Show("Lütfen bir müşteri seçiniz.."); }
            else
            {
                odaa br = new odaa();
                br.buuton();
                br.Show();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MÜŞTERİ_KAYITLARI.tası = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value);
        }

        private void button5_Click(object sender, EventArgs e)
        {//////müşterilere kaydet
            baglanti.Open();
             if (MÜŞTERİ_KAYITLARI.tası == 0) { MessageBox.Show("Lütfen bir müşteri seçiniz.."); }else{
            SqlCommand kmt = new SqlCommand("insert into MÜSTERİtablosu( AD,SOYAD,TELEFON,TC,CİNSİYET,YETİSKİN,COCUK,GİRİS,CIKIS,oda_no) select AD,SOYAD,TELEFON_NO,TC_KİMLİK_NO,CİNSİYET,YETİSKİN,COCUK,GİRİS_TARİHİ,CIKIS_TARİHİ,oda_no from REZERVASYON where TC_KİMLİK_NO ='" + MÜŞTERİ_KAYITLARI.tası + "'", baglanti);
             kmt.ExecuteNonQuery();
             MessageBox.Show("müşteri kaydı yapıldı :)");            
             SqlCommand sil = new SqlCommand("DELETE FROM REZERVASYON WHERE TC_KİMLİK_NO='" + MÜŞTERİ_KAYITLARI.tası + "'", baglanti);
             kmt.Parameters.AddWithValue("@TC_KİMLİK_NO", dataGridView1.CurrentRow.Cells[3].Value.ToString());
             sil.ExecuteNonQuery();
             MessageBox.Show("müşteri kaydı yapıldıgı için rezervasyon silindi .!");}
            baglanti.Close();           
            verilerigoster();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
             SqlCommand cmd = new SqlCommand("UPDATE REZERVASYON SET oda_no=@oda_no  WHERE TC_KİMLİK_NO='" + MÜŞTERİ_KAYITLARI.tası + "'", baglanti);
            cmd.Parameters.AddWithValue("@TC_KİMLİK_NO", dataGridView1.CurrentRow.Cells[3].Value);
                cmd.Parameters.AddWithValue("@oda_no", dataGridView1.CurrentRow.Cells[9].Value.ToString());
                cmd.ExecuteNonQuery();               
                MessageBox.Show("Oda Numarası Kaydedildi");
                verilerigoster();
                if (baglanti.State == ConnectionState.Open)
                {
                    baglanti.Close();
                
            }
        }
 

 
            
        }
        }
 

        

       

        
    
