using System;
using System.Collections.Generic;
using System.Text;

namespace CoursAP2019.Classes
{
    public abstract class Figure
    {
        private double posX;
        private double posY;

        public double PosX { get => posX; set => posX = value; }
        public double PosY { get => posY; set => posY = value; }

        protected Figure(double posX, double posY)
        {
            PosX = posX;
            PosX = posY;
        }

        public abstract void Afficher();
    }
}
