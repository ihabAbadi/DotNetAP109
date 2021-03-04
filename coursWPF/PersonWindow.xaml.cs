using CoursAdoNet.Classes;
using CoursAdoNet.Repositories;
using CoursAdoNet.Tools;
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
    /// Logique d'interaction pour PersonWindow.xaml
    /// </summary>
    public partial class PersonWindow : Window
    {
        public PersonWindow()
        {
            InitializeComponent();
            confirmButton.Click += ConfirmButtonClick;
            PersonRepository personRepository = new PersonRepository(Connection.GetSqlConnection());

            personListBox.ItemsSource = personRepository.FindAll();
            personListView.ItemsSource = personRepository.FindAll();
        }

        public void ConfirmButtonClick(object sender, RoutedEventArgs e)
        {
            Person person = new Person()
            {
                FristName = firstNameTextBox.Text,
                LastName = lastNameTextBox.Text
            };
            PersonRepository personRepository = new PersonRepository(Connection.GetSqlConnection());
            personRepository.Create(person);
            if(person.Id > 0)
            {
                resultTextBlock.Text = $"Personne ajoutée avec l'id {person.Id}";
                personListView.ItemsSource = personRepository.FindAll();
            } 
            else
            {
                resultTextBlock.Text = $"Erreur d'insertion dans la base";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show((personListBox.SelectedItem as Person).LastName);
        }
    }
}
