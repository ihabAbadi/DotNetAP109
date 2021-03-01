using CoursAP2019.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoursAP2019.Classes
{
    public class Car : IDisplayable
    {
        private string model;

        public string Model { get => model; set => model = value; }

        public void Display()
        {
            Console.WriteLine($"Model Voiture : {Model}");
        }
    }
}
