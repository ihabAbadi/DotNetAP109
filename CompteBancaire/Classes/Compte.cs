using System;
using System.Collections.Generic;
using System.Text;

namespace CompteBancaire.Classes
{
    public class Compte
    {
        private int numero;
        private decimal solde;
        private Client client;
        private List<Operation> operations;
        private static int compteur = 0;
        public int Numero { get => numero; }
        public decimal Solde { get => solde; }
        public Client Client { get => client; set => client = value; }
        public List<Operation> Operations { get => operations; set => operations = value; }

        public Compte()
        {
            numero = ++compteur;
            Operations = new List<Operation>();
            solde = 0;
        }

        public virtual bool Depot(Operation operation)
        {
            if(operation.Montant > 0)
            {
                Operations.Add(operation);
                solde += operation.Montant;
                return true;
            }
            return false;
        }

        public virtual bool Retrait(Operation operation)
        {
            if(Solde >= Math.Abs(operation.Montant) && operation.Montant < 0)
            {
                Operations.Add(operation);
                solde += operation.Montant;
                return true;
            }
            return false;
        }

    }
}
