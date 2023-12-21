using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace PipesServerTest
{
    public partial class Form1 : Form
    {
        public delegate void NewMessageDelegate(string NewMessage);
        private PipeServer _pipeServer;

        public Form1()
        {
            InitializeComponent();
        }
    
        private void cmdListen_Click(object sender, EventArgs e)
        {
            try
            {
                _pipeServer = new PipeServer();
                _pipeServer.PipeMessage += new DelegateMessage(PipesMessageHandler);
                _pipeServer.Listen(textBox1.Text);
                //cmdListen.Enabled = false;
            }
            catch (Exception)
            {            
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void PipesMessageHandler(string message)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new NewMessageDelegate(PipesMessageHandler), message);
                }
                else
                {
                    listBox1.Items.Add(message);
                }
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.Message);
            }

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _pipeServer.PipeMessage -= new DelegateMessage(PipesMessageHandler);
            _pipeServer = null;

        }
    }
}
