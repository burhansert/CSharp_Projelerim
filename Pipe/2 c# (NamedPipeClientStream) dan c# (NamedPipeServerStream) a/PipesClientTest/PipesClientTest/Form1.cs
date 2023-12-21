using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PipesClientTest
{
    public partial class Form1 : Form
    {
        private PipeClient _pipeClient;

        public Form1()
        {
            InitializeComponent();
        }

        private void cmdSend_Click(object sender, EventArgs e)
        {
            _pipeClient = new PipeClient();
            _pipeClient.Send(txtMessage.Text , textBox1.Text);
            listBox1.Items.Add(txtMessage.Text);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _pipeClient = null;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
