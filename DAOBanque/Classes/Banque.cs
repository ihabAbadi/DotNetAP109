using System;
using System.Collections.Generic;
using System.Text;

namespace DAOBanque.Classes
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

        public void CreationCompte(Compte compte)
        {
            compte.ADecouvert += NotificationDecouvert;
            Comptes.Add(compte);
        }

        public Compte RechercherCompte(int numero)
        {
            Compte compte = null;
            foreach(Compte c in Comptes)
            {
                if(c.Numero == numero)
                {
                    compte = c;
                    break;
                }
            }
            return compte;
        }

        public void NotificationDecouvert(int numero, decimal solde)
        {
            Console.WriteLine($"Le compte numéro {numero} est à decouvert, le solde est de {solde} euros");
            Console.WriteLine("Touche pour continuer....");
            Console.ReadLine();
        }
    }
}
