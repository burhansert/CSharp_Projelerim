using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kendi_Programimiza_Tus_Gonderme
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public int i=1;
        private void textBox1_Click(object sender, EventArgs e)
        {
            switch (i++)
            {
                case 1:
                    textBox1.Clear();
                    SendKeys.Send("M");
                    break;
                case 2:
                    SendKeys.Send("E");
                    break;
                case 3:
                    SendKeys.Send("R");
                    break;

                case 4:
                    SendKeys.Send("H");
                    break;
                case 5:
                    SendKeys.Send("A");
                    break;
                case 6:
                    SendKeys.Send("B");
                    break;
                case 7:
                    SendKeys.Send("A");
                    break;
            }           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
