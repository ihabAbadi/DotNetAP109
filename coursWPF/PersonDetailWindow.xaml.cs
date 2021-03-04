using CoursAdoNet.Classes;
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

namespace coursWPF
{
    /// <summary>
    /// Logique d'interaction pour PersonDetailWindow.xaml
    /// </summary>
    public partial class PersonDetailWindow : Window
    {
        public PersonDetailWindow()
        {
            InitializeComponent();
        }

        public PersonDetailWindow(Person p) : this()
        {
            firstNameLabel.Content = p.FristName;
            lastNameLabel.Content = p.LastName;
        }
    }
}
