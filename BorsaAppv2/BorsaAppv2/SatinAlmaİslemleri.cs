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


namespace BorsaAppv2
{
    public partial class SatinAlmaİslemleri : Form
    {
        public SatinAlmaİslemleri()
        {
            InitializeComponent();
        }
        static string constring = "Data Source =.; Initial Catalog = BorsaApp; Integrated Security = True";
        SqlConnection connect = new SqlConnection(constring);

        
        private void button1_Click(object sender, EventArgs e)
        {
            /*string query = "SELECT * FROM Satis_Bilgileri WHERE Urun = '" + UrunAd_txtbox.Text + "' AND Fiyat BETWEEN '" + float.Parse(fiyat_txtbox.Text) + "' AND 0";
            SqlDataAdapter sda = new SqlDataAdapter(query, connect);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            if(dtbl.Rows.Count >= 1)
            {
                MessageBox.Show("Ürün Bulundu.");
            }*/


            connect.Open();
            string tckno="";
            SqlCommand myCommand = new SqlCommand("SELECT * FROM Satis_Bilgileri WHERE AktifKullanici = 1", connect);
            SqlDataReader myReader = myCommand.ExecuteReader();
            while (myReader.Read())
            {

                tckno = myReader["TCKNO"].ToString();

            }
            myReader.Close();

            float odenecekFiyat = float.Parse(fiyat_txtbox.Text);
            float alinacakUrun_Miktar = float.Parse(miktar_txtbox.Text);
            float odenecekPara = odenecekFiyat * alinacakUrun_Miktar;

            if (ParaKontrol(odenecekPara))
            {
                SatinAl(odenecekFiyat,alinacakUrun_Miktar,UrunAd_txtbox.Text,tckno);
            }


        }

        bool ParaKontrol(float odenecekPara) {

            SqlCommand myCommand = new SqlCommand("SELECT * FROM Satis_Bilgileri WHERE AktifKullanici = 1", connect);
            SqlDataReader myReader = myCommand.ExecuteReader();
            while (myReader.Read())
            {

                if (float.Parse(myReader["para"].ToString()) < odenecekPara)
                {
                    MessageBox.Show("Hesapta yeterli paranız bulunmamaktadır !");
                    myReader.Close();
                    connect.Close();
                    return false;
                }

            }
            myReader.Close();
            return true;
        }

        bool SatinAl(float odenecekFiyat, float alinacakUrun_Miktar,string urunAd,string tckno)
        {
            string query = "SELECT * FROM Satis_Bilgileri WHERE Urun = '" + UrunAd_txtbox.Text + "' AND Fiyat BETWEEN 0 AND '" + odenecekFiyat + "'AND Miktar BETWEEN '" + alinacakUrun_Miktar + "' AND 2000";
            SqlCommand myCommand = new SqlCommand(query, connect);
            SqlDataReader myReader = myCommand.ExecuteReader();
            int count = 0;
            
            float fiyat = odenecekFiyat;
            float miktar = alinacakUrun_Miktar;
            float tutar = fiyat * miktar;
            if (myReader.Read())
            {
                string urun = myReader["Urun"].ToString();

                float urunFiyat = float.Parse(myReader["Fiyat"].ToString());



                // MessageBox.Show(myReader["Urun"].ToString() + myReader["Fiyat"].ToString() + myReader["Miktar"].ToString());

                string kayit = "Update Satis_Bilgileri set Miktar=Miktar-'" + alinacakUrun_Miktar + "', Para+='" + odenecekFiyat * miktar + "' where TCKNO='" + myReader["TCKNO"].ToString() + "';" +
                                "Update Satis_Bilgileri set Miktar+='" + alinacakUrun_Miktar + "',Urun='" + myReader["Urun"].ToString() + "', Para=Para -'" + odenecekFiyat * miktar + "' where AktifKullanici= 1";

                fiyat_txtbox.Text = "";
                miktar_txtbox.Text = "";
                UrunAd_txtbox.Text = "";
                MessageBox.Show("Satın alım başarılı !");


                myReader.Close();
                Calistir(kayit);
                GecmiseEkle(urun, miktar, urunFiyat);

            }
            else
            {
                myReader.Close();
                AskidaBirak(query, connect, urunAd, alinacakUrun_Miktar, odenecekFiyat, tckno);

            }




            connect.Close();
            return true;
            
        }

        void Calistir(string kayit)
        {
            SqlCommand komut = new SqlCommand(kayit, connect);
            komut.ExecuteNonQuery();
        }
        

        void GecmiseEkle(string Urun, float Miktar, float Fiyat)
        {
            string kayit3 = "insert into Satis_Gecmis(Tarih,Urun,Miktar,Fiyat) values(@Tarih,@Urun,@Miktar,@Fiyat)";
            DateTime dateTime = DateTime.UtcNow.Date;
            SqlCommand komut2 = new SqlCommand(kayit3, connect);
            komut2.Parameters.AddWithValue("@Tarih", dateTime);
            komut2.Parameters.AddWithValue("@Urun", Urun);
            komut2.Parameters.AddWithValue("@Miktar", Miktar);
            komut2.Parameters.AddWithValue("@Fiyat", Fiyat);
            komut2.ExecuteNonQuery();
        }

        void AskidaBirak(string query , SqlConnection connect,string urunAd, float alinacakUrun_Miktar,float odenecekFiyat,string tckno)
        {
            SqlDataAdapter sda = new SqlDataAdapter(query, connect);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            if (dtbl.Rows.Count == 0)
            {
                string kayit_Aski = "Update Satis_Bilgileri set UrunAski_Satis = '" + urunAd + "', MiktarAski_Satis='" + alinacakUrun_Miktar + "', FiyatAski_Satis= +'" + odenecekFiyat + "' where TCKNO='" + tckno + "';";
                Calistir(kayit_Aski);
                MessageBox.Show("İstenilen şartlarda ürün bulunamadığı için talebiniz askıya alındı ");

            }
        }
        private void SatinAlmaİslemleri_Load(object sender, EventArgs e)
        {

        }
    }
}
