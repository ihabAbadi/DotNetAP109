using System;
using System.Collections.Generic;
using System.Text;

namespace CoursAP2019.Classes
{
    public class Calculatrice
    {

        //1ere maniére de créer des delegates
        //public delegate double MethodeCalcule(double a, double b);
        //2eme manière de créer les delegates (des delegates génériques)
        //Classe Action => utiliser pour passer des méthodes avec un retour en void
        //Classe Func => utiliser pour passer des méthodes avec un retour autre que void
        public double Addition(double a, double b)
        {
            return a + b;
        }

        public double Soustraction(double a, double b)
        {
            return a - b;
        }

        public void Calcule(double n1, double n2, Func<double, double, double> methode)
        {
            Console.WriteLine(methode(n1, n2));
        }
    }
}
