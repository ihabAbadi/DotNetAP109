using CoursAP2019.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoursAP2019.Classes
{
    public class Person : IDisplayable
    {
        private string firstName;
        private string lastName;

        public string FirstName { 
            get
            {
              return firstName;
            }
            set
            {
                if(value.Length > 3)
                {
                    firstName = value;
                }
                else
                {
                    throw new Exception("Erreur firstName");
                }
            }
        }
        public string LastName { get => lastName; set => lastName = value; }

        public int Age { get; set; }

        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public Person(string firstName, string lastName, int age) : this(firstName, lastName)
        {
            Age = age;
        }

        public virtual void Display()
        {
            Console.WriteLine($"Nom : {FirstName}, Prénom : {LastName}, Age : {Age}");
        }

        public virtual void Display(Action<string> methodeAffichage)
        {
            methodeAffichage($"Nom : {FirstName}, Prénom : {LastName}, Age : {Age}");
        }
    }
}
