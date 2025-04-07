using Microsoft.VisualStudio.TestTools.UnitTesting;
using PAW.Data;
using PAW.Models;
using PAW.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace PAW.Repositories.Tests
{
    [TestClass]
    public class ProductRepositoryTests
    {
        private ProductDb2Context _context;
        private ProductRepository _repository;

        [TestInitialize]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ProductDb2Context>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            _context = new ProductDb2Context(options);
            _repository = new ProductRepository();
        }

        [TestCleanup]
        public void Cleanup()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }

        [TestMethod]
        public async System.Threading.Tasks.Task CreateAsyncShouldInsertProduct()
        {
            var product = new Product
            {
                ProductName = "Test Product",
                Description = "Test Description",
                Rating = 4.5m,
                CategoryId = 1,
                ModifiedBy = "TestUser",
                LastModified = DateTime.Now
            };

            var result = await _repository.CreateAsync(product);

            Assert.IsNotNull(result);
            Assert.AreEqual("Test Product", result.ProductName);
        }

        [TestMethod]
        public async System.Threading.Tasks.Task GetAllProductsAsync_ShouldReturnProducts()
        {
            await CreateAsyncShouldInsertProduct(); 

            var products = await _repository.GetAllProductsAsync();

            Assert.IsNotNull(products);
            Assert.IsTrue(products.Any());
        }

        [TestMethod]
        public async System.Threading.Tasks.Task UpdateAsync_ShouldUpdateProduct()
        {
            var product = await _repository.CreateAsync(new Product
            {
                ProductName = "Original",
                Description = "Original Desc",
                CategoryId = 1,
                ModifiedBy = "User",
                LastModified = DateTime.Now
            });

            product.ProductName = "Updated Name";
            var result = await _repository.UpdateAsync(product);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public async System.Threading.Tasks.Task DeleteAsync_ShouldRemoveProduct()
        {
            var product = await _repository.CreateAsync(new Product
            {
                ProductName = "ToDelete",
                Description = "To be deleted",
                CategoryId = 1,
                ModifiedBy = "User",
                LastModified = DateTime.Now
            });

            var deleted = await _repository.DeleteAsync(product.ProductId);
            Assert.IsTrue(deleted);
        }
    }
}