using System;
using System.Collections.Generic;
using System.Text;

namespace DAOHotel.Models
{
    public class Reservation
    {
        private int id;
        private Customer customer;
        private ReservationStatus status;
        private List<Room> rooms;

        public int Id { get => id; set => id = value; }
        public Customer Customer { get => customer; set => customer = value; }
        public ReservationStatus Status { get => status; set => status = value; }
        public List<Room> Rooms { get => rooms; set => rooms = value; }

        public Reservation()
        {
            Rooms = new List<Room>();
            Customer = new Customer();
        }
    }

    public enum ReservationStatus
    {
        confirm,
        cancel
    }
}
