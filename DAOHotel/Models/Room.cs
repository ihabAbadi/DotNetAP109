using System;
using System.Collections.Generic;
using System.Text;

namespace DAOHotel.Models
{
    public class Room
    {
        private int id;
        private decimal price;
        private int max;
        private RoomStatus status;
        public int Id { get => id; set => id = value; }
        public decimal Price { get => price; set => price = value; }
        public int Max { get => max; set => max = value; }
        public RoomStatus Status { get => status; set => status = value; }

        public override string ToString()
        {
            return $"N°: {Id}, Prix : {Price}, Max {Max}";
        }
    }

    public enum RoomStatus
    {
        free,
        busy,
    }
}
