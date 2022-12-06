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
        public static string kullaniciCap = ""; //form3 için gerekli kullanıcı kontrolü @Emre


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
    }
}

