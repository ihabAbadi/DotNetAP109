using System;
using System.Collections.Generic;
using System.Text;

namespace CompteBancaire.Classes
{
    public class Operation
    {
        private int numero;
        private decimal montant;
        private DateTime dateOperation;
        private static int compteur = 0;
        public int Numero { get => numero; }
        public decimal Montant { get => montant; }
        public DateTime DateOperation { get => dateOperation;}

        public Operation(decimal montant)
        {
            numero = ++compteur;
            dateOperation = DateTime.Now;
            this.montant = montant;
        } 
    }
}
