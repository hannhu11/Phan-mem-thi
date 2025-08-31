using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Diagnostics;

namespace frmEOSServer
{
    public class Client
    {

        public string id { get; set; }
        public IPEndPoint endPoint { get; set; }

        public Socket socket;

        public Client(Socket accepted)
        {
            socket = accepted;
            id = Guid.NewGuid().ToString();
            endPoint = (IPEndPoint)socket.RemoteEndPoint;
            socket.BeginReceive(new byte[] { 0 }, 0, 0, 0, callback, null);
        }

        void callback(IAsyncResult ar)
        {
            try
            {
                socket.EndReceive(ar);
                Debug.Print("CLIENT_CALLBACK");
                byte[] sizeBuffer = new byte[4]; //The length of an Int32 is 4 bytes;
                socket.Receive(sizeBuffer);
                int dataSize = BitConverter.ToInt32(sizeBuffer, 0); //Converts the byte array back to an Int32
                byte[] receiveBuffer = new byte[dataSize]; //Create a new buffer based on the real size                
                socket.Receive(receiveBuffer);

                if (Received != null)
                {
                    Received(this, receiveBuffer);
                }

                socket.BeginReceive(new byte[] { 0 }, 0, 0, 0, callback, null);
              
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Close();

                if (Disconnected != null)
                {
                    Disconnected(this); 
                }
            }
        }

        public void Close()
        {
            socket.Close();
            socket.Dispose();
        }

        public delegate void ClientReceivedHandler(Client sender, byte[] data);

        public delegate void ClientDisconnectedHandler(Client sender);
        public event ClientReceivedHandler Received;
        public event ClientDisconnectedHandler Disconnected;
    }
}
