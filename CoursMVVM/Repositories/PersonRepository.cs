
using CoursMVVM.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace CoursMVVM.Repositories
{
    public class PersonRepository
    {
        private SqlCommand command;
        private SqlConnection _connection;
        private SqlDataReader reader;
        private string request;

        public PersonRepository(SqlConnection connection)
        {
            _connection = connection;
        }
        public Person Create(Person person)
        {
            //insertion dans la base de données
            request = "INSERT INTO person (firstname, lastname) " +
                    "OUTPUT INSERTED.id values (@firstname,  @lastname)";
            command = new SqlCommand(request, _connection);
            command.Parameters.Add(new SqlParameter("@firstname", person.FristName));
            command.Parameters.Add(new SqlParameter("@lastname", person.LastName));
            if(_connection.State == ConnectionState.Closed)
                _connection.Open();
            person.Id = (int)command.ExecuteScalar();
            command.Dispose();
            if (_connection.State == ConnectionState.Open)
                _connection.Close();
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
            List<Person> liste = new List<Person>();
            request = "SELECT id, firstname, lastname from person";
            SqlCommand command = new SqlCommand(request, _connection);
            _connection.Open();
            
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Person p = new Person()
                {
                    Id = reader.GetInt32(0),
                    FristName = reader.GetString(1),
                    LastName = reader.GetString(2),
                };
                liste.Add(p);
            }
            reader.Close();
            //liberation des ressources
            command.Dispose();
            _connection.Close();
            return liste;
        }

        public Person FindById(int id)
        {
            return null;
        }
    }
}
