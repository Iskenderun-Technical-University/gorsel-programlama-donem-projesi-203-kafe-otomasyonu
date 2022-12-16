using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Windows.Forms;


namespace Kafe_Otomasyonu
{
    internal class Class1

    {
        static SqlConnection con;
        static SqlCommand cmd;
        static SqlDataReader dr;
        static System.Data.DataSet ds;
        static SqlDataAdapter da;

        public static string SqlCon = @"Data Source=localhost\SQLEXPRESS;Initial Catalog = Veritabani; Integrated Security = True";
        //public static string kullaniciCap = ""; //form3 için gerekli kullanıcı kontrolü @Emre


        public static string MD5Sifrele(string sifrelenecekMetin)//burası md5 şifreleme için oluşturduğum class @Bleda
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] dizi = Encoding.UTF8.GetBytes(sifrelenecekMetin);
            dizi = md5.ComputeHash(dizi);
            StringBuilder sb = new StringBuilder();
            foreach (byte item in dizi)
                sb.Append(item.ToString("x2").ToLower());
            return sb.ToString();


        }
        public static bool loginkontrol(string user_nick, string pass)//login kontrol etmek için oluşturduğum sınıf @Bleda
        {

            string sorgu = "Select*From giris_ve_kayıt_veritabanı where user_nick=@user and user_password=@pass ";
            con = new SqlConnection(SqlCon);
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@user", user_nick);
            cmd.Parameters.AddWithValue("@pass", Class1.MD5Sifrele(pass));
            con.Open();
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
                return true;



            }
            else
            {

                con.Close();
                return false;

            }
        }
        public static DataGridView GridDoldur(DataGridView datagrid, string sqlsorgu)
        {
            con = new SqlConnection(SqlCon);
            da = new SqlDataAdapter("select * from urun_bilgi", con);
            ds = new System.Data.DataSet();
            con.Open();
            da.Fill(ds, sqlsorgu);
            datagrid.DataSource = ds.Tables[sqlsorgu];
            con.Close();
            return datagrid;//1.datagrid tablo komutları @Bleda
        }
        public static DataGridView GridDoldur2(DataGridView datagrid, string sqlsorgu)
        {
            con = new SqlConnection(SqlCon);
            da = new SqlDataAdapter("select * from siparis_tablo", con);
            ds = new System.Data.DataSet();
            con.Open();
            da.Fill(ds, sqlsorgu);
            datagrid.DataSource = ds.Tables[sqlsorgu];
            con.Close();
            return datagrid;
            //2.datagrid tablo komutları@Bleda
        }

        public static DataGridView GridDoldur3(DataGridView datagrid, string sqlsorgu)
        {
            con = new SqlConnection(SqlCon);
            da = new SqlDataAdapter("select * from giris_ve_kayıt_veritabanı", con);
            ds = new System.Data.DataSet();
            con.Open();
            da.Fill(ds, sqlsorgu);
            datagrid.DataSource = ds.Tables[sqlsorgu];
            con.Close();
            return datagrid;//3.datagrid tablo komutları @Kemal
        }
        public static DataGridView GridDoldur4(DataGridView datagrid, string sqlsorgu)
        {
            con = new SqlConnection(SqlCon);
            da = new SqlDataAdapter(sqlsorgu, con);
            ds = new System.Data.DataSet();
            con.Open();
            da.Fill(ds, sqlsorgu);
            datagrid.DataSource = ds.Tables[sqlsorgu];
            con.Close();
            return datagrid;//3.datagrid tablo komutları @Kemal
        }

        public static int PersonelİdAl(String kullaniciadi, String sifre) //personel id tutmak için bir fonksiyon @emre
        {
            int id = 0;
            String sqlsorgu = "select user_id from giris_ve_kayıt_veritabanı where user_nick=@kullaniciadi AND user_password=@sifre";
            con = new SqlConnection(SqlCon);
            cmd = new SqlCommand(sqlsorgu, con);
            cmd.Parameters.AddWithValue("@kullaniciadi", kullaniciadi);
            cmd.Parameters.AddWithValue("@sifre", MD5Sifrele(sifre));
            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                id = Convert.ToInt32(dr[0]);
            }
            return id;
        }
        public static bool adminloginkontrol(string admmin_nick, string apass)//admin girişini kontrol etmek için oluşturduğum sınıf @Bleda
        {

            string sorgu = "Select*From admin_giris where admmin_nick=@auser and admin_password=@apass ";
            con = new SqlConnection(SqlCon);
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@auser", admmin_nick);
            cmd.Parameters.AddWithValue("@apass", apass);
            con.Open();
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
                return true;



            }
            else
            {

                con.Close();
                return false;

            }
        }
    }
}

