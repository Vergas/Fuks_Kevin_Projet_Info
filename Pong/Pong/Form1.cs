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
        // initialisation des paramètres
        public int vitesse = 6;
        public int gaucheDroite = 1;
        public int hautBas = 1;
        public int score = 0;


        public Form1()
        {
            InitializeComponent();
            timer1.Enabled = true;
            this.FormBorderStyle = FormBorderStyle.None; // pas de barre en haut
            this.Bounds = Screen.PrimaryScreen.Bounds; // plein écran
            raquette.Top = (espaceJeu.Bottom - 40);  // positionne la raquette en hauteur

            messageLabel.Visible = false; // n'affiche pas le label de message sans raisons

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            raquette.Left = Cursor.Position.X - (raquette.Width / 2); // la raquette suit la souris 

            balle.Left = balle.Left + vitesse*gaucheDroite;
            balle.Top = balle.Top + vitesse*hautBas;

            if (balle.Bottom >= raquette.Top && balle.Bottom <= raquette.Bottom && balle.Left >= raquette.Left && balle.Right <= raquette.Right) // si la balle touche la raquette : 
            {
                vitesse = vitesse + 2;
                hautBas = -1; // balle change de sens verticalement et remonte
                score = score + 1;
                scoreLabel.Text = score.ToString();
            }

            // changement de sens horizontal quand la balle touche bord gauche ou droite
            if (balle.Left <= espaceJeu.Left)
            {
                gaucheDroite = 1;
            }
            if (balle.Right >= espaceJeu.Right)
            {
                gaucheDroite = -1;
            }
            // changement de sens vertical quand la balle touche le sommet de l'espace de jeu
            if (balle.Top <= espaceJeu.Top)
            {
                hautBas = 1;
            }

            // fin du jeu quand la balle arrive en bas de l'espace de jeu
            if (balle.Bottom >= espaceJeu.Bottom)
            {
                timer1.Enabled = false;
                messageLabel.Text = "GAME OVER // Score : " + score.ToString();
            }

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                timer1.Enabled = false;
                messageLabel.Text = "PAUSE. Appuyez sur ENTER pour relancer la partie";
                messageLabel.Left = espaceJeu.Right/2 - messageLabel.Width / 2;
                messageLabel.Top = espaceJeu.Bottom/2 - messageLabel.Height / 2;
                messageLabel.Visible = true;
            }

            if (e.KeyCode == Keys.Enter)
            {
                timer1.Enabled = true;
                messageLabel.Visible = false;
            }

            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }

        }




    }
}
