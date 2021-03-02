using CoursAP2019.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoursAP2019.Classes
{
    public class Sauvegarde : ISauvegarde
    {
        public void Sauvegarder()
        {
            Console.WriteLine("Sauvegarde en fichier");
        }
    }
}
