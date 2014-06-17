using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;


// TO DO : 2eme balle si score%10 = 0 et si balle 2 n'existe pas. (ATTENTION : pas de game over s'il reste une balle en jeu)
// TO DO : threads pour changer couleur de fond à chaque fois que ça touche la raquette
// TO DO : Serveur TCP
// TO DO : Choix clavier / souris
// TO DO : rajouter musique
// TO DO : mettre des tiers de raquette : centre : même vitesse horizontale / côté opposé à la vitesse : changement de sens / même côté que vitesse : vitesse horiz*1.2
// TO DO : 2 players ? (mettre if 1player : top rebondit / if 2 players : top = perdu) 
// TO DO : ... 

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        // paramètres
        public int nbJoueurs = 1;
        public int score;
        public string clavierSouris = "souris";
        Balle b;
        
        public Form1()
        {
            InitializeComponent();

            // démarre une nouvelle partie
            newGame();

            // éléments graphiques
            this.FormBorderStyle = FormBorderStyle.None; // pas de barre en haut
            this.Bounds = Screen.PrimaryScreen.Bounds; // plein écran
            raquette.Top = (espaceJeu.Bottom - 40);  // positionne la raquette en hauteur
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            b.move();

            // si balle touche raquette
            if (b.Bas >= raquette.Top && b.Bas <= raquette.Bottom && b.Gauche >= raquette.Left && b.Droite <= raquette.Right) // si la balle touche la raquette : 
            {
                b.rebond();
                score = score + 1;
                scoreLabel.Text = score.ToString();
            }

            // si balle touche bord gauche ou droite
            if (b.Gauche <= espaceJeu.Left || b.Droite >= espaceJeu.Right)
            {
                b.invGaucheDroite();
            }

            // si balle touche bord supérieur
            if (b.Haut <= espaceJeu.Top)
            {
                b.rebond();
            }

            // si balle touche bord du bas
            if (b.Bas >= espaceJeu.Bottom)
            {
                gameOver();
            }

            if (nbJoueurs == 1)
            {
                if (clavierSouris == "souris")
                {
                    raquette.Left = Cursor.Position.X - (raquette.Width / 2); // la raquette suit la souris 
                }
            }
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
            if (b != null)
            {
                b.remove();
            }
            b = new Balle(espaceJeu);
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

        
    }



    
}
