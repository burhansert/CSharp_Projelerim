using System;
using System.Drawing;
using System.Windows.Forms;

namespace Fareyi_Hareket_Ettirmek
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int xHareket;
        int yHareket;
        int fareHiz = 50;
        private void timer1_Tick(object sender, EventArgs e)
        {
            Cursor.Position = new Point(Cursor.Position.X + xHareket, Cursor.Position.Y + yHareket);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            xHareket = 0;
            yHareket = fareHiz;
            timer1.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            xHareket = 0;
            yHareket = -fareHiz;
            timer1.Enabled = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            xHareket = fareHiz;
            yHareket = 0;
            timer1.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            xHareket = -fareHiz;
            yHareket = 0;
            timer1.Enabled = true;
        }
    }
}
