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
    class Balle
    {
        List<PictureBox> balles;
        PictureBox balle;
        int vitesse = 18;
        int gaucheDroite = 1;
        int hautBas = 1;

        public int haut;
        public int bas;
        public int gauche;
        public int droite;
        public int Haut { get { return balle.Top; } set { haut = value; } }
        public int Bas { get { return balle.Bottom; } set { bas = value; } }
        public int Gauche { get { return balle.Left; } set { gauche = value; } }
        public int Droite { get { return balle.Right; } set { droite = value; } }

        // définition d'une balle : picturebox de 20x20 rouge
        public Balle(Panel _espacedejeu)
        {
            balles = new List<PictureBox>();
            balle = new PictureBox();
            balle.BackColor = Color.Red;
            balle.Size = new Size(20, 20);
            _espacedejeu.Controls.Add(balle);
            balles.Add(balle);
            balle.Enabled = true;
            balle.Show();
        }

        // rebond quand la balle touche la raquette ou bord supérieur
        public void rebond()
        {
            vitesse += 2;
            hautBas *= -1 ; // balle change de sens verticalement et remonte
        }

        // inverser gauche et droite quand la balle touche un côté
        public void invGaucheDroite()
        {
            gaucheDroite *= -1;
        }

        // faire se déplacer la balle
        public void move()
        {
            balle.Hide(); //cache la balle pour éviter d'avoir 3 images de balle pour un déplacement
            balle.Left += vitesse * gaucheDroite;
            balle.Top += vitesse * hautBas;
            balle.Show(); //fait réaparaitre la balle à sa nouvelle position
        }

        // virer la balle pour nouvelle partie par exemple
        public void remove()
        {
            balle.Enabled = false;
        }

    }
}
