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
        private decimal maxDecouvert;

        public event Action<int, decimal> ADecouvert;
        public int Numero { get => numero; }
        public decimal Solde { get => solde; }
        public Client Client { get => client; set => client = value; }
        public List<Operation> Operations { get => operations; set => operations = value; }
        public decimal MaxDecouvert { get => maxDecouvert; set => maxDecouvert = value; }

        public Compte()
        {
            numero = ++compteur;
            Operations = new List<Operation>();
            solde = 0;
            MaxDecouvert = 200;
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
            if(Math.Abs(Solde - Math.Abs(operation.Montant)) <= MaxDecouvert  && operation.Montant < 0)
            {
                Operations.Add(operation);
                solde += operation.Montant;
                if(Solde < 0)
                {
                    if(ADecouvert != null)
                    {
                        ADecouvert(Numero, Solde);
                    }
                }
                return true;
            }
            return false;
        }


        public override string ToString()
        {
            string retour = $"====Compte Numéro : {Numero}, Solde : {Solde} euros ====\n";
            retour+=$"Client : {Client.ToString()} \n";
            retour += "----Liste des opérations----\n";
            foreach(Operation o in Operations)
            {
                retour += o.ToString() + "\n";
            }
            return retour;
        }
    }
}
