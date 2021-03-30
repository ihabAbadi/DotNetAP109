using DAOHotel.Models;
using DAOHotel.Repositories;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace HotelWPF.ViewModels
{
    class RoomViewModel : ViewModelBase
    {
        private Room room;
        private RoomRepository roomRepository;
        public Room Room
        {
            get => room; set
            {
                room = value;
                if (room != null)
                {
                    RaisePropertyChanged("Max");
                    RaisePropertyChanged("Status");
                    RaisePropertyChanged("Price");
                }

            }
        }

        public int Max { get => room.Max; set { room.Max= value; RaisePropertyChanged(); } }
        public RoomStatus Status { get => room.Status; set { room.Status = value; RaisePropertyChanged(); } }
        public decimal Price { get => room.Price; set { room.Price = value; RaisePropertyChanged(); } }

        public ObservableCollection<Room> Rooms { get; set; }

        public ICommand ValidCommand { get; set; }

        public ICommand DeleteCommand { get; set; }

        public List<RoomStatus> ListStatus { get; set; }

        public RoomViewModel()
        {
            ListStatus = Enum.GetValues(typeof(RoomStatus)).Cast<RoomStatus>().ToList();
            Room = new Room();        
            roomRepository = new RoomRepository();
            Rooms = new ObservableCollection<Room>(roomRepository.FindAll());
            ValidCommand = new RelayCommand(ValidRoom);
            DeleteCommand = new RelayCommand(DeleteRoom);
        }


        private void ValidRoom()
        {
            roomRepository = new RoomRepository();
            roomRepository.Create(Room);
            if (Room.Id > 0)
            {
                Rooms.Add(Room);
                Room = new Room();
            }
        }

        private void DeleteRoom()
        {
            roomRepository = new RoomRepository();
            if (Room.Id > 0)
            {
                if (roomRepository.Delete(Room))
                {
                    Rooms.Remove(Room);
                    Room = new Room();
                }
            }
        }
    }
}
