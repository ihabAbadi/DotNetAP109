using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using HotelWPF.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace HotelWPF.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        //public ICommand CustomerWindowCommand { get; set; }
        //public ICommand RoomWindowCommand { get; set; }
        //public ICommand ListReservationWindowCommand { get; set; }
        //public ICommand ReservationWindowCommand { get; set; }

        public ICommand NewWindowCommand { get; set; }

        public MainViewModel()
        {
            NewWindowCommand = new RelayCommand<string>(ActionOpenWindow);
        }

        private void ActionOpenWindow(string nameWindow)
        {
            switch(nameWindow)
            {
                case "customer":
                    new CustomerWindow().Show();
                    break;
                case "room":
                    new RoomWindow().Show();
                    break;
                case "reservation":
                    new ReservationWindow().Show();
                    break;
                case "listReservation":
                    new ListReservationWindow().Show();
                    break;
            }
        }
    }
}
