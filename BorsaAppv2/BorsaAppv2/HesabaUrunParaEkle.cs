using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BorsaAppv2
{
        public class HesabaUrunParaEkle
    {
        static string constring = "Data Source =.; Initial Catalog = BorsaApp; Integrated Security = True";
        SqlConnection connect = new SqlConnection(constring);
        
        

        public void SatinAl(string UrunAdi, float Fiyat, float Miktar)
        {
            connect.Open();
            string kayit = "Update Satis_Bilgileri set MiktarAski_Admin='" + Miktar + "', FiyatAski_Admin='" + Fiyat + "', UrunAski_Admin='" + UrunAdi + "' where AktifKullanici='" + 1 + "'";
            SqlCommand komut = new SqlCommand(kayit, connect);
            komut.ExecuteNonQuery();
            connect.Close();
        }

        public void ParaEkle(float Para, bool doviz)
        {
            
            connect.Open();
            
            if (doviz)
            {

                Para *=99F;
                Para /= 100F;
            }
            var xpara = Para.ToString().Replace(",", ".");
            
            string kayit = "Update Satis_Bilgileri set ParaAski_Admin+='" + xpara + "' where AktifKullanici=1";

            SqlCommand komut = new SqlCommand(kayit, connect);
            komut.ExecuteNonQuery();
            connect.Close();
        }





    }
}
