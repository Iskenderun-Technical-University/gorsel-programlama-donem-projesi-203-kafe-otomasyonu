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
using System.Data.SqlClient;

namespace Kafe_Otomasyonu
{
    public partial class Form4 : Form
    {
        SqlConnection con,con1;
        SqlCommand cmd,cmd1;
        SqlDataReader dr;
        DataSet ds;
        SqlDataAdapter da;

        public static string SqlCon = @"Data Source=localhost\SQLEXPRESS;Initial Catalog = Veritabani; Integrated Security = True";//bağlantıları tekrar yapmanıza gerek yok @bleda

        public Form4()
        {
            InitializeComponent();

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
            //sipariş eklemek için gerekli komutlar @bleda

        }



        private void Form4_Load(object sender, EventArgs e)
        {
            Class1.GridDoldur(dataGridView1, "select * from urun_bilgi");
            Class1.GridDoldur2(dataGridView2, "select * from siparis_tablo");
            //datagrid tablolarını göstermek için classtan çektiğim komutlar @bleda

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
            
            con = new SqlConnection(SqlCon);
            string sql = "delete from siparis_tablo where siparis_adi=@s_ad and siparis_adet=@s_adet";
            cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@s_ad", textBox3.Text);
            cmd.Parameters.AddWithValue("@s_adet", textBox2.Text);
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            con.Close();
            Class1.GridDoldur2(dataGridView2, "select * from siparis_tablo");
            //sipariş silmek için yaptığım komutlar @bleda




        }

        private void dataGridView2_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox3.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            textBox4.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            textBox2.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
            textBox7.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();//burada datagrid tablosunu textboxlara aktarmak için yaptım @bleda
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }


       

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }



        private void label6_Click(object sender, EventArgs e)
        {

        }
        /*
  con = new SqlConnection(SqlCon);
  string sqli ="uptade siparis_tablo set siparis_adet=@s_adet where siparis_id=@s_id and siparis_adi=@s_ad";
  cmd = new SqlCommand();
  cmd.Parameters.AddWithValue("@s_id",textBox7.Text);
  cmd.Parameters.AddWithValue("@s_adet", textBox2.Text);
  cmd.Parameters.AddWithValue("@s_ad", textBox3.Text);
  con.Open();
  cmd.Connection = con;
  cmd.CommandText = sqli;
  cmd.ExecuteNonQuery();
  con.Close();
  Class1.GridDoldur2(dataGridView2, "select * from siparis_tablo");
  burası updtate işlemi için sıra bana gelince halledicem*/
    }
}


