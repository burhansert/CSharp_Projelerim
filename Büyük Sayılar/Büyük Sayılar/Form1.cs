using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;

namespace Büyük_Sayılar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        void hesapla()
        {
            BigInteger sayi1 = BigInteger.Parse(textBox2.Text);
            BigInteger sayi2 = BigInteger.Parse(textBox3.Text);

            string sayi2str = sayi2.ToString();

            int uzunluk = sayi2.ToString().Length;

            BigInteger[] carpimlar = new BigInteger[uzunluk];

            for (int i = 0; i < uzunluk; i++)
            {
                carpimlar[i] = BigInteger.Multiply(sayi1, BigInteger.Parse(sayi2str[uzunluk - i - 1].ToString()));

            }

            BigInteger sonuc = 0;

            for (int i = 0; i < uzunluk; i++)
            {
                sonuc = BigInteger.Add(sonuc, carpimlar[i]);
            }

            textBox1.Text = sonuc.ToString();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            hesapla();
        }

              private void textBox2_TextChanged(object sender, EventArgs e)
        {
            hesapla();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            hesapla();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            hesapla();
        }
    }
}
