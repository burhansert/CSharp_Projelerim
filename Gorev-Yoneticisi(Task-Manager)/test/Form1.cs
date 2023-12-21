using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace test
{
    public partial class Form1 : Form
    {
        [DllImport("User32.dll")]//tuş göndermek için eklemeliyiz
        static extern int SetForegroundWindow(IntPtr point);//tuş göndermek için eklemeliyiz

        private void listView1_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = listView1.Columns[e.ColumnIndex].Width;
        }

        private void ProgramlariListele()
        {
            listView1.Items.Clear();

            int i = 0; //listView e eleman eklerken sıradaki eleman index'ini saklar

            //içine parametre olarak "." koyanlar var sebebini bilmiyorum
            foreach (Process p in Process.GetProcesses())
            {
                //İşlem isimlerine sıra numarası veriliyor
                listView1.Items.Add((i + 1).ToString());
                
                //programın adı
                listView1.Items[i].SubItems.Add(p.ProcessName);

                //Programın pencere başlığı eklendi
                listView1.Items[i].SubItems.Add(p.MainWindowTitle.ToString());

                //Programların PID değerleri
                listView1.Items[i].SubItems.Add(p.Id.ToString());

                //Programın Hafızada Kapladığı Yer
                listView1.Items[i].SubItems.Add(Convert.ToInt32(Math.Round(Convert.ToDecimal(p.PrivateMemorySize64 / 1024))) + "KB");

                //Uygulamanın yanıt verip vermediğini
                //Yani sorunsuz bir şekilde çalışıp çalışmadığını söyle
                listView1.Items[i].SubItems.Add(p.Responding.ToString());

           

                i++;



            }
            lblTotal.Text = "Toplam Çalışan\nİşlem Sayısı:\n" + listView1.Items.Count.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ProgramlariListele();          
        }

   
        private void btnTaskEnd_Click(object sender, EventArgs e)
        {
            var kapatilacakIslem = listView1.SelectedItems[0].SubItems[1].Text;
            Process[] processler = Process.GetProcessesByName(kapatilacakIslem.ToString());

            foreach (Process process in processler)
            {
                Debug.WriteLine("İşlem sonlandırıldı: " + process.ProcessName);
                process.Kill();
            }
            MessageBox.Show("İşlem sonlandırıldı: " + kapatilacakIslem, "Başarılı");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProgramlariListele();
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process p = Process.GetProcessesByName(listView1.SelectedItems[0].SubItems[1].Text).FirstOrDefault();
            if (p != null)
            {
                IntPtr h = p.MainWindowHandle;
                SetForegroundWindow(h);
            }
        }

 
    }
}
