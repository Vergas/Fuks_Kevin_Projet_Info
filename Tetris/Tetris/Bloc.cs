using System.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Tetris
{
    class Bloc
    {
        enum angle
        {
            initiale = 1,
            rotation90 = 2,
            rotation180 = 3,
            rotation270 = 4,
        }
        
    
        enum type
        {
            S = 1,
            Z = 2,
            T = 3,
            O = 4,
            L = 5,
            J = 6,
            I = 7
        }

    struct StructureBloc
    {
        public angle angle;
        public type type;

        public StructureBloc(angle newAngle, type newType)
        {
            this.angle = newAngle;
            this.type  = newType;
        }
    }

    public Boolean[] situation(StructureBloc structure)
        {
            // on considère des matrices 4x4 sous cette forme : 
            //0  1  2  3
            //4  5  6  7
            //8  9  10 11
            //12 13 13 15
            bool [] matrice = new bool [16];

            switch (structure.type)
            {
                case type.I:
                    matrice[1] = true;
                    matrice[5] = true;
                    matrice[9] = true;
                    matrice[13] = true;
                    break;

                  
                case type.J:
                    if (structure.angle.Equals(angle.initiale))
                    {
                        matrice[1] = true;
                        matrice[5] = true;
                        matrice[9] = true;
                        matrice[8] = true;
                    }
                    else if (structure.angle.Equals(angle.rotation90))
                    {
                        matrice[0] = true;
                        matrice[4] = true;
                        matrice[5] = true;
                        matrice[6] = true;
                    }
                    else if (structure.angle.Equals(angle.rotation180))
                    {
                        matrice[1] = true;
                        matrice[0] = true;
                        matrice[5] = true;
                        matrice[9] = true;
                    }
                    else
                    {
                        matrice[4] = true;
                        matrice[5] = true;
                        matrice[6] = true;
                        matrice[10] = true;

                    }
                    break;

                case type.L:
                    if (structure.angle.Equals(angle.initiale))
                    {
                        matrice[1] = true;
                        matrice[5] = true;
                        matrice[9] = true;
                        matrice[10] = true;
                    }
                    else if (structure.angle.Equals(angle.rotation90))
                    {
                        matrice[8] = true;
                        matrice[4] = true;
                        matrice[5] = true;
                        matrice[6] = true;
                    }
                    else if (structure.angle.Equals(angle.rotation180))
                    {
                        matrice[1] = true;
                        matrice[2] = true;
                        matrice[5] = true;
                        matrice[9] = true;
                    }
                    else
                    {
                        matrice[4] = true;
                        matrice[5] = true;
                        matrice[6] = true;
                        matrice[2] = true;

                    }
                    break;

                case type.O:
                    matrice[1] = true;
                    matrice[2] = true;
                    matrice[5] = true;
                    matrice[6] = true;
                    break;

                case type.S:
                    if (structure.angle.Equals(angle.initiale) || structure.angle.Equals(angle.rotation180))
                    {
                        matrice[1] = true;
                        matrice[5] = true;
                        matrice[2] = true;
                        matrice[4] = true;
                    }
                    else if (structure.angle.Equals(angle.rotation90) || structure.angle.Equals(angle.rotation270))
                    {
                        matrice[2] = true;
                        matrice[9] = true;
                        matrice[5] = true;
                        matrice[6] = true;
                    }
                    break;
                case type.Z:
                    if (structure.angle.Equals(angle.initiale) || structure.angle.Equals(angle.rotation180))
                    {
                        matrice[1] = true;
                        matrice[5] = true;
                        matrice[0] = true;
                        matrice[6] = true;
                    }
                    else if (structure.angle.Equals(angle.rotation90) || structure.angle.Equals(angle.rotation270))
                    {
                        matrice[1] = true;
                        matrice[5] = true;
                        matrice[6] = true;
                        matrice[10] = true;
                    }
                    break;

                case type.T:
                    if (structure.angle.Equals(angle.initiale))
                    {
                        matrice[0] = true;
                        matrice[1] = true;
                        matrice[2] = true;
                        matrice[5] = true;
                    }
                    else if (structure.angle.Equals(angle.rotation90))
                    {
                        matrice[1] = true;
                        matrice[5] = true;
                        matrice[6] = true;
                        matrice[9] = true;
                    }
                    else if (structure.angle.Equals(angle.rotation180))
                    {
                        matrice[1] = true;
                        matrice[4] = true;
                        matrice[5] = true;
                        matrice[6] = true;
                    }
                    else
                    {
                        matrice[1] = true;
                        matrice[4] = true;
                        matrice[5] = true;
                        matrice[9] = true;

                    }
                    break;

            }

            return matrice;
        }

    }
}
