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
        PictureBox balle;
        int vitesse = 18;
        int gaucheDroite = 1;
        int hautBas = 1;



        // définition d'une balle : picturebox de 20x20 rouge
        public Balle(Panel _espacedejeu)
        {
            balle = new PictureBox();
            balle.BackColor = Color.Red;
            balle.Size = new Size(20, 20);
            _espacedejeu.Controls.Add(balle);
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
            Point p = new Point();
            p = balle.Location;
            p.X = balle.Left + vitesse * gaucheDroite;
            p.Y = balle.Top + vitesse * hautBas;
            balle.Location = p;
        }

        // virer la balle pour nouvelle partie par exemple
        public void remove()
        {
            balle.Hide();
        }

        public PictureBox Ballon {get {return balle;}}


    }
}
