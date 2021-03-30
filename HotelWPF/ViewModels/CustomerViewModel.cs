using DAOHotel.Models;
using DAOHotel.Repositories;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace HotelWPF.ViewModels
{
    class CustomerViewModel : ViewModelBase
    {
        private Customer customer;
        private CustomerRepository customerRepository;
        public Customer Customer
        {
            get => customer; set
            {
                customer = value;
                if(customer != null)
                {
                    RaisePropertyChanged("FirstName");
                    RaisePropertyChanged("LastName");
                    RaisePropertyChanged("Phone");
                }
                
            }
        }

        public string FirstName { get => customer.FirstName; set { customer.FirstName = value; RaisePropertyChanged(); } }
        public string LastName { get => customer.LastName; set { customer.LastName = value; RaisePropertyChanged(); } }
        public string Phone { get => customer.Phone; set { customer.Phone = value; RaisePropertyChanged(); } }

        public ObservableCollection<Customer> Customers { get; set; }

        public ICommand ValidCommand { get; set; }

        public ICommand DeleteCommand { get; set; }

        public CustomerViewModel()
        {
            Customer = new Customer();
            customerRepository = new CustomerRepository();
            Customers = new ObservableCollection<Customer>(customerRepository.FindAll());
            ValidCommand = new RelayCommand(ValidCustomer);
            DeleteCommand = new RelayCommand(DeleteCustomer);
        }


        private void ValidCustomer()
        {
            customerRepository = new CustomerRepository();
            customerRepository.Create(Customer);
            if (Customer.Id > 0)
            {
                Customers.Add(Customer);
                Customer = new Customer();
            }
        }

        private void DeleteCustomer()
        {
            customerRepository = new CustomerRepository();
            if(Customer.Id > 0)
            {
                if(customerRepository.Delete(Customer))
                {
                    Customers.Remove(Customer);
                    Customer = new Customer();
                }
            }
        }
    }
}
