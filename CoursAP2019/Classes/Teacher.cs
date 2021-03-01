using System;
using System.Collections.Generic;
using System.Text;

namespace CoursAP2019.Classes
{
    public class Teacher : Person
    {
        private string course;

        public string Course { get => course; set => course = value; }

        public Teacher(string firstName, string lastName, int age, string course) : base(firstName, lastName, age)
        {
            Course = course;
        }

        public new void Display()
        {
            base.Display();
            Console.WriteLine($"Cours : {Course}");
        }

        public void DisplayTeacher()
        {
            Console.WriteLine("Special Teacher");
        }
    }
}
