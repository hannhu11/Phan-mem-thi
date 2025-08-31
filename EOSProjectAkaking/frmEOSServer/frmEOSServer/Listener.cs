using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.CodeDom;
using System.Diagnostics;

namespace frmEOSServer
{
    public class Listener
    {
        Socket socket;
        IPAddress hostIP = IPAddress.Parse("103.179.172.211");

        public bool Listening { get; set; }
        public int Port { get; set; }

        public Listener(int port)
        {
            Port = port;
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public void Start()
        {
            if (Listening)
            {
                return;
            }

            socket.Bind(new IPEndPoint(hostIP, Port));
            socket.Listen(0);
            socket.BeginAccept(callback, null);
            Listening = true;
        }
        public void Stop()
        {
            if (!Listening)
            {
                return;
            }
            socket.Close();
            socket.Dispose();
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        void callback(IAsyncResult ar)
        {
            try
            {
                Debug.Print("CALLBACK!");
                Socket socket = this.socket.EndAccept(ar);
                if (SocketAccepted != null)
                {
                    SocketAccepted(socket);
                }
                this.socket.BeginAccept(callback, null);
            }
            catch(Exception ex) {
                Debug.Print(ex.Message);
            }
        }

        public delegate void SocketAcceptedHandler(Socket e);
        public event SocketAcceptedHandler SocketAccepted;
    }
}
