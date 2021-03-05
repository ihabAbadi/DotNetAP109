using CashRegister.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace CashRegister.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private int productId;
        private decimal total;
        private DateTime dateTime;
        private ObservableCollection<ProductBasket> basketProducts;
        private ProductBasket basketProductSelected;
        private int qty;

        public int ProductId { get => productId; set => productId = value; }
        public decimal Total { get => total; set => total = value; }
        public DateTime DateTime { get => dateTime; set => dateTime = value; }
        public ObservableCollection<ProductBasket> BasketProducts { get => basketProducts; set => basketProducts = value; }
        public ProductBasket BasketProductSelected { get => basketProductSelected; set => basketProductSelected = value; }

        public ICommand ConfirmProductCommand { get; set; }
        public ICommand DeleteProductCommand { get; set; }
        public ICommand QtyCommand { get; set; }
        public ICommand DisplayManagerProductCommand { get; set; }

        public HomeViewModel()
        {
            BasketProducts = new ObservableCollection<ProductBasket>();
            ConfirmProductCommand = new RelayCommand(ConfirmProduct);
            DeleteProductCommand = new RelayCommand(DeleteProduct);
            QtyCommand = new RelayCommand<int>(QtyProduct);
            DisplayManagerProductCommand = new RelayCommand(DisplayProductManager);
        }

        private void ConfirmProduct()
        {

        }

        private void DeleteProduct()
        {

        }

        private void QtyProduct(int id)
        {

        }

        private void DisplayProductManager()
        {

        }
    }
}
