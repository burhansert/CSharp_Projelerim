using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Runtime.InteropServices; //tuş göndermek için eklemeliyiz

//process'lere erişim için gerekli olan sınıf
using System.Diagnostics;
using System.IO;

namespace Baska_Programa_Tus_Gonderme
{
    public partial class Form1 : Form
    {
        [DllImport("User32.dll")]//tuş göndermek için eklemeliyiz
        static extern int SetForegroundWindow(IntPtr point);//tuş göndermek için eklemeliyiz

        public Form1()
        {
            InitializeComponent();
        }

        void kendiniAktifEt()
        {
            Activate();
        }

        bool mesaj = false; //textBox2 ye ilk tıklandığında içeriği boşaltılıyor

        private void textBox2_Click(object sender, EventArgs e)
        {
            if (mesaj == false)
            {
                mesaj = true;
                textBox2.Clear();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process p = Process.GetProcessesByName(listView1.SelectedItems[0].SubItems[1].Text).FirstOrDefault();
            IntPtr h = p.MainWindowHandle;
            SetForegroundWindow(h);
            SendKeys.Send(textBox2.Text);

            kendiniAktifEt();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Lütfen Programı Seçiniz";
            openFileDialog1.Filter = "(*.exe)|*.exe";
            openFileDialog1.ShowDialog();
            string exeAdi = openFileDialog1.FileName;
            Process.Start(exeAdi);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Process p = Process.GetProcessesByName(listView1.SelectedItems[0].SubItems[1].Text).FirstOrDefault();
            if (p != null)
            {
                IntPtr h = p.MainWindowHandle;
                SetForegroundWindow(h);
                SendKeys.SendWait("{LEFT}");
            }
            kendiniAktifEt();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Process p = Process.GetProcessesByName(listView1.SelectedItems[0].SubItems[1].Text).FirstOrDefault();
            if (p != null)
            {
                IntPtr h = p.MainWindowHandle;
                SetForegroundWindow(h);
                SendKeys.SendWait("{RIGHT}");
            }
            kendiniAktifEt();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Process p = Process.GetProcessesByName(listView1.SelectedItems[0].SubItems[1].Text).FirstOrDefault();
            if (p != null)
            {
                IntPtr h = p.MainWindowHandle;
                SetForegroundWindow(h);
                SendKeys.SendWait("{UP}");
            }
            kendiniAktifEt();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Process p = Process.GetProcessesByName(listView1.SelectedItems[0].SubItems[1].Text).FirstOrDefault();
            if (p != null)
            {
                IntPtr h = p.MainWindowHandle;
                SetForegroundWindow(h);
                SendKeys.SendWait("{DOWN}");
            }
            kendiniAktifEt();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            islemleriListele();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            kendiniAktifEt();
        }

        private void Form1_DoubleClick(object sender, EventArgs e)
        {
            this.Text = Path.GetFileName(Application.ExecutablePath);
        }

        void islemleriListele()
        {
            listView1.Items.Clear();

            int i = 0; //listView e eleman eklerken sıradaki eleman index'ini saklar

            foreach (Process prg in Process.GetProcesses())
            {
                if (prg.MainWindowTitle.ToString().Length > 0)
                {

                    listView1.Items.Add(prg.MainWindowTitle.ToString());

                    listView1.Items[i].SubItems.Add(prg.ProcessName);

                    i++;
                }
            }
        }


        private void button11_Click(object sender, EventArgs e)
        {
            islemleriListele();
        }

    }
}


