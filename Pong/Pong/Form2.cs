using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;


namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        IPAddress serverAddress = IPAddress.Parse("127.0.0.1");
        TcpClient client = new TcpClient();
        NetworkStream stream;

        string text;
        int scor;


        public Form2(int score)
        {
            InitializeComponent();
            scor = score; 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                text = "HS," + textBox1.Text + "," + scor.ToString();
                client.Connect(serverAddress, 8001);
                stream = client.GetStream();
                ASCIIEncoding encoder = new ASCIIEncoding();
                byte[] sndBytes = encoder.GetBytes(text);
                stream.Write(sndBytes, 0, text.Length);
                stream.Flush();
                stream.Close();
                client.Close();
                this.Close();
            }
        }
    }
}
