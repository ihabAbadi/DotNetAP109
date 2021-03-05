using System;
using System.Collections.Generic;
using System.Text;

namespace CashRegister.Models
{
    public class ProductBasket
    {
        private int qty;

        private Product product;

        public int Qty { get => qty; set => qty = value; }
        public Product Product { get => product; set => product = value; }

        public decimal Total { get => Qty * Product.Price; }
    }
}
