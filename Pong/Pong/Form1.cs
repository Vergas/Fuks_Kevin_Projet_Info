using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public int vitesse = 1;
        public int gaucheDroite = 1;
        public int hautBas = 1;
        public int score = 0;
        public Form1()
        {
            InitializeComponent();
            timer1.Enabled = true;

            raquette.Top = (espaceJeu.Bottom - 40);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            raquette.Left = Cursor.Position.X - (raquette.Width / 2);
            balle.Left = balle.Left + vitesse*gaucheDroite;
            balle.Top = balle.Top + vitesse*hautBas;

            if (balle.Bottom >= raquette.Top && balle.Bottom <= raquette.Bottom && balle.Left >= raquette.Left && balle.Right <= raquette.Right)
            {
                vitesse = vitesse + 2;
                hautBas = -1;
                score = score + 1;
            }

            if (balle.Left <= espaceJeu.Left)
            {
                gaucheDroite = 1;
            }
            if (balle.Right >= espaceJeu.Right)
            {
                gaucheDroite = -1;
            }
            if (balle.Top <= espaceJeu.Top)
            {
                hautBas = 1;
            }

            if (balle.Bottom >= espaceJeu.Bottom)
            {
                timer1.Enabled = false;
            }

        }

    }
}
