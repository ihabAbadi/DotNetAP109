using CashRegister.ViewModels;
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

namespace CashRegister.Views
{
    /// <summary>
    /// Logique d'interaction pour HomeCashRegisterWindow.xaml
    /// </summary>
    public partial class HomeCashRegisterWindow : Window
    {
        public HomeCashRegisterWindow()
        {
            InitializeComponent();
            DataContext = new HomeViewModel();
        }
    }
}
