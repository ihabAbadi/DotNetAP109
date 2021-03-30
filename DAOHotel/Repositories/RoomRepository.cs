using DAOHotel.Interfaces;
using DAOHotel.Models;
using DAOHotel.Tools;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAOHotel.Repositories
{
    public class RoomRepository : BaseRepository, IRepository<Room>
    {
        
        public void Create(Room element)
        {
            request = "INSERT INTO room (price, max, status) OUTPUT inserted.id values (@price, @max, @status)";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@price", element.Price));
            command.Parameters.Add(new SqlParameter("@max", element.Max));
            command.Parameters.Add(new SqlParameter("@status", element.Status));
            connection.Open();
            element.Id = (int)command.ExecuteScalar();
            command.Dispose();
            connection.Close();
        }

        public bool Delete(Room element)
        {
            request = "DELETE FROM room where id=@id";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@id", element.Id));
            connection.Open();
            int nbRow = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return nbRow == 1;
        }

        public List<Room> FindAll()
        {
            List<Room> rooms = new List<Room>();
            request = "SELECT id, price, max, status from room";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Room r = new Room()
                {
                    Id = reader.GetInt32(0),
                    Price = reader.GetDecimal(1),
                    Max = reader.GetInt32(2),
                    Status = (RoomStatus)reader.GetInt32(3)
                };
                rooms.Add(r);
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return rooms;
        }

        public List<Room> FindAllByStatus(RoomStatus status)
        {
            List<Room> rooms = new List<Room>();
            request = "SELECT id, price, max, status from room where status=@status";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@status", status));
            connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Room r = new Room()
                {
                    Id = reader.GetInt32(0),
                    Price = reader.GetDecimal(1),
                    Max = reader.GetInt32(2),
                    Status = (RoomStatus)reader.GetInt32(3)
                };
                rooms.Add(r);
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return rooms;
        }

        public List<Room> FindAllByReservationId(int id)
        {
            List<Room> rooms = new List<Room>();
            request = "SELECT r.id, r.price, r.max, r.status from room as r " +
                "inner join reservation_room as rr on  r.id == rr.room_id" +
                " where rr.reservation_id=@id";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@id", id));
            connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Room r = new Room()
                {
                    Id = reader.GetInt32(0),
                    Price = reader.GetDecimal(1),
                    Max = reader.GetInt32(2),
                    Status = (RoomStatus)reader.GetInt32(3)
                };
                rooms.Add(r);
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return rooms;
        }

        public Room FindById(int id)
        {
            Room room = null;
            request = "SELECT id, price, max, status from room where id=@id";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@id", id));
            connection.Open();
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                room = new Room()
                {
                    Id = reader.GetInt32(0),
                    Price = reader.GetDecimal(1),
                    Max = reader.GetInt32(2),
                    Status = (RoomStatus)reader.GetInt32(3)
                };
                
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return room;
        }

        public bool Update(Room element)
        {
            request = "UPDATE room set status=@status where id=@id";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@id", element.Id));
            command.Parameters.Add(new SqlParameter("@status", element.Status));
            connection.Open();
            int nbRow = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return nbRow == 1;
        }
    }
}
