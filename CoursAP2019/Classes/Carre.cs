using CoursAP2019.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoursAP2019.Classes
{
    public class Carre : Figure, IDeformable
    {
        private double cote;

        public double Cote { get => cote; set => cote = value; }

        public Carre(double posX, double posY, double cote) : base(posX, posY)
        {
            Cote = cote;
        }

        public override void Afficher()
        {
            Console.WriteLine($"Je suis un carré de côté {Cote}");
        }

        public Figure Deformation(double coeffH, double coeffV)
        {
            if(coeffH != coeffV)
            {
                return new Rectangle(PosX, PosY, Cote * coeffH, Cote * coeffV);
            }
            else
            {
                return new Carre(PosX, PosY, Cote * coeffH);
            }
        }
    }
}
