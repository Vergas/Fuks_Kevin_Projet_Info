using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                IPAddress ipAd = IPAddress.Parse("127.0.0.1"); //use local m/c IP address, and use the same in the client
                /* Initializes the Listener */
                TcpListener myList = new TcpListener(ipAd, 8001);
                while (true)
                {
                    /* Start Listeneting at the specified port */
                    myList.Start();
                    TcpClient cl = myList.AcceptTcpClient();
                    NetworkStream stm = cl.GetStream();
                    string rcvString = "";
                    byte[] b = new byte[100];
                    stm.Read(b, 0, b.Length);
                    ASCIIEncoding asen = new ASCIIEncoding();
                    
                    rcvString = asen.GetString(b);
                    Console.WriteLine(rcvString);

                    stm.Close();
                    cl.Close();
                    myList.Stop();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error..... " + e.StackTrace);
                Console.ReadLine();
            } 
        }
    }
}
