using System;
using System.Collections.Generic;
using System.Text;

namespace DAOBanque.Classes
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
            return Depot(new Operation(Solde * Taux / 100));
        }
    }
}
