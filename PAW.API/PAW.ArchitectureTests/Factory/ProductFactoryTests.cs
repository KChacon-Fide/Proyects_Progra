using Microsoft.VisualStudio.TestTools.UnitTesting;
using PAW.Architecture.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAW.ArchitectureTests.Factory
{
    [TestClass]
    public class ProductFactoryTests
    {
        private ProductFactory _factory;

        [TestInitialize]
        public void Setup()
        {
            _factory = new ProductFactory();
        }

        [TestMethod]
        public void Create_ShouldReturnValidProduct()
        {
            var product = _factory.Create();

            Assert.IsNotNull(product);
            Assert.IsFalse(string.IsNullOrWhiteSpace(product.ProductName));
            Assert.IsFalse(string.IsNullOrWhiteSpace(product.Description));
            Assert.IsNotNull(product.Rating);
            Assert.IsNotNull(product.CategoryId);
            Assert.IsNotNull(product.LastModified);
            Assert.IsFalse(string.IsNullOrWhiteSpace(product.ModifiedBy));
        }

        [TestMethod]
        public void CreateMany_ShouldReturnListOfProducts()
        {
            int count = 5;
            var products = _factory.CreateMany(count);

            Assert.IsNotNull(products);
            Assert.AreEqual(count, products.Count);

            foreach (var p in products)
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(p.ProductName));
                Assert.IsFalse(string.IsNullOrWhiteSpace(p.Description));
                Assert.IsNotNull(p.Rating);
                Assert.IsNotNull(p.CategoryId);
            }
        }
    }
}