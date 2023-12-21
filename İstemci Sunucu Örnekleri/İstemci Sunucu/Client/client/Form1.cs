using System;
using System.Net.Sockets;
using System.IO;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace client
{
    public partial class Form1 : Form
    {
        public TcpClient Istemci;
        private NetworkStream AgAkimi;
        private StreamReader AkimOkuyucu;
        private StreamWriter AkimYazici;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                Istemci = new TcpClient("localhost", 1234);
            }
            catch
            {
                return;
            }
            AgAkimi = Istemci.GetStream();
            AkimOkuyucu = new StreamReader(AgAkimi);
            AkimYazici = new StreamWriter(AgAkimi);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Boş mesaj gönderemezsiniz.", "Uyarı!");
                    textBox1.Focus();
                    return;
                }

                string yazi;
                AkimYazici.WriteLine(textBox1.Text);
                AkimYazici.Flush();
                listBox1.Items.Add(textBox1.Text);
                yazi = AkimOkuyucu.ReadLine();
                listBox2.Items.Add(yazi);
            }
            catch
            {
                MessageBox.Show("Sunucu çalışmıyor.","Uyarı!");
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                AkimYazici.Close();
                AkimOkuyucu.Close();
                AgAkimi.Close();
            }
            catch
            {
                MessageBox.Show("Program Doğru Kapanamıyor");
            }
        }
    }

}
