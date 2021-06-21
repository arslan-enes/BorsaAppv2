using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace BorsaAppv2
{
    public partial class ParaEkle : Form
    {
        public ParaEkle()
        {
            InitializeComponent();
        }
        static readonly string textFile = @"C:\Users\enesf\source\repos\BorsaAppv2\BorsaAppv2\Döviz.txt";
        private void button1_Click(object sender, EventArgs e)
        {
            HesabaUrunParaEkle satinAlmaIslemi = new HesabaUrunParaEkle();
            string text = File.ReadAllText(textFile);
            string[] dovizler = text.Split(' ');
            float carpan = 1;
            bool doviz = false;
            switch (comboBox1.SelectedItem.ToString())
            {
                case "Euro":
                    carpan = float.Parse(dovizler[1]);
                    break;
                case "Dolar":
                    carpan = float.Parse(dovizler[3]);
                    doviz = true;
                    break;
                case "TL":
                    carpan = 1;
                    doviz = false;
                    break;
                default:
                    break;

            }



            float para = float.Parse(para_txtbox.Text.ToString()) * carpan;

            MessageBox.Show(para.ToString());
            satinAlmaIslemi.ParaEkle(para, doviz);

            MessageBox.Show("İşlem admin onayına bırakıldı ");
            para_txtbox.Text = "";
            
        }
    }
}
