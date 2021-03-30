using DAOHotel.Models;
using DAOHotel.Repositories;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace HotelWPF.ViewModels
{
    class ReservationViewModel : ViewModelBase
    {
        private Reservation reservation;
        private ReservationRepository reservationRepository;
        private CustomerRepository customerRepository;
        private RoomRepository roomRepository;

        public List<Customer> Customers { get; set; }

        public Customer Customer { get => reservation.Customer; set => reservation.Customer = value; }

        public int Max { get; set; }

        private int nb;


        public ICommand DisplayRoomCommand { get; set; }

        public ICommand ValidCommand { get; set; }
        public ObservableCollection<Room> Rooms { get; set; }

        public ReservationViewModel()
        {
            customerRepository = new CustomerRepository();
            Customers = customerRepository.FindAll();
            reservation = new Reservation();
            Rooms = new ObservableCollection<Room>();
            DisplayRoomCommand = new RelayCommand<WrapPanel>(DisplayRoom);
            ValidCommand = new RelayCommand(ValidReservation);
        }
        private void DisplayRoom(WrapPanel panel)
        {
            nb = Max;
            roomRepository = new RoomRepository();
            List<Room> liste = roomRepository.FindAllByStatus(RoomStatus.free);
            panel.Children.Clear();
            foreach (Room r in liste)
            {                
                Button b = new Button()
                {
                    Content = r.Id,
                    Width = 50,
                    Height = 50
                };
                b.Click += ClickRoomButton;
                panel.Children.Add(b);
            }
        }

        private void ClickRoomButton(object sender, RoutedEventArgs e)
        {
            
            if(sender is Button b)
            {
                int roomId = Convert.ToInt32(b.Content.ToString());
                roomRepository = new RoomRepository();
                Room room = roomRepository.FindById(roomId);
                if(nb > 0)
                {
                    Rooms.Add(room);
                    nb -= room.Max;
                    b.IsEnabled = false;
                }

            }
        }

        private void ValidReservation()
        {
            reservationRepository = new ReservationRepository();
            reservation.Rooms = Rooms.ToList();
            reservation.Status = ReservationStatus.confirm;
            reservation.Rooms.ForEach(r => r.Status = RoomStatus.busy);
            reservationRepository.Create(reservation);
            if(reservation.Id > 0)
            {
                MessageBox.Show("réservation ajoutée avec le numéro " + reservation.Id);
                reservation = new Reservation();
                
            }
        }
    }
}
