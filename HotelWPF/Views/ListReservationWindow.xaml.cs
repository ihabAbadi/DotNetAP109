using HotelWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HotelWPF.Views
{
    /// <summary>
    /// Logique d'interaction pour ListReservationWindow.xaml
    /// </summary>
    public partial class ListReservationWindow : Window
    {
        public ListReservationWindow()
        {
            InitializeComponent();
            DataContext = new ListReservationViewModel();
        }
    }
}
