using System;
using Client;

namespace Server
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Server server = new Server();
                server.StartServer();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
