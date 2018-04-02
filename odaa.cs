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
    public partial class odaa : Form
    {
       public bool flag = false;
        public odaa()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=SAMSUNGPC;Initial Catalog=OTEL;Integrated Security=true;");
        public static int id = 1;
        SqlCommand komt = null;
        List<Button> listBtn = new List<Button>();
        List<int> listIndex = new List<int>();
        List<int> doluIndex = new List<int>();
   
        public void doluuu() {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            SqlCommand dolutext = new SqlCommand("Select id from odadurumu where durumu!='bos'",baglanti);
            SqlDataReader dReader = dolutext.ExecuteReader();
            while (dReader.Read())
            {
               doluIndex.Add(int.Parse("" + dReader.GetValue(0)));                 
            }
            baglanti.Close();
        }
        public void textRez()
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            for (int k = 0; k < doluIndex.Count; k++)
            {
                if (id == doluIndex.ElementAt(k))
                {
                  
                    SqlCommand dolutext = new SqlCommand("Select durumu from odadurumu where id='" + id + "' and ref=1", baglanti);
                    if (baglanti.State == ConnectionState.Closed)
                    {
                        baglanti.Open();
                    }
                    SqlDataReader dReader = dolutext.ExecuteReader();
                    while (dReader.Read())
                    {                                              
                        btn.Text = Convert.ToString(dReader.GetValue(0));
                    }
                }

                if (baglanti.State == ConnectionState.Open)
                {
                    baglanti.Close();
                }
            }
        }
        public void yazı(int id)
        {
           
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }

            {
                for (int k = 0; k < doluIndex.Count; k++)
                {
                    if (id == doluIndex.ElementAt(k))
                    {
                        btn.BackColor = Color.Yellow;
                        SqlCommand dolutext = new SqlCommand("Select durumu from odadurumu where id='" + id + "' and ref=0", baglanti);
                        if (baglanti.State == ConnectionState.Closed)
                        {
                            baglanti.Open();
                        }
                        SqlDataReader dReader = dolutext.ExecuteReader();
                        while (dReader.Read())
                        {
                            btn.BackColor = Color.Red;
                            btn.Text = Convert.ToString(dReader.GetValue(0));
                        }                       
                        if (baglanti.State == ConnectionState.Open)
                        {
                            baglanti.Close();
                        } textRez();
                    }
                }
            }
        }
        Button btn = null;
        public void buuton()
        {

            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }    
            id = 1;
            doluuu();
            for (int i = 1; i < 11; i++)
            {
                for (int j = 0; j < 14; j++)
                {
                    btn = new Button();

                    btn.Click += buton_click;
                    btn.Name = "" + (id - 1);
                    btn.BackColor = Color.LawnGreen;
                    btn.Text = "bos";
                    yazı(id);
                       
                        btn.Height = 40;
                        btn.Width = 60;
                        btn.Location = new System.Drawing.Point(60 * i + 150, 40 * j + 100);
                        this.Controls.Add(btn);
                        listBtn.Add(btn);
                        id++;                   

                    if (baglanti.State == ConnectionState.Open)
                    {
                        baglanti.Close();
                    }
                }
            }
        }



        public static int referans;
        private void buton_click(object s, EventArgs e)
        {////////////////////////////////////////////////////////
            baglanti.Open();

            Button btn = s as Button;

            if (btn.BackColor == Color.LawnGreen)
            {
                if (REZERVASYONKAYITLARI.deger != "rezz")
                {
                    btn.BackColor = Color.Red; referans = 0;
                }
                else
                {
                    btn.BackColor = Color.Yellow;
                    referans = 1;
                }
                btn.Text = Convert.ToString(MÜŞTERİ_KAYITLARI.tası); 
                komt = new SqlCommand("update  odadurumu set durumu=@durumu,ref=@ref where id=@id", baglanti);
                komt.Parameters.AddWithValue("@id", int.Parse(btn.Name)+1);
                komt.Parameters.AddWithValue("@durumu", btn.Text);
                komt.Parameters.AddWithValue("@ref", referans);
                komt.ExecuteNonQuery();                
            }
            else
            {
                btn.BackColor = Color.LawnGreen;
                btn.Text = "bos";               
                komt = new SqlCommand("update  odadurumu set durumu=@durumu where id=@id", baglanti);
                komt.Parameters.AddWithValue("@id", int.Parse(btn.Name) + 1);
                komt.Parameters.AddWithValue("@durumu", btn.Text);
                komt.Parameters.AddWithValue("@ref", 0);
                komt.ExecuteNonQuery();
            }

            baglanti.Close();
        }


        private void odalar_Load(object sender, EventArgs e)
        {
         
        }

        }
    }

