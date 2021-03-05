﻿using CoursMVVM.Models;
using CoursMVVM.Repositories;
using CoursMVVM.Tools;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace CoursMVVM.ViewModels
{
    public class PersonViewModel : ViewModelBase
    {
        private string nom;
        private string prenom;
        private ObservableCollection<Person> personnes;
        private PersonRepository personRepository;

        private Person selectedPerson;
        public string Nom
        {
            get => nom;
            set
            {
                nom = value;
                RaisePropertyChanged();
            }
        }
        public string Prenom { get => prenom; set { prenom = value; RaisePropertyChanged(); } }
        public ObservableCollection<Person> Personnes { get => personnes; set => personnes = value; }

        public ICommand CommandAjouterPersonne { get; set; }
        public Person SelectedPerson
        {
            get => selectedPerson; 
            set
            {
                selectedPerson = value;
                Nom = selectedPerson.LastName;
                Prenom = selectedPerson.FristName;
            }
        }

        public PersonViewModel()
        {
            personRepository = new PersonRepository(Connection.GetSqlConnection());
            Personnes = new ObservableCollection<Person>(personRepository.FindAll());
            CommandAjouterPersonne = new RelayCommand(ClickAjoutPersonne);
        }


        public void ClickAjoutPersonne()
        {
            MessageBox.Show(Nom + " " + Prenom);
            Person p = new Person()
            {
                FristName = Prenom,
                LastName = Nom
            };
            personRepository = new PersonRepository(Connection.GetSqlConnection());
            personRepository.Create(p);
            Personnes.Add(p);
        }






        //public event PropertyChangedEventHandler PropertyChanged;

        //private void RaisePorpertyChanged(string propertyName)
        //{
        //    if (PropertyChanged != null)
        //    {
        //        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        //    }
        //}
    }
}
