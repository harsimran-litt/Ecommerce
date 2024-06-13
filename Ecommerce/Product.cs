using System;

namespace Ecommerce
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        public Product(int productID, string productName, decimal price, int stock)
        {
            if (productID < 1 || productID > 10000)
                throw new ArgumentOutOfRangeException(nameof(productID), "ProductID has to be between 1 and 10000.");
            if (string.IsNullOrWhiteSpace(productName))
                throw new ArgumentException("ProductName is required!", nameof(productName));
            if (price < 1 || price > 5000)
                throw new ArgumentOutOfRangeException(nameof(price), "Enter Price between 1 and 5000.");
            if (stock < 1 || stock > 100000)
                throw new ArgumentOutOfRangeException(nameof(stock), "Enter Stock between 1 and 100000.");

            ProductID = productID;
            ProductName = productName;
            Price = price;
            Stock = stock;
        }

        public void IncreaseStock(int amount)
        {
            if (amount < 0) throw new ArgumentException("Enter positive value for Amount");
            Stock += amount;
        }

        public void DecreaseStock(int amount)
        {
            if (amount < 0) throw new ArgumentException("Enter poositive values only");
            if (Stock - amount < 0) throw new InvalidOperationException("Stock is empty");
            Stock -= amount;
        }
    }
}
