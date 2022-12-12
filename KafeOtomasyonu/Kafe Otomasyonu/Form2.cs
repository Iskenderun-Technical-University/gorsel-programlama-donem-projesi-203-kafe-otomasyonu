using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Kafe_Otomasyonu
{
    public partial class Form2 : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        DataSet ds;
        SqlDataAdapter da;

        public static string SqlCon = "Data Source=localhost\\SQLEXPRESS;Initial Catalog = Veritabani; Integrated Security = True"; //bağlantı için gerekli komutlar @Kemal

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void KullaniciAdi_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(SqlCon); //Giriş için gerekli sql bağlantısı @Kemal
            string sql = "insert into giris_ve_kayıt_veritabanı(user_nick, user_password, user_mail, user_datetime) values (@user, @pass, @mail, @datetime)";
            cmd=new SqlCommand();
            cmd.Parameters.AddWithValue("@user", KullaniciAdi.Text);
            cmd.Parameters.AddWithValue("@pass", Class1.MD5Sifrele(Sifre.Text));
            cmd.Parameters.AddWithValue("@mail", Email.Text);
            cmd.Parameters.AddWithValue("@datetime", DateTime.Now);

            con.Open();
            cmd.Connection=con;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            con.Close();

            
            
        }

        private void Email_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
    }
}
