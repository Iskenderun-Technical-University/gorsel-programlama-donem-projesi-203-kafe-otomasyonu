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


namespace Kafe_Otomasyonu
{
    public partial class Form3 : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        DataSet ds;
        SqlDataAdapter da;

        public static string SqlCon = @"Data Source=localhost\SQLEXPRESS;Initial Catalog = Veritabani; Integrated Security = True";

        public int sonuc = 0;
        public Form3()
        {
            InitializeComponent();
        }

        public bool EskiSifreKontrol() //eski şifrenin kontrolü için bağlantılar @emre
        {
            string sorgu = "select Sifre from giris_ve_kayıt_veritabanı where user_nick=@user and user_password=@password";
            con = new SqlConnection(SqlCon);
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@user", Class1.kullaniciCap );
            cmd.Parameters.AddWithValue("@password", Class1.MD5Sifrele(texBox_eskisifre.Text));

            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read()) //şifre ve user okunuyorsa işlemleri yap.@emre
            {
                con = new SqlConnection(SqlCon);
                string sql = "update giris_ve_kayıt_veritabanı set Sifre='" + Class1.MD5Sifrele(textBox_yenisifre.Text) + "'";
                cmd = new SqlCommand();

                cmd.Connection = con;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Şifre Değişti!!");
                Label_mesaj.Text = "Şifre Değişti!!";
                con.Close(); 
                return true;
   

            }
            else
            {
                Label_mesaj.Text = "Eski şifreniz hatalı..";
                CaptchaOlustur();
                con.Close();
                return false;
            }
        }

        public void CaptchaOlustur() //captcha oluşturmak için bir fonksiyon. @emre
        {
            Random r = new Random();
            int ilk = r.Next(0, 100);
            int ikinci = r.Next(0, 100);
            sonuc = ilk + ikinci;  //yukarıda global olarak tanımlandı.@emre
            Label_captcha.Text = ilk.ToString() + "+" + ikinci.ToString() + "=";
            Label_mesaj.Text = "";
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            CaptchaOlustur();
        }


        private void label1_Click(object sender, EventArgs e) //şifre değiştirme.@emre
        {
            if (textBox_captcha.Text == sonuc.ToString())
            {
                if (textBox_yenisifre.Text == textBox_yenisifretekrar.Text)
                {
                    EskiSifreKontrol();
                }
                else
                {
                    Label_mesaj.Text = "Yeni şifre tekrarı yalnış...";
                    CaptchaOlustur();
                }

            }
            else
            {
                Label_mesaj.Text = "Güvenlik sorusu yanlış...";
                CaptchaOlustur();
            }
        }

        private void Label_iptal_Click(object sender, EventArgs e)
        {
            //daha sonra önceki formlara dönme işlemi yazılacak. @emre
        }

        private void Label_captcha_Click(object sender, EventArgs e)
        {

        }
    }
}
