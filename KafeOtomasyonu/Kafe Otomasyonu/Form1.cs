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
        public static string kullanicimSession = ""; //giriş yapan personel tekrar kullanıcı adı yazmasın diye yazdım. @emre

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
                Form4.id = Class1.PersonelİdAl(textBox1.Text, textBox2.Text); //form1 e girilen personelin ıd sini form4 e attık. @emre
               
                this.Hide();
                kullanicimSession = textBox1.Text;
                Form4 form4 = new Form4();
                form4.Show();

            }
            else if(Class1.adminloginkontrol(textBox1.Text,textBox2.Text))//admin login durumunu kontrol etme @Bleda
            {
                MessageBox.Show("GİRİŞ BAŞARILI");
                Form5 form5 = new Form5();
                form5.Show();
                this.Hide();
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

        private void label2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();
                
        }
    }
}

