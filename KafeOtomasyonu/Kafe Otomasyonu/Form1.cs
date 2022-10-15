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
using System.Security.Cryptography;


namespace Kafe_Otomasyonu
{
    public partial class Form1 : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        DataSet ds;
        SqlDataAdapter da;

        public static string SqlCon = @"Data Source=localhost\SQLEXPRESS;Initial Catalog = Veritabani; Integrated Security = True";//bağlantıları tekrar yapmanıza gerek yok @bledaa


        public Form1()
        {
            InitializeComponent();


        }
       

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (Class1.loginkontrol(textBox1.Text, textBox2.Text))
            {
                MessageBox.Show("GİRİŞ BAŞARILI");
            }
            else
            {
                MessageBox.Show("KULLANICI ADI YA DA ŞİFRE HATALI");
            }//label1 giriş yap butonunun tuşu bu da onu çalıştırıyor.@bleda
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit(); // bu  çarpı işaretinin işlevi kapatıyor basınca @bleda
        }
    }
}

