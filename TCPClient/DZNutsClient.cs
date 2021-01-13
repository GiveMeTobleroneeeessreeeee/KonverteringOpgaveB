using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TCPClient
{
    class DZNutsClient
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Tryk for en tast for at forsæt");
            Console.ReadKey();

            int port = 7000;
            TcpClient clientSocket = new TcpClient(IPAddress.Loopback.ToString(), port);

            Stream ns = clientSocket.GetStream();  //provides a NetworkStream
            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);
            sw.AutoFlush = true; // enable automatic flushing


            while (true)
            {
                string line = sr.ReadLine();

                Console.WriteLine(line);
                sw.WriteLine(Console.ReadLine());
            }
        }
    }
}
