using DAOHotel.Interfaces;
using DAOHotel.Models;
using DAOHotel.Tools;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAOHotel.Repositories
{
    public class CustomerRepository : BaseRepository, IRepository<Customer>
    {
        
        public Customer Create(Customer element)
        {
            request = "INSERT INTO customer (firstname, lastname, phone) OUTPUT inserted.id values (@firstname, @lastname, @phone)";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@firstname", element.FirstName));
            command.Parameters.Add(new SqlParameter("@lastname", element.LastName));
            command.Parameters.Add(new SqlParameter("@phone", element.Phone));
            connection.Open();
            element.Id = (int)command.ExecuteScalar();
            command.Dispose();
            connection.Close();
            return element;
        }

        public bool Delete(Customer element)
        {
            request = "DELETE FROM customer where id=@id";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@id", element.Id));
            connection.Open();
            int nbRow = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return nbRow == 1;       
        }

        public List<Customer> FindAll()
        {
            List<Customer> customers = new List<Customer>();
            request = "SELECT id, firstname, lastname, phone from customer";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            reader = command.ExecuteReader();
            while(reader.Read())
            {
                Customer c = new Customer()
                {
                    Id = reader.GetInt32(0),
                    FirstName = reader.GetString(1),
                    LastName = reader.GetString(2),
                    Phone = reader.GetString(3)
                };
                customers.Add(c);
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return customers;
        }

        public Customer FindById(int id)
        {
            Customer customer = null;
            request = "SELECT id, firstname, lastname, phone from customer where id = @id";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@id", id));
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                customer= new Customer()
                {
                    Id = reader.GetInt32(0),
                    FirstName = reader.GetString(1),
                    LastName = reader.GetString(2),
                    Phone = reader.GetString(3)
                };
               
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return customer;
        }

        public bool Update(Customer element)
        {
            throw new NotImplementedException();
        }
    }
}
