using DAOHotel.Interfaces;
using DAOHotel.Models;
using DAOHotel.Tools;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAOHotel.Repositories
{
    public class ReservationRepository : BaseRepository, IRepository<Reservation>
    {
        public void Create(Reservation element)
        {
            
            connection = Connection.New;
            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();
            try
            {
                //requetes
                request = "INSERT INTO reservation (customer_id, status) output inserted.id values (@customer_id, @status)";
                command = new SqlCommand(request, connection, transaction);
                command.Parameters.Add(new SqlParameter("@customer_id", element.Customer.Id));
                command.Parameters.Add(new SqlParameter("@status", element.Status));
                int reservation_id = (int)command.ExecuteScalar();
                command.Dispose();
                foreach(Room c in element.Rooms)
                {
                    request = "INSERT INTO reservation_room (room_id, reservation_id) values (@room_id, @reservation_id);" +
                        "UPDATE room set status = @status where id=@room_id;";
                    command = new SqlCommand(request, connection, transaction);
                    command.Parameters.Add(new SqlParameter("@room_id", c.Id));
                    command.Parameters.Add(new SqlParameter("@reservation_id", reservation_id));
                    command.Parameters.Add(new SqlParameter("@status", c.Status));
                    command.ExecuteNonQuery();
                    command.Dispose();
                }
                element.Id = reservation_id;
                transaction.Commit();
            }catch(Exception ex)
            {
                transaction.Rollback();
            }
            
        }

        public bool Delete(Reservation element)
        {
            throw new NotImplementedException();
        }

        public List<Reservation> FindAll()
        {
            List<Reservation> reservations = new List<Reservation>();
            request = "SELECT r.id, r.status, c.id, c.firstname, c.lastname, c.phone from " +
                "reservation as r inner customer as c on c.id == r.customer_id";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            connection.Open();
            reader = command.ExecuteReader();
            while(reader.Read())
            {
                Reservation r = new Reservation()
                {
                    Id = reader.GetInt32(0),
                    Status = (ReservationStatus)reader.GetInt32(1),
                    Customer = new Customer()
                    {
                        Id = reader.GetInt32(2),
                        FirstName = reader.GetString(3),
                        LastName = reader.GetString(4),
                        Phone = reader.GetString(5),
                    }
                };
                reservations.Add(r);
            }
            return reservations;
        }

        public Reservation FindById(int id)
        {
            Reservation reservation = null;
            request = "SELECT r.id, r.status, c.id, c.firstname, c.lastname, c.phone from " +
                "reservation as r inner customer as c on c.id == r.customer_id where r.id = @id";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@id", id));
            connection.Open();
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                reservation = new Reservation()
                {
                    Id = reader.GetInt32(0),
                    Status = (ReservationStatus)reader.GetInt32(1),
                    Customer = new Customer()
                    {
                        Id = reader.GetInt32(2),
                        FirstName = reader.GetString(3),
                        LastName = reader.GetString(4),
                        Phone = reader.GetString(5),
                    }
                };
                
            }
            return reservation;
        }

        public bool Update(Reservation element)
        {
            bool result = false;
            connection = Connection.New;
            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();
            try
            {
                //requetes
                request = "UPDATE reservation set status = @status where id = @id";
                command = new SqlCommand(request, connection, transaction);
                command.Parameters.Add(new SqlParameter("@id", element.Id));
                command.Parameters.Add(new SqlParameter("@status", element.Status));
                int nbRow = command.ExecuteNonQuery();
                command.Dispose();
                foreach (Room c in element.Rooms)
                {
                    request = "UPDATE room set status = @status where id=@room_id;";
                    command = new SqlCommand(request, connection, transaction);
                    command.Parameters.Add(new SqlParameter("@room_id", c.Id));
                    command.Parameters.Add(new SqlParameter("@status", c.Status));
                    command.ExecuteNonQuery();
                    command.Dispose();
                }
                transaction.Commit();
                result = nbRow == 1;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
            }
            return result;
        }
    }
}
