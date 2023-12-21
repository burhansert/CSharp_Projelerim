using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace stringBilgileri
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void hesapla()
        {
            String[] satir = textBox1.Text.Split('\n');
            int enUzunKarakterSayisi = 0;

            for (int i = 0; i < satir.Count(); i++)
            {
                if ((satir[i].Trim().Length) > enUzunKarakterSayisi)
                {
                    enUzunKarakterSayisi = satir[i].Trim().Length;
                }
            }
            label1.Text = "En uzun satirdaki karakter sayisi: " + enUzunKarakterSayisi;

            label2.Text = "Satir sayisi: " + satir.Count();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            hesapla();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            hesapla();
        }
    }
}
