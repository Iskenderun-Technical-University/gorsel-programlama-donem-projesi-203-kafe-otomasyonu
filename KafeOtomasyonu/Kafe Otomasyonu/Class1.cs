using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Security.Cryptography;


namespace Kafe_Otomasyonu
{
    internal class Class1

    {
        static SqlConnection con;
        static SqlCommand cmd;
        static SqlDataReader dr;
        System.Data.DataSet ds;

        public static string SqlCon = @"Data Source=localhost\SQLEXPRESS;Initial Catalog = Veritabani; Integrated Security = True";
        public static string kullaniciCap = ""; //form3 için gerekli kullanıcı kontrolü @emre


        public static string MD5Sifrele(string sifrelenecekMetin)//burası md5 şifreleme için oluşturduğum class @bleda
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] dizi = Encoding.UTF8.GetBytes(sifrelenecekMetin);
            dizi = md5.ComputeHash(dizi);
            StringBuilder sb = new StringBuilder();
            foreach (byte item in dizi)
                sb.Append(item.ToString("x2").ToLower());
            return sb.ToString();


        }
        public static bool loginkontrol(string user_nick, string pass)//login kontrol etmek için oluşturduğum sınıf @bleda
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
    }
}

