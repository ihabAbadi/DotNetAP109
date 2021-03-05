using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CoursMVVM.Models
{
    public class Person : INotifyPropertyChanged
    {
        private int id;
        private string fristName;
        private string lastName;


        public int Id { get => id; set => id = value; }
        public string FristName { get => fristName; set { fristName = value; RaisePorpertyChanged("FristName"); } }
        public string LastName { get => lastName; set { lastName = value; RaisePorpertyChanged("LastName"); } }

        //public bool Save()
        //{
        //    return false;
        //}

        //public bool Update()
        //{
        //    return false;
        //}

        //public bool Delete()
        //{
        //    return false;
        //}

        //public static List<Person> GetPersons()
        //{
        //    return null;
        //}

        //public static Person GetPersonById(int id)
        //{
        //    return null;
        //}

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePorpertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public override string ToString()
        {
            return $"{FristName} {LastName}";
        }
    }
}
