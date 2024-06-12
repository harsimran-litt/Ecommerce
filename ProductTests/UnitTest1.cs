using NUnit.Framework;
using Ecommerce;

namespace ProductTests
{
    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ProductID_ShouldSetCorrectly()
        {
            var product = new Product(1, "Test Product", 100.0m, 10);
            Assert.That(product.ProductID, Is.EqualTo(1));
        }

        [Test]
        public void ProductID_ShouldThrowExceptionForNegativeValue()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Product(-1, "Test Product", 100.0m, 10));
        }

        [Test]
        public void ProductID_ShouldBeWithinValidRange()
        {
            var product = new Product(5000, "Test Product", 100.0m, 10);
            Assert.That(product.ProductID, Is.InRange(1, 10000));
        }

        [Test]
        public void ProductName_ShouldSetCorrectly()
        {
            var product = new Product(1, "Test Product", 100.0m, 10);
            Assert.That(product.ProductName, Is.EqualTo("Test Product"));
        }

        [Test]
        public void ProductName_ShouldThrowExceptionForEmptyValue()
        {
            Assert.Throws<ArgumentException>(() => new Product(1, "", 100.0m, 10));
        }

        [Test]
        public void ProductName_ShouldBeValid()
        {
            var product = new Product(1, "Valid Name", 100.0m, 10);
            Assert.That(product.ProductName.Length, Is.InRange(1, 50));
        }

        [Test]
        public void Price_ShouldSetCorrectly()
        {
            var product = new Product(1, "Test Product", 100.0m, 10);
            Assert.That(product.Price, Is.EqualTo(100.0m));
        }

        [Test]
        public void Price_ShouldThrowExceptionForNegativeValue()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Product(1, "Test Product", -100.0m, 10));
        }

        [Test]
        public void Price_ShouldBeWithinValidRange()
        {
            var product = new Product(1, "Test Product", 5000.0m, 10);
            Assert.That(product.Price, Is.InRange(1, 5000));
        }

        [Test]
        public void Stock_ShouldSetCorrectly()
        {
            var product = new Product(1, "Test Product", 100.0m, 10);
            Assert.That(product.Stock, Is.EqualTo(10));
        }

        [Test]
        public void Stock_ShouldThrowExceptionForNegativeValue()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Product(1, "Test Product", 100.0m, -10));
        }

        [Test]
        public void Stock_ShouldBeWithinValidRange()
        {
            var product = new Product(1, "Test Product", 100.0m, 100000);
            Assert.That(product.Stock, Is.InRange(1, 100000));
        }

        [Test]
        public void IncreaseStock_ShouldWorkCorrectly()
        {
            var product = new Product(1, "Test Product", 100.0m, 10);
            product.IncreaseStock(5);
            Assert.That(product.Stock, Is.EqualTo(15));
        }

        [Test]
        public void IncreaseStock_ShouldThrowExceptionForNegativeAmount()
        {
            var product = new Product(1, "Test Product", 100.0m, 10);
            Assert.Throws<ArgumentException>(() => product.IncreaseStock(-5));
        }

        [Test]
        public void IncreaseStock_ShouldHandleZero()
        {
            var product = new Product(1, "Test Product", 100.0m, 10);
            product.IncreaseStock(0);
            Assert.That(product.Stock, Is.EqualTo(10));
        }

        [Test]
        public void DecreaseStock_ShouldWorkCorrectly()
        {
            var product = new Product(1, "Test Product", 100.0m, 10);
            product.DecreaseStock(5);
            Assert.That(product.Stock, Is.EqualTo(5));
        }

        [Test]
        public void DecreaseStock_ShouldThrowExceptionForInsufficientStock()
        {
            var product = new Product(1, "Test Product", 100.0m, 10);
            Assert.Throws<InvalidOperationException>(() => product.DecreaseStock(15));
        }

        [Test]
        public void DecreaseStock_ShouldThrowExceptionForNegativeAmount()
        {
            var product = new Product(1, "Test Product", 100.0m, 10);
            Assert.Throws<ArgumentException>(() => product.DecreaseStock(-5));
        }
    }
}
