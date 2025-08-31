using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace frmEOSServer
{
    public partial class tryAnother : Form
    {
        public tryAnother()
        {
            InitializeComponent();

            IPAddress serverIP = IPAddress.Parse("127.0.0.1"); //103.179.172.211
            TcpListener server = new TcpListener(serverIP, 55178);

            server.Start();

            displayMessenger("Server has started on " + serverIP.ToString() + ". Waiting for a connection ...");

            //TcpClient client = server.AcceptTcpClient();
            //displayMessenger("A client connected");
        }

        void displayMessenger(string messenger)
        {
            rtbMessenger.AppendText("\r\n" + messenger);
        }
    }
}
