using System;
using System.Collections.Generic;
using System.Text;

namespace DAOBanque.Classes
{
    public class ComptePayant : Compte
    {
        private decimal coutOperation;

        public decimal CoutOperation { get => coutOperation; set => coutOperation = value; }

        public ComptePayant(decimal coutOperation) : base()
        {
            CoutOperation = coutOperation;
        }

        public override bool Depot(Operation operation)
        {
            if(operation.Montant > coutOperation && base.Depot(operation))
            {
                return base.Retrait(new Operation(coutOperation * -1));
            }
            return false;
        }

        public override bool Retrait(Operation operation)
        {
            if(Solde >= (Math.Abs(operation.Montant) + CoutOperation))
            {
                return base.Retrait(operation) && base.Retrait(new Operation(coutOperation * -1));
            }
            return false;
        }
    }
}
