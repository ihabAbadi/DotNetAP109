using System;
using System.Collections.Generic;
using System.Text;

namespace CompteBancaire.Classes
{
    public class Banque
    {
        private string nom;
        private List<Compte> comptes;

        public string Nom { get => nom; set => nom = value; }
        public List<Compte> Comptes { get => comptes; set => comptes = value; }

        public Banque(string nom)
        {
            Nom = nom;
            Comptes = new List<Compte>();
        }
    }
}
