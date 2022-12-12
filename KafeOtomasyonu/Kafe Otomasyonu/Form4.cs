﻿using System;
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
        SqlConnection con,con1;
        SqlCommand cmd,cmd1;
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
            string sqli = "update siparis_tablo set siparis_adet=@s_adet where siparis_id=@s_id ";
            cmd1 = new SqlCommand();
            cmd1.Parameters.AddWithValue("@s_id", Convert.ToInt32(textBox7.Text));
            cmd1.Parameters.AddWithValue("@s_adet", Convert.ToInt32(textBox2.Text));
            con.Open();
            cmd1.Connection = con;
            cmd1.CommandText = sqli;
            cmd1.ExecuteNonQuery();
            con.Close();
            Class1.GridDoldur2(dataGridView2, "select * from siparis_tablo");
            //sipariş eklemek ve sipariş gücellemek için gerekli komutlar @bleda

        }



        private void Form4_Load(object sender, EventArgs e)
        {
            Class1.GridDoldur(dataGridView1, "select * from urun_bilgi");
            Class1.GridDoldur2(dataGridView2, "select * from siparis_tablo");
            //datagrid tablolarını göstermek için classtan çektiğim komutlar @bleda

            label10.Text = "";
            captchaolustur();
           

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

        private void button3_Click(object sender, EventArgs e)
        {
           /* con = new SqlConnection(SqlCon);
            string sqli = "update siparis_tablo set siparis_adet=@s_adet where siparis_id=@s_id ";
            cmd1 = new SqlCommand();
           cmd1.Parameters.AddWithValue("@s_id", Convert.ToInt32(textBox7.Text));
            cmd1.Parameters.AddWithValue("@s_adet",Convert.ToInt32(textBox2.Text));
            con.Open();
            cmd1.Connection = con;
            cmd1.CommandText = sqli;
            cmd1.ExecuteNonQuery();
            con.Close();
            Class1.GridDoldur2(dataGridView2, "select * from siparis_tablo");
           buraya sakın bulaşmayın dhgasgd @bleda */ 
            
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show(id.ToString());
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

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }



        private void label6_Click(object sender, EventArgs e)
        {

        }
        
  
    }
}


