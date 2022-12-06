using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Kafe_Otomasyonu
{
    public partial class Form5 : Form
    {
        SqlConnection con, con1;
        SqlCommand cmd, cmd1;
        SqlDataReader dr;
        DataSet ds;
        SqlDataAdapter da;

        public static string SqlCon = @"Data Source=localhost\SQLEXPRESS;Initial Catalog = Veritabani; Integrated Security = True";//bağlantıları tekrar yapmanıza gerek yok @Kemal





        private void button8_Click(object sender, EventArgs e)// Burası adminin sql tablosuna kullanıcı eklemek için @Kemal
        {
            con = new SqlConnection(SqlCon); //Giriş için gerekli sql bağlantısı @Kemal
            string sql = "insert into giris_ve_kayıt_veritabanı(user_nick, user_password, user_mail, user_datetime) values (@user, @pass, @mail, @datetime)";
            cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@user", textBox7.Text);
            cmd.Parameters.AddWithValue("@pass", Class1.MD5Sifrele(textBox6.Text));
            cmd.Parameters.AddWithValue("@mail", textBox5.Text);
            cmd.Parameters.AddWithValue("@datetime", DateTime.Now);
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            con.Close();
            Class1.GridDoldur3(dataGridView3, "select * from giris_ve_kayıt_veritabanı");

        }

        private void button6_Click(object sender, EventArgs e)//Burda textboxları temizledim @Kemal
        {
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            dateTimePicker2.Value = DateTime.Now;
        }

        private void button7_Click(object sender, EventArgs e)// Burası sql tablosundan kullanıcı silmek için gerekli kod @Kemal
        {
            con = new SqlConnection(SqlCon); //Giriş için gerekli sql bağlantısı @Kemal
            string sql = "delete from giris_ve_kayıt_veritabanı where user_nick=@user and user_password=@pass";
            cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@user", textBox7.Text);
            cmd.Parameters.AddWithValue("@pass", textBox6.Text);
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            con.Close();
            Class1.GridDoldur3(dataGridView3, "select * from giris_ve_kayıt_veritabanı");

        }

        private void button5_Click(object sender, EventArgs e)//Burada sql tablosunda Admin tarafından kullanıcı bilgisi güncellemek için @Kemal
        {
            con = new SqlConnection(SqlCon); //Giriş için gerekli sql bağlantısı @Kemal
            string sql = "update giris_ve_kayıt_veritabanı set user_password='" + Class1.MD5Sifrele(textBox6.Text) + "' where user_nick='" + textBox7.Text + "'and user_id=" + textBox8.Text + "";
            cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@user", textBox7.Text);
            cmd.Parameters.AddWithValue("@pass", textBox6.Text);
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            con.Close();
            Class1.GridDoldur3(dataGridView3, "select * from giris_ve_kayıt_veritabanı");

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)// Data Gride sqldeki kullanıcı tablosunu eklemek için @Kemal
        {
            textBox8.Text = dataGridView3.CurrentRow.Cells[0].Value.ToString();
            textBox7.Text = dataGridView3.CurrentRow.Cells[1].Value.ToString();
            textBox6.Text = dataGridView3.CurrentRow.Cells[2].Value.ToString();
            textBox5.Text = dataGridView3.CurrentRow.Cells[3].Value.ToString();

            dateTimePicker2.Text = dataGridView3.CurrentRow.Cells[4].Value.ToString();
        }

        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            Class1.GridDoldur3(dataGridView3, "select * from giris_ve_kayıt_veritabanı");

        }
    }
}
