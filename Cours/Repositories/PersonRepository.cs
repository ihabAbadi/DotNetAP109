using CoursAdoNet.Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace CoursAdoNet.Repositories
{
    public class PersonRepository
    {
        private SqlCommand command;
        private SqlConnection _connection;
        private SqlDataReader reader;

        public PersonRepository(SqlConnection connection)
        {
            _connection = connection;
        }
        public Person Create(Person person)
        {
            //insertion dans la base de données
            return person;
        }

        public Person Update(Person person)
        {
            //insertion dans la base de données
            return person;
        }
        public Person Delete(Person person)
        {
            //insertion dans la base de données
            return person;
        }
        public List<Person> FindAll()
        {            
            return null;
        }

        public Person FindById(int id)
        {
            return null;
        }
    }
}
