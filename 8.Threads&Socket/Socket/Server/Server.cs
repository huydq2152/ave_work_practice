using Common;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Server
{
    public class Server
    {
        private bool _exitServer;
        public void Start(object state)
        {
            var socketServer = state as Socket;
            const int size = 1024;
            var receivedBuffer = new byte[size];

            if (socketServer == null) return;
            try
            {
                var length = socketServer.Receive(receivedBuffer);
                var data = Encoding.ASCII.GetString(receivedBuffer,
                    0, length);
                if (!string.IsNullOrEmpty(data))
                {
                    var socketMessage = Helper.DeserializeXmlStringToObject(data);
                    Console.WriteLine(
                        $"{socketMessage.Name} - {socketMessage.Email} : {socketMessage.Message} \n" +
                        $" Time send : {socketMessage.TimeSent.ToShortTimeString()}"
                    );
                    socketMessage.TimeReceived = DateTime.Now;
                    socketMessage.ThreadId = Thread.CurrentThread.ManagedThreadId;
                    var socketMessageString = Helper.SerializeObjectToXmlString(socketMessage);
                    Helper.WriteStringToXmlFile(socketMessageString);
                    socketServer.Send(Encoding.ASCII.GetBytes("Server received message !"));
                    Console.WriteLine("\n ################################### \n");

                    socketServer.Shutdown(SocketShutdown.Both);
                    socketServer.Close();
                    Array.Clear(receivedBuffer,0,size);
                }
            }
            catch (Exception e)
            {
                if (e is ObjectDisposedException || e is SocketException)
                {
                    Console.WriteLine("A client socket is closed");
                    socketServer.Shutdown(SocketShutdown.Both);
                    socketServer.Close();
                    Array.Clear(receivedBuffer, 0, size);
                }
                else
                {
                    Console.WriteLine(e.ToString());
                    socketServer.Shutdown(SocketShutdown.Both);
                    socketServer.Close();
                    Array.Clear(receivedBuffer, 0, size);
                }
            }
        }

        public void StartServer()
        {
            var serverIp = IPAddress.Parse(Helper.GetLocalIpAddress());
            const int serverPort = 1380;
            var serverEndpoint = new IPEndPoint(serverIp, serverPort);

            var listener = new Socket(serverIp.AddressFamily,
                SocketType.Stream, ProtocolType.Tcp);
            listener.Bind(serverEndpoint);
            listener.Listen(10);
            Console.WriteLine("Waiting connection ...");

            while (true)
            {
                if (_exitServer) break;
                var socketServer = listener.Accept();
                var thread = new Thread(Start);
                thread.Start(socketServer);

                #region wait to close server

                new Thread(() =>
                {
                    while (true)
                    {
                        var handleCloseServer = Console.ReadLine();
                        if (handleCloseServer != "x") continue;
                        _exitServer = true;
                        break;
                    }
                })
                {
                    Priority = ThreadPriority.Highest
                }.Start();

                #endregion

            }
        }
    }
}
