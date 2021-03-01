using System;
using System.Collections.Generic;
using System.Text;

namespace CompteBancaire.Classes
{
    class ComptePayant : Compte
    {
        private decimal coutOperation;

        public decimal CoutOperation { get => coutOperation; set => coutOperation = value; }

        public ComptePayant(decimal coutOperation) : base()
        {
            CoutOperation = coutOperation;
        }

        public override bool Depot(Operation operation)
        {
            return base.Depot(operation);
        }

        public override bool Retrait(Operation operation)
        {
            return base.Retrait(operation);
        }
    }
}
