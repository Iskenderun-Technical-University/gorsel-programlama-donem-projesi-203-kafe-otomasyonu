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
using System.Security.Cryptography;

namespace Kafe_Otomasyonu
{
    
    public partial class Form4 : Form
    {
        SqlConnection con;
        SqlCommand cmd,cmd1,cmd2;
        SqlDataReader dr;
        DataSet ds;
        SqlDataAdapter da;
        public static int id;
        

        public static string SqlCon = @"Data Source=localhost\SQLEXPRESS;Initial Catalog = Veritabani; Integrated Security = True";//bağlantıları tekrar yapmanıza gerek yok @bleda
        public int sonuc = 0; //captcha sonuç fonksiyonu @emre
        public Form4()
        {
            InitializeComponent();

        }
        public void eskisifrekontrol() //eski şifrenin kontrolü için bağlantılar @emre
        {
            string sorgu = "select user_password from giris_ve_kayıt_veritabanı where user_nick=@user and user_password=@password";
            con = new SqlConnection(SqlCon);
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@user", Form1.kullanicimSession );
            cmd.Parameters.AddWithValue("@password", Class1.MD5Sifrele(textBox9.Text));



            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read()) //şifre ve user okunuyorsa işlemleri yap.@emre
            {
                con = new SqlConnection(SqlCon);
                string sql = "update giris_ve_kayıt_veritabanı set user_password='" + Class1.MD5Sifrele(textBox10.Text) + "'";
                cmd = new SqlCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Şifre Değişti!!");
                label10.Text = "Şifre Değişti!!";
                con.Close();
                
            }
            else
            {
                label10.Text = "Eski şifreniz eksik veya hatalı..";
                captchaolustur();
                con.Close();
            }
        }
        public void AdetAzaltma()
        {
            //Sipariş oluşturmak için aritmetik işlemler. @Kemal
            int ilk = Convert.ToInt32(textBox2.Text);
            int iki = Convert.ToInt32(textBox1.Text);
            sonuc = ilk - iki;
            textBox6.Text = sonuc.ToString();
        }
        public void Siparisİptal()
        {
            //Sipariş iptali için aritmetik işlemler. @Kemal
            int ilk = Convert.ToInt32(textBox2.Text);
            int iki = Convert.ToInt32(textBox15.Text);
            sonuc = ilk + iki;
            textBox16.Text = sonuc.ToString();
            
      
        }

        public void captchaolustur()
        {
            //Captcha oluşturma @emre
            Random r = new Random();
            int ilk = r.Next(0, 50);
            int iki = r.Next(0, 50);
            sonuc = ilk + iki;
            label9.Text = ilk.ToString() + "+" + iki.ToString() + "=";
            textBox12.Clear();
            
        }


        private void button1_Click(object sender, EventArgs e)
        {

            double sayi1 = Convert.ToDouble(textBox1.Text);
            double sayi2 = Convert.ToDouble(textBox4.Text);
            textBox5.Text = Convert.ToString(sayi1 * sayi2);
            con = new SqlConnection(SqlCon);
            string sql = "insert into siparis_tablo(siparis_adi,siparis_adet,siparis_fiyat,siparis_toplam) values(@s_ad,@s_adet,@s_birim,@s_toplam)";
            cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@s_ad", textBox3.Text);
            cmd.Parameters.AddWithValue("@s_adet", textBox1.Text);
            cmd.Parameters.AddWithValue("@s_birim", textBox4.Text);
            cmd.Parameters.AddWithValue("@s_toplam", textBox5.Text);
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            con.Close();
            Class1.GridDoldur2(dataGridView2, "select * from siparis_tablo");

            con = new SqlConnection(SqlCon);
            string sqli = "update urun_bilgi set urun_adet=@u_adet where urun_id=@u_id ";
            cmd1 = new SqlCommand();
            cmd1.Parameters.AddWithValue("@u_id", Convert.ToInt32(textBox7.Text));
            cmd1.Parameters.AddWithValue("@u_adet", Convert.ToInt32(textBox2.Text));
            con.Open();
            cmd1.Connection = con;
            cmd1.CommandText = sqli;
            cmd1.ExecuteNonQuery();
            con.Close();
            Class1.GridDoldur2(dataGridView2, "select * from urun_bilgi");
            //sipariş eklemek ve sipariş gücellemek için gerekli komutlar @bleda
            AdetAzaltma();

            con = new SqlConnection(SqlCon);
            string sqlii = "update urun_bilgi set urun_adet=@u_adet where urun_id=@uu_id ";
            cmd2 = new SqlCommand();
            cmd2.Parameters.AddWithValue("@uu_id", Convert.ToInt32(textBox7.Text));
            cmd2.Parameters.AddWithValue("@u_adet", Convert.ToInt32(textBox6.Text));
            con.Open();
            cmd2.Connection = con;
            cmd2.CommandText = sqlii;
            cmd2.ExecuteNonQuery();
            con.Close();
            Class1.GridDoldur(dataGridView1, "select * from urun_bilgi");
            //Ürün tablosundan verilen sipariş kadar azaltmak için @Bleda


        }



