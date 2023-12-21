using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dikdörtgen_Çizme
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //4. Şekil
            //form üzerine çizim yapılıyor
            //formun load olayında çalışmıyor
            //butonların click olayında çalışıyor
            //formların paint olayında çalışıyor
            System.Drawing.Graphics graphicsObj = this.CreateGraphics();
            Pen myPen = new Pen(System.Drawing.Color.Blue, 5);
            Rectangle myRectangle = new Rectangle(20, 20, 100, 100);
            graphicsObj.DrawRectangle(myPen, myRectangle);

            //5. Şekil
            //bu kodda panel üzerine çizim yapılıyor
            //formun load olayında çalışmıyor
            //butonların click olayında çalışıyor
            //formların paint olayında çalışıyor
            Graphics daire1 = panel2.CreateGraphics();
            SolidBrush firca = new SolidBrush(Color.Red);
            daire1.FillEllipse(firca, new Rectangle(new Point(10, 10), new Size(50, 50)));

            //6. Şekil
            //bu kodda panel üzerine çizim yapılıyor
            //formun load olayında çalışmıyor
            //butonların click olayında çalışıyor
            //formların paint olayında çalışıyor
            Graphics daire = panel1.CreateGraphics(); //panel nesnemizi çizime hazırladık
            Pen kalem1 = new Pen(Color.Red);
            daire.DrawEllipse(kalem1, new Rectangle(new Point(10, 10), new Size(50, 50)));

            //7. Şekil
            //picturebox üzerine çizim yapılıyor
            //picturebox ta resim yüklü değilse sorun çıkarıyor
            //!!!formun load olayında çalışıyor
            //formların load olayında sadece bu kullanım çalışıyor
            //!!!butonların click olayında çalışmıyor
            //butonların click olayında sadece bu çalışmıyor
            //formların paint olayında çalışıyor
            Graphics qq = Graphics.FromImage(pictureBox2.Image);
            qq.DrawString("Hoş Geldiniz.", new Font("Arial", 10), System.Drawing.Brushes.Blue, new Point(0, 150));
            qq.DrawLine(System.Drawing.Pens.Black, 0, 0, 100, 100);

            //şekil çizdikten sonra, çizilen şekillerin görünmesi için bazen gerekli oluyor
            //ama ne işe yaradığını tam anlamıyla çözemedim
            //this.Invalidate(); 

            //this.Invalidate(myRectangle); //böyle bir kullanımda var ne işe yaradığını bilmiyorum
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //1. Şekil
            //bu kodda picturebox üzerine çizim yapılıyor
            //formun load olayında çalışmıyor
            //butonların click olayında çalışıyor
            //kodun sonuna Invalidate(); eklenirse formların paint olayında çalışıyor
            Graphics grafik = pictureBox1.CreateGraphics();
            Pen kalem = new Pen(System.Drawing.Color.Green, 7);
            Point nokta1 = new Point(50, 50);
            Point nokta2 = new Point(200, 200);
            grafik.DrawLine(kalem, nokta1, nokta2);

            //2. Şekil
            //bu kodda picturebox üzerine çizim yapılıyor
            //formun load olayında çalışmıyor
            //butonların click olayında çalışıyor
            //kodun sonuna Invalidate(); eklenirse formların paint olayında çalışıyor
            Graphics g = pictureBox1.CreateGraphics();
            Pen blackPen = new Pen(Color.Black, 30);
            g.DrawRectangle(Pens.Black, 100, 150, 150, 100);

            //3. Şekil
            //bu kodda picturebox üzerine çizim yapılıyor
            //formun load olayında çalışmıyor
            //butonların click olayında çalışıyor
            //kodun sonuna Invalidate(); eklenirse formların paint olayında çalışıyor
            System.Drawing.Graphics graphicsObj1 = pictureBox1.CreateGraphics();
            Pen myPen1 = new Pen(System.Drawing.Color.Red, 5);
            Rectangle myRectangle1 = new Rectangle(20, 20, 150, 100);
            graphicsObj1.DrawRectangle(myPen1, myRectangle1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }
    }
}
