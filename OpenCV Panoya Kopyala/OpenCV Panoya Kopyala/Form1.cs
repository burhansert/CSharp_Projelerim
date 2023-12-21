using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OpenCV_Panoya_Kopyala
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            string data = textBox1.Text;
            Clipboard.SetDataObject((object)data, false);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_Click(object sender, EventArgs e)
        {
            string data = textBox3.Text;
            Clipboard.SetDataObject((object)data, false);
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            string data = textBox2.Text;
            Clipboard.SetDataObject((object)data, false);
        }
    }
}
