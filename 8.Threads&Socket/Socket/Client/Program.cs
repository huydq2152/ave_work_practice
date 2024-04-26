using System;

namespace Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var clientService = new Client();
            clientService.StartClient();
        }
    }
}
