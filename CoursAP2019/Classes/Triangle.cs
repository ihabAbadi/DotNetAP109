using System;
using System.Collections.Generic;
using System.Text;

namespace CoursAP2019.Classes
{
    public class Triangle : Figure
    {
        private double baseT;
        private double hauteurT;

        public double BaseT { get => baseT; set => baseT = value; }
        public double HauteurT { get => hauteurT; set => hauteurT = value; }

        public Triangle(double posX, double posY, double baseH, double hauteurT) : base(posX, posY)
        {
            BaseT = baseT;
            HauteurT = hauteurT;
        }

        public override void Afficher()
        {
            Console.WriteLine($"Je suis un triangle iscocèle de base {BaseT} et hauteur  {HauteurT}");
        }
    }
}
