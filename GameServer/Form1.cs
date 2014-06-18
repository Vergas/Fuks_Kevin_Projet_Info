using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Net;
using System.Net.Sockets;
using MySql.Data.MySqlClient;


namespace GameServer
{
    public partial class Form1 : Form
    {
        private static TcpListener _listener;
//        [DllImport("kernel32.dll", EntryPoint = "AllocConsole", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)] 
//            static extern int AllocConsole();

        public Form1()
        {
            InitializeComponent();
            timer1.Enabled = true;
//            AllocConsole();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            StartServer();
        }

        public static void StartServer()
        {
            IPEndPoint ipLocal = new IPEndPoint(IPAddress.Any, 8001);
            _listener = new TcpListener(ipLocal);
            _listener.Start();
            WaitForClientConnect();
        }
        private static void WaitForClientConnect()
        {
            object obj = new object();
            _listener.BeginAcceptTcpClient(new System.AsyncCallback(OnClientConnect), obj);
        }

        private static void OnClientConnect(IAsyncResult asyn)
        {
            try
            {
                TcpClient clientSocket = default(TcpClient);
                clientSocket = _listener.EndAcceptTcpClient(asyn);
                HandleClientRequest clientReq = new HandleClientRequest(clientSocket);
                clientReq.StartClient();
            }
            catch (Exception se)
            {
                throw;
            }

            WaitForClientConnect();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            HighScoresDB DB = new HighScoresDB();
            string html = DB.TopTen();
            webBrowser1.Navigate("about:blank");
            webBrowser1.DocumentText = "";
            webBrowser1.Refresh();
            while (webBrowser1.Document == null && webBrowser1.Document.Body == null)
                Application.DoEvents();
            webBrowser1.Document.Write(html);
            timer1.Enabled = true;
        }
    }

    public class HandleClientRequest
    {
        TcpClient _clientSocket;
        NetworkStream _networkStream = null;
        public HandleClientRequest(TcpClient clientConnected)
        {
            this._clientSocket = clientConnected;
        }
        public void StartClient()
        {
            _networkStream = _clientSocket.GetStream();
            WaitForRequest();
        }

        public void WaitForRequest()
        {
            byte[] buffer = new byte[_clientSocket.ReceiveBufferSize];

            _networkStream.BeginRead(buffer, 0, buffer.Length, ReadCallback, buffer);
        }

        private void ReadCallback(IAsyncResult result)
        {
            NetworkStream networkStream = _clientSocket.GetStream();
            try
            {
                int read = networkStream.EndRead(result);
                if (read == 0)
                {
                    _networkStream.Close();
                    _clientSocket.Close();
                    return;
                }

                byte[] buffer = result.AsyncState as byte[];
                string data = Encoding.Default.GetString(buffer, 0, read);
                if (data.Length >= 3)
                {
                    string Operation = data.Substring(0, 3);
                    if (Operation == "HS,")
                    {
                        string[] entry = data.Split(',');
                        Pong pongscore = new Pong();
                        pongscore.Pseudo = entry[1];
                        pongscore.Score = Convert.ToInt32(entry[2]);
                        HighScoresDB DB = new HighScoresDB();
                        DB.AddScore(pongscore);
                    }
                    else if (Operation == "GET")
                    {
                        HighScoresDB DB = new HighScoresDB();
                        string html = DB.TopTen();
                        Byte[] sendBytes = Encoding.ASCII.GetBytes(html);
                        networkStream.Write(sendBytes, 0, sendBytes.Length);
                        networkStream.Flush();
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            this.WaitForRequest();
        }
    }

    public class Pong
    {
        public string Pseudo { get; set; }
        public int Score { get; set; }

        public Pong()
        {
        }
    }
    public class HighScoresDB
    {

        private MySqlConnection connection;

        public HighScoresDB()
        {
            this.InitConnexion();
        }


       private void InitConnexion()
        {
            string connectionString = "SERVER=127.0.0.1; DATABASE=highscores; UID=root; PASSWORD=isib";
            this.connection = new MySqlConnection(connectionString);
        }

        public string TopTen()
        {
            MySqlDataReader rdr = null;
            string htmlHighScore;
            htmlHighScore = "";
            try
            {
                Pong pongscore = new Pong();
                this.connection.Open();
                MySqlCommand cmd = this.connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM Pong ORDER BY score DESC LIMIT 10";
                rdr = cmd.ExecuteReader();
                htmlHighScore = "<html><body><h1>High Scores</h1><br /><hr /><br /><table border=\"1\"><tr><td>Pseudo</td><td>High Score</td></tr>";
                while (rdr.Read()) 
                {
                    pongscore.Pseudo = rdr.GetString(0);
                    pongscore.Score = rdr.GetInt32(1);
                    htmlHighScore += "<tr><td>" + pongscore.Pseudo + "</td><td ALIGN=\"RIGHT\">" + Convert.ToString(pongscore.Score) + "</td></tr>";
                }
                htmlHighScore += "</table></body></html>";
            }
        catch (MySqlException ex) 
        {
            Console.WriteLine("Error: {0}",  ex.ToString());

        } finally 
        {
            if (rdr != null) 
            {
                rdr.Close();
            }
        }
            return htmlHighScore;

}


        public void AddScore(Pong pongscore)
        {
            try
            {
                this.connection.Open();

                MySqlCommand cmd = this.connection.CreateCommand();

                cmd.CommandText = "INSERT INTO pong (pseudo, score) VALUES (@Pseudo, @Score)";

                cmd.Parameters.AddWithValue("@Pseudo", pongscore.Pseudo);
                cmd.Parameters.AddWithValue("@Score", pongscore.Score);

                cmd.ExecuteNonQuery();

                this.connection.Close();
            }
            catch
            {
                throw;
            }
        }
    }
}
