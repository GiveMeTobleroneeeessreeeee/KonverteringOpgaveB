using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using KonverteringModel;

namespace TCPKonverteringsServer
{
    class TCPServer
    {
        static void Main()
        {
            TcpListener listener = null;
            try
            {
                listener = new TcpListener(IPAddress.Loopback, 7000);
                listener.Start();

                Console.WriteLine("MultiThreadedServer started...");
                while (true)
                {
                    Console.WriteLine("Waiting for incoming client connections...");
                    TcpClient client = listener.AcceptTcpClient();
                    Console.WriteLine("Accepted new client connection...");
                    Thread t = new Thread(ProcessClientRequests);
                    t.Start(client);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                if (listener != null)
                {
                    listener.Stop();
                }
            }
            //Console.WriteLine("Hello World!");
        }


        private static double RateCHoice(double num)
        {
            if (num == 0)
            {
                return num = 0.7041;
            }
            else
            {
                return num;
            }
        }
        
        private static void ProcessClientRequests(object argument)
        {
            TcpClient client = (TcpClient)argument;
            try
            {          
                StreamReader sr = new StreamReader(client.GetStream());
                StreamWriter sw = new StreamWriter(client.GetStream());
                sw.AutoFlush = true;
                //Console.WriteLine("Hejsa, Hvilken Request vil du foretage? dkktosvk eller svktodkk");
                
                
                while (true)
                {
                    sw.WriteLine("Hejsa, Hvilken Request vil du foretage? dkktosvk eller svktodkk, tryk x for at afslutte.");
                    string message = sr.ReadLine();
                    if (message.ToLower().Contains("x"))
                    {
                        break;
                    }

                    switch (message)
                    {
                        case "svktodkk":
                            sw.WriteLine("Hvad beløb vil du konverterer?");
                            string amount = sr.ReadLine();
                            double svenskeKroner = double.Parse(amount);

                            sw.WriteLine("Hvilken rate vil du anvende? tast 0 hvis standard rate skal benyttes.");
                            string recieved1Rate = sr.ReadLine();
                            double rate1 = RateCHoice(double.Parse(recieved1Rate));

                            double ConvertedAmount = Konvertering.TilDanskeKroner(svenskeKroner, rate1);
                            sw.WriteLine($"Danske Kroner: {ConvertedAmount}");
                            break;

                        case "dkktosvk":
                            sw.WriteLine("Hvad beløb vil du konverterer?");
                            string amount2 = sr.ReadLine();
                            double danskeKroner = double.Parse(amount2);

                            sw.WriteLine("Hvilken rate vil du anvende? tast 0 hvis standard rate skal benyttes.");
                            string recieved2Rate = sr.ReadLine();
                            double rate2 = RateCHoice(double.Parse(recieved2Rate));

                            double ConvertedAmount2 = Konvertering.TilSvenskeKroner(danskeKroner, rate2);
                            sw.WriteLine($"Danske Kroner: {ConvertedAmount2}");
                            break;
                    }
                }
                sr.Close();
                sw.Close();
                client.Close();
                Console.WriteLine("Closing client connection");
            }
            catch (IOException)
            {
                Console.WriteLine("Problem with client communication. Exiting thread.");
            }
            finally
            {
                if (client != null)
                {
                    client.Close();
                }
            }
        }


        

    }
}

