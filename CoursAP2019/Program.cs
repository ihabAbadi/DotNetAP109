using CoursAP2019.Classes;
using System;
using System.Collections.Generic;

namespace CoursAP2019
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();
            Person s = new Student("toto", "tata", 20, 1);
            persons.Add(s);
            Person t = new Teacher("titi", "minet", 50, ".net");
            persons.Add(t);
            foreach(Person p in persons)
            {
                Console.WriteLine(p.GetType());
                p.Display();
                //1ere manière de convertir des objets
                //Student st = p as Student;
                //if(st != null)
                //{
                //    st.DisplayStudent();
                //}
                //2eme manière de convertir des objets
                //if(p.GetType() == typeof(Student))
                //{
                //    Student st = (Student)p;
                //    st.DisplayStudent();
                //}
                //3eme manière de convertir des objets
                if(p is Student st)
                {
                    st.DisplayStudent();
                }
                else if(p is Teacher tt)
                {
                    tt.DisplayTeacher();
                }
            }
        }
    }
}
