using System;
using System.Collections.Generic;
using System.Text;

namespace CashRegister.Models
{
    public class Product
    {
        private int id;
        private string title;
        private decimal price;

        public int Id { get => id; set => id = value; }
        public string Title { get => title; set => title = value; }
        public decimal Price { get => price; set => price = value; }
    }
}
