using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


// TO DO : 2eme balle si score%10 = 0 et si balle 2 n'existe pas. (ATTENTION : pas de game over s'il reste une balle en jeu)
// TO DO : threads pour changer couleur de fond à chaque fois que ça touche la raquette
// TO DO : Serveur TCP

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        // paramètres
        public int vitesse;
        public int gaucheDroite;
        public int hautBas;
        public int score;



        public Form1()
        {
            InitializeComponent();
            newGame();
            this.FormBorderStyle = FormBorderStyle.None; // pas de barre en haut
            this.Bounds = Screen.PrimaryScreen.Bounds; // plein écran
            raquette.Top = (espaceJeu.Bottom - 40);  // positionne la raquette en hauteur

            messageLabel.Visible = false; // n'affiche pas le label de message sans raisons

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            move(balle);
            raquette.Left = Cursor.Position.X - (raquette.Width / 2); // la raquette suit la souris 
        }


        // centre le message au milieu de l'écran
        public void position()
        {
            messageLabel.Left = espaceJeu.Width / 2 - messageLabel.Width / 2;
            messageLabel.Top = espaceJeu.Height / 2 - messageLabel.Height / 2;
        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // touche espace = pause
            if (e.KeyCode == Keys.Space)
            {
                pause();
            }

            // touche enter = reprise du jeu
            if (e.KeyCode == Keys.Enter)
            {
                backToNormal();
            }

            // touche escape = quitter le jeu
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }

            //touche F2 = Nouvelle partie 
            if (e.KeyCode == Keys.F2)
            {
                newGame();
            }
        }





        // nouvelle partie = (ré)initialisation des paramètres
        public void newGame()
        {
            balle.Top = 20;
            balle.Left = espaceJeu.Width / 2 - balle.Width / 2;
            vitesse = 18;
            gaucheDroite = 1;
            hautBas = 1;
            score = 0;
            scoreLabel.Text = "0";
            backToNormal();
        }

        // fin du jeu
        public void gameOver()
        {
            timer1.Enabled = false;
            messageLabel.Text = "GAME OVER // Score : " + score.ToString() + "\n Nouvelle partie : F2" + "\n Exit : Escape";
            position();
            messageLabel.Visible = true;
        }

        // pause
        public void pause()
        {
            timer1.Enabled = false;
            messageLabel.Text = "PAUSE. Appuyez sur ENTER pour relancer la partie";
            position();
            messageLabel.Visible = true;
        }

        // retour à un jeu normal (sans message et timer on)
        public void backToNormal()
        {
            timer1.Enabled = true;
            messageLabel.Visible = false;
        }

        public void move(PictureBox ball)
        {   ball.Left = ball.Left + vitesse*gaucheDroite;
            ball.Top = ball.Top + vitesse*hautBas;

            if (ball.Bottom >= raquette.Top && ball.Bottom <= raquette.Bottom && ball.Left >= raquette.Left && ball.Right <= raquette.Right) // si la balle touche la raquette : 
            {
                vitesse = vitesse + 2;
                hautBas = -1; // balle change de sens verticalement et remonte
                score = score + 1;
                scoreLabel.Text = score.ToString();
            }

            // changement de sens horizontal quand la balle touche bord gauche ou droite
            if (ball.Left <= espaceJeu.Left)
            {
                gaucheDroite = 1;
            }
            if (ball.Right >= espaceJeu.Right)
            {
                gaucheDroite = -1;
            }
            // changement de sens vertical quand la balle touche le sommet de l'espace de jeu
            if (ball.Top <= espaceJeu.Top)
            {
                hautBas = 1;
            }

            // fin du jeu quand la balle arrive en bas de l'espace de jeu
            if (ball.Bottom >= espaceJeu.Bottom)
            {
                gameOver();
            }

        }

    }



    
}
