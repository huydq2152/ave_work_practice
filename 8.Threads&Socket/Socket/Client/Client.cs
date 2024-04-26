using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Common;
using Socket = System.Net.Sockets.Socket;

namespace Client
{
    public class Client
    {
        private bool _exitClient;

        private void GetOption()
        {
            while (true)
            {
                Console.WriteLine("Do you want to quit ? Input 'y' for yes or 'n' for no to confirm");
                var a = Console.ReadLine();
                if (a == "y")
                {
                    _exitClient = true;
                    break;
                }
                if (a == "n")
                {
                    _exitClient = false;
                    break;
                }
            }
        }

        private void GetClientInformation(SocketMessage clientMessage)
        {
            Console.WriteLine("Username:");
            clientMessage.Name = Console.ReadLine();
            while (clientMessage.Name == null)
            {
                Console.WriteLine("Name is empty, please enter your user name");
                clientMessage.Name = Console.ReadLine();
            }

            Console.WriteLine("Email:");
            clientMessage.Email = Console.ReadLine();
            while (!Helper.IsValidatedEmail(clientMessage.Email))
            {
                Console.WriteLine("Invalid email, please enter your email again!");
                clientMessage.Email = Console.ReadLine();
            }
        }

        private void GetClientMessage(SocketMessage clientMessage)
        {
            Console.WriteLine("Message(input 'end' to close this socket) :");
            clientMessage.Message = Console.ReadLine();
            clientMessage.TimeSent = DateTime.Now;
        }

        public void StartClient()
        {
            var clientMessage = new SocketMessage();

            #region Create server endpoint to connect socket

            var serverIp = IPAddress.Parse(Helper.GetLocalIpAddress());
            const int serverPort = 1380;
            var serverEndpoint = new IPEndPoint(serverIp, serverPort);

            #endregion

            var size = 1024;
            var receiveBuffer = new byte[size];

            while (true)
            {
                if (_exitClient)
                {
                    break;
                }
                try
                {
                    #region Create socket and connect to server endpoint

                    var socket = new Socket(serverIp.AddressFamily,
                        SocketType.Stream, ProtocolType.Tcp);
                    try
                    {
                        socket.Connect(serverEndpoint);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Connect exception : {e}");
                    }

                    #endregion

                    #region Get Client Message

                    if (clientMessage.Name == null && clientMessage.Email == null)
                    {
                        GetClientInformation(clientMessage);
                    }
                    while (socket.Connected)
                    {
                        try
                        {
                            GetClientMessage(clientMessage);
                            if (clientMessage.Message != "end")
                            {
                                var message = Helper.SerializeObjectToXmlString(clientMessage);
                                Console.WriteLine($">>> Message send to server: \n {message}");
                                var sendBuffer = Encoding.ASCII.GetBytes(message);
                                socket.Send(sendBuffer);
                                var length = socket.Receive(receiveBuffer);
                                var result = Encoding.ASCII.GetString(receiveBuffer, 0, length);
                                Console.WriteLine($">>> Server send : \n {result}");
                            }
                            else
                            {
                                GetOption();
                                if (_exitClient)
                                {
                                    break;
                                }
                            }
                        }
                        // Manage of Socket's Exceptions
                        catch (ArgumentNullException ane)
                        {
                            Console.WriteLine($"ArgumentNullException : {ane}");
                        }

                        catch (SocketException se)
                        {
                            Console.WriteLine($"SocketException : {se}");
                        }

                        catch (Exception e)
                        {
                            Console.WriteLine($"Unexpected exception : {e}");
                        }
                        Array.Clear(receiveBuffer, 0, size);
                        socket.Shutdown(SocketShutdown.Both);
                        socket.Close();
                    }

                    #endregion
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }
    }
}
