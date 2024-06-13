using System;
using NUnit.Framework;
using Ecommerce;

namespace ProductTests
{
    [TestFixture]
    public class ProductTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ProductID_ShouldSetCorrectly()
        {
            // Arrange
            int productId = 1;
            string productName = "Test Product";
            decimal price = 100.0m;
            int stock = 10;

            // Act
            var product = new Product(productId, productName, price, stock);

            // Assert
            Assert.That(product.ProductID, Is.EqualTo(productId));
        }

        [Test]
        public void ProductID_ShouldThrowExceptionForNegativeValue()
        {
            // Arrange
            int productId = -1;
            string productName = "Test Product";
            decimal price = 100.0m;
            int stock = 10;

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new Product(productId, productName, price, stock));
        }

        [Test]
        public void ProductID_ShouldBeWithinValidRange()
        {
            // Arrange
            int productId = 5000;
            string productName = "Test Product";
            decimal price = 100.0m;
            int stock = 10;

            // Act
            var product = new Product(productId, productName, price, stock);

            // Assert
            Assert.That(product.ProductID, Is.InRange(1, 10000));
        }

        [Test]
        public void ProductName_ShouldSetCorrectly()
        {
            // Arrange
            int productId = 1;
            string productName = "Test Product";
            decimal price = 100.0m;
            int stock = 10;

            // Act
            var product = new Product(productId, productName, price, stock);

            // Assert
            Assert.That(product.ProductName, Is.EqualTo(productName));
        }

        [Test]
        public void ProductName_ShouldThrowExceptionForEmptyValue()
        {
            // Arrange
            int productId = 1;
            string productName = "";
            decimal price = 100.0m;
            int stock = 10;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Product(productId, productName, price, stock));
        }

        [Test]
        public void ProductName_ShouldBeValid()
        {
            // Arrange
            int productId = 1;
            string productName = "Valid Name";
            decimal price = 100.0m;
            int stock = 10;

            // Act
            var product = new Product(productId, productName, price, stock);

            // Assert
            Assert.That(product.ProductName.Length, Is.InRange(1, 50));
        }

        [Test]
        public void Price_ShouldSetCorrectly()
        {
            // Arrange
            int productId = 1;
            string productName = "Test Product";
            decimal price = 100.0m;
            int stock = 10;

            // Act
            var product = new Product(productId, productName, price, stock);

            // Assert
            Assert.That(product.Price, Is.EqualTo(price));
        }

        [Test]
        public void Price_ShouldThrowExceptionForNegativeValue()
        {
            // Arrange
            int productId = 1;
            string productName = "Test Product";
            decimal price = -100.0m;
            int stock = 10;

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new Product(productId, productName, price, stock));
        }

        [Test]
        public void Price_ShouldBeWithinValidRange()
        {
            // Arrange
            int productId = 1;
            string productName = "Test Product";
            decimal price = 5000.0m;
            int stock = 10;

            // Act
            var product = new Product(productId, productName, price, stock);

            // Assert
            Assert.That(product.Price, Is.InRange(1, 5000));
        }

        [Test]
        public void Stock_ShouldSetCorrectly()
        {
            // Arrange
            int productId = 1;
            string productName = "Test Product";
            decimal price = 100.0m;
            int stock = 10;

            // Act
            var product = new Product(productId, productName, price, stock);

            // Assert
            Assert.That(product.Stock, Is.EqualTo(stock));
        }

        [Test]
        public void Stock_ShouldThrowExceptionForNegativeValue()
        {
            // Arrange
            int productId = 1;
            string productName = "Test Product";
            decimal price = 100.0m;
            int stock = -10;

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new Product(productId, productName, price, stock));
        }

        [Test]
        public void Stock_ShouldBeWithinValidRange()
        {
            // Arrange
            int productId = 1;
            string productName = "Test Product";
            decimal price = 100.0m;
            int stock = 100000;

            // Act
            var product = new Product(productId, productName, price, stock);

            // Assert
            Assert.That(product.Stock, Is.InRange(1, 100000));
        }

        [Test]
        public void IncreaseStock_ShouldWorkCorrectly()
        {
            // Arrange
            int productId = 1;
            string productName = "Test Product";
            decimal price = 100.0m;
            int initialStock = 10;
            int increaseAmount = 5;
            var product = new Product(productId, productName, price, initialStock);

            // Act
            product.IncreaseStock(increaseAmount);

            // Assert
            Assert.That(product.Stock, Is.EqualTo(initialStock + increaseAmount));
        }

        [Test]
        public void IncreaseStock_ShouldThrowExceptionForNegativeAmount()
        {
            // Arrange
            int productId = 1;
            string productName = "Test Product";
            decimal price = 100.0m;
            int initialStock = 10;
            int increaseAmount = -5;
            var product = new Product(productId, productName, price, initialStock);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => product.IncreaseStock(increaseAmount));
        }

        [Test]
        public void IncreaseStock_ShouldHandleZero()
        {
            // Arrange
            int productId = 1;
            string productName = "Test Product";
            decimal price = 100.0m;
            int initialStock = 10;
            int increaseAmount = 0;
            var product = new Product(productId, productName, price, initialStock);

            // Act
            product.IncreaseStock(increaseAmount);

            // Assert
            Assert.That(product.Stock, Is.EqualTo(initialStock));
        }

        [Test]
        public void DecreaseStock_ShouldWorkCorrectly()
        {
            // Arrange
            int productId = 1;
            string productName = "Test Product";
            decimal price = 100.0m;
            int initialStock = 10;
            int decreaseAmount = 5;
            var product = new Product(productId, productName, price, initialStock);

            // Act
            product.DecreaseStock(decreaseAmount);

            // Assert
            Assert.That(product.Stock, Is.EqualTo(initialStock - decreaseAmount));
        }

        [Test]
        public void DecreaseStock_ShouldThrowExceptionForInsufficientStock()
        {
            // Arrange
            int productId = 1;
            string productName = "Test Product";
            decimal price = 100.0m;
            int initialStock = 10;
            int decreaseAmount = 15;
            var product = new Product(productId, productName, price, initialStock);

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => product.DecreaseStock(decreaseAmount));
        }

        [Test]
        public void DecreaseStock_ShouldThrowExceptionForNegativeAmount()
        {
            // Arrange
            int productId = 1;
            string productName = "Test Product";
            decimal price = 100.0m;
            int initialStock = 10;
            int decreaseAmount = -5;
            var product = new Product(productId, productName, price, initialStock);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => product.DecreaseStock(decreaseAmount));
        }
    }
}
