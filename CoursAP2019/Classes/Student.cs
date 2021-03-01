using CoursAP2019.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoursAP2019.Classes
{
    sealed public class Student : Person
    {
        private int level;

        public int Level { get => level; set => level = value; }

        public Student(string firstName, string lastName, int age, int level) : base(firstName, lastName, age)
        { 
            Level = level;
        }

        //Surcharge en utilisant le mot clé new
        public new void Display()
        {
            base.Display();
            Console.WriteLine($"niveau : {Level}");
        }

        //Surcharge en utilisant le mot clé Override
        //public override void Display()
        //{
        //    base.Display();
        //    Console.WriteLine($"niveau : {Level}");
        //}

        public void DisplayStudent()
        {
            Console.WriteLine("Special Student");
        }
    }
}
