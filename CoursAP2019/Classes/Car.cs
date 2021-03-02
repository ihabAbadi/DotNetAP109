﻿using CoursAP2019.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoursAP2019.Classes
{
    public class Car : IDisplayable
    {
        private string model;

        private decimal price;

        private ISauvegarde _sauvegarde;
        public string Model { get => model; set => model = value; }
        public decimal Price { get => price; set => price = value; }

        public event Action<decimal> Promotion;

        public Car(ISauvegarde sauvegarde)
        {
            _sauvegarde = sauvegarde;
        }

        public void Display()
        {
            Console.WriteLine($"Model Voiture : {Model}");
        }

        public void Discount(decimal amount)
        {
            Price -= amount;
            //Lance une compagne sms et mail.
            //Démarrer event promotion
            if(Promotion != null)
            {
                Promotion(Price);
            }
        }

        public void Save()
        {
            _sauvegarde.Sauvegarder();
        }
    }
}
