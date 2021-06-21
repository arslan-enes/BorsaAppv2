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
using System.IO;

namespace BorsaAppv2
{
    public partial class SatinAlmaGecmisi : Form
    {
        public SatinAlmaGecmisi()
        {
            InitializeComponent();
        }
        static string constring = "Data Source =.; Initial Catalog = BorsaApp; Integrated Security = True";
        SqlConnection connect = new SqlConnection(constring);
        List<string> onaylar = new List<string>()
        {


        };
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            

            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "DECLARE @MinDate DATE = '" + dateTimePicker1.Value.ToString("yyyyMMdd") + "',@MaxDate DATE = '" + dateTimePicker2.Value.ToString("yyyyMMdd") + "';SELECT  *FROM    Satis_Gecmis WHERE  Urun='"+ textBox1.Text + "' AND Tarih >= @MinDate AND     Tarih < @MaxDate;";

            SqlDataAdapter sda = new SqlDataAdapter(query, connect);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            for (int i = 0; i < dtbl.Rows.Count; i++)
            {


                onaylar.Add(dtbl.Rows[i][0].ToString() + "  " + dtbl.Rows[i][2] + " KG " + dtbl.Rows[i][1] + "  " + dtbl.Rows[i][3] + " TL");


            }

            listBox1.DataSource = onaylar;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string path = @"C:\Users\enesf\source\repos\BorsaAppv2\BorsaAppv2\Rapor.csv";
            string[] parca;
            var csv = new StringBuilder();
            foreach(string str in onaylar)
            {
                parca = str.Split(' ');
                var Tarih = parca[0];
                var Miktar =parca[3];
                var Urun = parca[5];
                var Fiyat = parca[7];
                //Suggestion made by KyleMit
                var newLine = $"{Tarih},{Miktar},{Urun},{Fiyat}";
                csv.AppendLine(newLine);
            }
            File.WriteAllText(path,csv.ToString());
            MessageBox.Show("Rapor oluşturuldu !");
        }
    }
}
