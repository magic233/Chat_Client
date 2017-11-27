using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace Chat_Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            textChat.Text = textChat.Text + "\nClient Running ...";
            //TcpClient client; 
            //try
            //{
            //    client = new TcpClient();
            //    client.Connect("localhost", 8500);
            //    textChat.Text = textChat.Text + "\n"+"OK ...";
            //}
            //catch(Exception ex)
            //{
            //    textChat.Text = textChat.Text + "\nServer Connected!" + ex.Message ;
            //    return;
            //}
           
        }

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            TcpClient client;
            try
            {
                client = new TcpClient();
                client.Connect("localhost", 8500);
            }
            catch (Exception ex)
            {
                textChat.Text = textChat.Text + "\n"+"Server Connected!" + ex.Message;
                return;
            }
            NetworkStream streamToServer = client.GetStream();

            byte[] text = Encoding.Unicode.GetBytes(textInput.Text);
            streamToServer.Write(text, 0, text.Length);
            int textRead;
            text = new byte[8192];
            textRead = streamToServer.Read(text, 0, 8192);
            string msg = Encoding.Unicode.GetString(text, 0, textRead);
            textChat.Text = textChat.Text + "\n"  + msg;
        }
    }
}
