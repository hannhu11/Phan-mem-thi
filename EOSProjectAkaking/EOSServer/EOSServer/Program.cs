using System.Net;
using System.Net.Sockets;

static void Main(string[] args)
{
    Console.Title = "Tải lên file server";

    var listener = new TcpListener(IPAddress.Any, 55178);
    listener.Start();
}