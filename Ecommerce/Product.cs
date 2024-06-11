using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce
{
    internal class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
    
    public Product(int productID, string productName, decimal price, int stock)
    {
        ProductID = productID;
        ProductName = productName;
        Price = price;
        Stock = stock;
    }
    public void IncreaseStock(int amount)
    {
        if (amount < 0) throw new ArgumentException("Amount cannot be negative");
        Stock += amount;
    }

    public void DecreaseStock(int amount)
    {
        if (amount < 0) throw new ArgumentException("Amount cannot be negative");
        if (Stock - amount < 0) throw new InvalidOperationException("Not enough stock");
        Stock -= amount;
    }
}
}
