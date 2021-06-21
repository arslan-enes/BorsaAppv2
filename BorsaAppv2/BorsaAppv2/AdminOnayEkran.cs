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
    public partial class AdminOnayEkran : Form
    {
        public AdminOnayEkran()
        {
            InitializeComponent();
        }
        static string constring = "Data Source =.; Initial Catalog = BorsaApp; Integrated Security = True";
        SqlConnection connect = new SqlConnection(constring);

        List<string> onaylar = new List<string>()
        {
            

        };
        private void AdminOnayEkran_Load(object sender, EventArgs e)
        {

            string query = "SELECT * FROM Satis_Bilgileri WHERE ParaAski_Admin !=0 OR UrunAski_Admin IS NOT NULL";
           
            SqlDataAdapter sda = new SqlDataAdapter(query, connect);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            for(int i=0; i<dtbl.Rows.Count; i++)
            {


                if (!string.IsNullOrEmpty(dtbl.Rows[i][9].ToString()))
                {
                    onaylar.Add(dtbl.Rows[i][1].ToString() + " " + dtbl.Rows[i][9].ToString()+" TL");
                }
                else if (!string.IsNullOrEmpty(dtbl.Rows[i][6].ToString()))
                {
                    onaylar.Add(dtbl.Rows[i][1].ToString() +" "+ dtbl.Rows[i][6].ToString() + " KG "+ dtbl.Rows[i][7].ToString() +" " + dtbl.Rows[i][8].ToString() +" TL" );
                }


            }
            
            listBox1.DataSource = onaylar;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            string onaylanan = listBox1.SelectedItem.ToString();
            string[] onayDizi = onaylanan.Split(' ');
            string kayit;
            int secilenIndex = listBox1.SelectedIndex;
            connect.Open();/*
                            0 TCKNO
                            1 Miktar
                            3 Ürün
                            4 Fiyat               
                            */
            if (onayDizi[2] == "TL")
            {
                var xpara = float.Parse(onayDizi[1]).ToString().Replace(",", ".");
                kayit = "Update Satis_Bilgileri set Para+='" + xpara + "', ParaAski_Admin = 0 where TCKNO='" + onayDizi[0] + "'";
                SqlCommand komut1 = new SqlCommand(kayit, connect);
                komut1.ExecuteNonQuery();
                this.Hide();
                

            }
            else {
                float kalan = 0;
                string komut3 = "SELECT * FROM Satis_Bilgileri WHERE UrunAski_Satis IS NOT NULL";
                SqlCommand myCommand = new SqlCommand(komut3, connect);
                SqlDataReader myReader = myCommand.ExecuteReader();
                float money=0;
                if (myReader.Read())
                {
                    if (myReader["UrunAski_Satis"].ToString() == onayDizi[3] && float.Parse(myReader["MiktarAski_Satis"].ToString()) <= float.Parse(onayDizi[1]) && float.Parse(myReader["FiyatAski_Satis"].ToString()) >= float.Parse(onayDizi[4]))
                    {
                        money = float.Parse(myReader["MiktarAski_Satis"].ToString()) * float.Parse(myReader["FiyatAski_Satis"].ToString());
                        string komut4_ = "Update Satis_Bilgileri set Urun=UrunAski_Satis, Miktar = MiktarAski_Satis, Fiyat =FiyatAski_Satis ,Para-='"+money+"',UrunAski_Satis= NULL,MiktarAski_Satis= NULL,FiyatAski_Satis = NULL where TCKNO='" + myReader["TCKNO"].ToString() + "'";
                        kalan = float.Parse(onayDizi[1]) - float.Parse(myReader["MiktarAski_Satis"].ToString());
                        myReader.Close();
                        
                        
                        SqlCommand komut4 = new SqlCommand(komut4_, connect);
                        komut4.ExecuteNonQuery();


                    }
                }
                myReader.Close();
                if (kalan == 0)
                {
                    kalan = float.Parse(onayDizi[1]);
                }
                
                 kayit = "Update Satis_Bilgileri set Miktar='" + kalan + "',MiktarAski_Admin = NULL, Urun='" + onayDizi[3] + "',UrunAski_Admin= NULL, Fiyat='" + float.Parse(onayDizi[4]) + "',FiyatAski_Admin = NULL,Para-='" + money + "' where TCKNO='" + onayDizi[0] + "'";
                                SqlCommand komut2 = new SqlCommand(kayit, connect);
                                komut2.ExecuteNonQuery();
                MessageBox.Show("Kullanicinin hesabına aktarildi.");
                this.Hide();





            }

            connect.Close();


        }
    }
}