        private void Form4_Load(object sender, EventArgs e)
        {
            Class1.GridDoldur(dataGridView1, "select * from urun_bilgi");
            Class1.GridDoldur2(dataGridView2, "select * from siparis_tablo");
            //datagrid tablolarını göstermek için classtan çektiğim komutlar @bleda

            label10.Text = "";
            captchaolustur();
           

        }

        private void dataGridView2_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox13.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            textBox14.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            textBox15.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();

            // burada datagrid tablosunu textboxlara aktarmak için yaptım @bleda




        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            // burada datagrid tablosunu textboxlara aktarmak için yaptım @bleda

        }

       

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Siparisİptal();
            con = new SqlConnection(SqlCon);
            string sqli = "update urun_bilgi set urun_adet=@u_a where urun_id=@u_id";
            cmd1 = new SqlCommand();
            con.Open();
            cmd1.Parameters.AddWithValue("@u_id", textBox7.Text);
            cmd1.Parameters.AddWithValue("@u_a", textBox14.Text);
            cmd1.Connection = con;
            cmd1.CommandText = sqli;
            cmd1.ExecuteNonQuery();
            con.Close();
            Class1.GridDoldur(dataGridView1, "select * from urun_bilgi");

            con = new SqlConnection(SqlCon);
            string sql = "delete from siparis_tablo where siparis_id=@s_id and siparis_adi=@s_ad";
            cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@s_id", textBox13.Text);
            cmd.Parameters.AddWithValue("@s_ad", textBox14.Text);
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            con.Close();
            Class1.GridDoldur2(dataGridView2, "select * from siparis_tablo");
            //sipariş silmek için yaptığım komutlar @bleda

   

        }



        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {  //yeni şifre ve tekrarının kontrolü. @emre
            label10.Text = "";
            if(textBox12.Text == sonuc.ToString())
            {
                if(textBox10.Text==textBox11.Text)
                {
                    eskisifrekontrol();
                }
                else
                {
                    label10.Text = "Yeni şifre ve tekrarı aynı değil..";
                    captchaolustur();
                }
            }
            else
            {
                label10.Text = "Captcha hatalı girildi..";
                captchaolustur();
            }
        }

        private void label12_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
           
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            if (textBox8.Text != "")//Tabloları inner join ile birbirine bağladık. @Kemal
            {
                string sorgu = "select satis_tablo.satıs_id, giris_ve_kayıt_veritabanı.user_nick,siparis_tablo.siparis_adi,siparis_tablo.siparis_fiyat,siparis_tablo.siparis_adet,siparis_tablo.siparis_toplam from satis_tablo INNER join giris_ve_kayıt_veritabanı ON satis_tablo.user_id=giris_ve_kayıt_veritabanı.user_id INNER join siparis_tablo ON satis_tablo.siparis_id=siparis_tablo.siparis_id where giris_ve_kayıt_veritabanı.user_nick like '%"+textBox8.Text+"%'";
                Class1.GridDoldur4(dataGridView3,sorgu);
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            con = new SqlConnection(SqlCon); //İnner joint ile bağladığımız tablolardan satış tablosunu dolduran kod bloğu. @Kemal
            string sql = "insert into satis_tablo(user_id,siparis_id) values(" + id + ","+Convert.ToInt32(textBox13.Text)+")";
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }



        private void label6_Click(object sender, EventArgs e)
        {

        }
        
  
    }
}


