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

namespace WindowsFormsApplication1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            HighScoresDB DB = new HighScoresDB();
            string html = DB.TopTen();
            webBrowser1.Navigate("about:blank");

            webBrowser1.Document.Write(html);
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

            public class Pong
            {
                public string Pseudo { get; set; }
                public int Score { get; set; }

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
                    Console.WriteLine("Error: {0}", ex.ToString());

                }
                finally
                {
                    if (rdr != null)
                    {
                        rdr.Close();
                    }
                }
                return htmlHighScore;

            }


        }
    }
}
