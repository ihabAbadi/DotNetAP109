using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace CoursAdoNet.Classes
{
    public class Person
    {
        private int id;
        private string fristName;
        private string lastName;
        

        public int Id { get => id; set => id = value; }
        public string FristName { get => fristName; set => fristName = value; }
        public string LastName { get => lastName; set => lastName = value; }

        //public bool Save()
        //{
        //    return false;
        //}

        //public bool Update()
        //{
        //    return false;
        //}

        //public bool Delete()
        //{
        //    return false;
        //}

        //public static List<Person> GetPersons()
        //{
        //    return null;
        //}

        //public static Person GetPersonById(int id)
        //{
        //    return null;
        //}
    }
}
