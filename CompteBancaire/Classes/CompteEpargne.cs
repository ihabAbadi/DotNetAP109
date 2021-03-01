using System;
using System.Collections.Generic;
using System.Text;

namespace CompteBancaire.Classes
{
    public class CompteEpargne : Compte
    {
        private decimal taux;

        public decimal Taux { get => taux; set => taux = value; }

        public CompteEpargne(decimal taux) : base()
        {
            Taux = taux;
        }

        public bool CalculeInteret()
        {
            return false;
        }
    }
}
