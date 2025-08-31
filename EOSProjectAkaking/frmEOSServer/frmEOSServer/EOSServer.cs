using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CipherHelper;
using System.Net.Sockets;
using System.Net;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using System.DirectoryServices.ActiveDirectory;

namespace frmEOSServer
{
    public partial class EOSServer : Form
    {
        static Listener listener;
        static String messenger = "";
        static List<Client> lstClient;
        private string decodeKey = "AKAKING55178xxxx";
        public EOSServer()
        {
            InitializeComponent();
            listener = new Listener(55178);
            listener.SocketAccepted += new Listener.SocketAcceptedHandler(listener_SocketAccepted);
            Load += new EventHandler(EOSServer_Load);
            lstClient = new List<Client>();

        }

        private void listener_SocketAccepted(Socket e)
        {
            Client client = new Client(e);
            client.Received += new Client.ClientReceivedHandler(clientReceived);
            client.Disconnected += new Client.ClientDisconnectedHandler(clientDisconnected);

            Invoke((MethodInvoker)delegate
            {
                displayMessenger($"Client Endpoint: {client.endPoint.ToString()}");
                lstClient.Add(client);
            });

        }

        private void clientDisconnected(Client sender)
        {
            Invoke((MethodInvoker)delegate
            {

                for (int i = 0; i < lstClient.Count; i++)
                {
                    Client client = lstClient[i];
                    if (client.id == sender.id)
                    {
                        lstClient.RemoveAt(i);
                        break;
                    }

                }

            });
        }

        private void clientReceived(Client sender, byte[] data)
        {
            Invoke((MethodInvoker)delegate
            {
                Debug.Print("JUMP!");
                byte[] sizeBuffer = new byte[4];
                
                for (int i = 0; i < lstClient.Count; i++)
                {
                    Client client = lstClient[i];
                    if (client.id == sender.id)
                    {

                        string messenger = Encoding.UTF8.GetString(data);
                        if (!(messenger.Length < 0))
                        {
                            displayMessenger($"Client Endpoint: {client.endPoint.ToString()} SENT: {messenger} TIME: {DateTime.Now.ToString()}");

                            //string res = catchMessengerReq(messenger);
                            //client.socket.Send(Encoding.UTF8.GetBytes(res));
                            if (messenger.Contains("#DOEXAM"))
                            {
                                
                                string requestExam = "#DOEXAM";
                                string examCode = messenger.Substring(requestExam.Length +1);
                                Debug.Print(examCode + "<<<");
                                //requestExam = "what?";
                                byte[] data = Encoding.UTF8.GetBytes(requestExam);
                                byte[] sizeInBytes = BitConverter.GetBytes(data.Length);
                                int dataSize = BitConverter.ToInt32(sizeInBytes, 0);
                                Debug.Print("CHECK_SIZE: " + dataSize);
                                Debug.Print("DATA LENGTH: " + data.Length.ToString());
                                client.socket.Send(sizeInBytes);
                                client.socket.Send(data);


                                byte[] examByte = CipherData.GetDecryptDataFromFile($"C:\\Users\\Administrator\\Desktop\\examCode\\{examCode}.dat", decodeKey);
                                sizeInBytes = BitConverter.GetBytes(examByte.Length);
                                //Gửi byte[] chua json String;
                                client.socket.Send(sizeInBytes);
                                client.socket.Send(examByte);
                            }

                        }
                        break;
                    }

                }

            });
        }

        private string catchMessengerReq(string messenger)
        {
            if (messenger.Contains("#DOEXAM")) {
                return "RESPONSED";
            }

            return "DO NOTHING";
        }

        void displayMessenger(string messenger)
        {
            rtbMessenger.AppendText("\r\n" + messenger);
        }



        private void EOSServer_Load(object sender, EventArgs e)
        {
            listener.Start();
        }
    }
}
