using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Programinizin_Adini_Ogrenme
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show
              (
              "Programın Orjinal Adı:\n"
              + Application.ProductName     //program derlenirken programa verilen isim

              + "\n\nProgramın Son Adı:\n"
              //programın bulunduğu klasördeki ismi
              //eğer sonradan kullanıcı program adını değiştirirse
              //buradaki bilgide değişir
              + Path.GetFileName(Application.ExecutablePath)

              + "\n\nProgramın Versiyonu:\n"
              + Application.ProductVersion  //program versiyonu

              , "Program Bilgileri!"
              );
        }
    }
}
