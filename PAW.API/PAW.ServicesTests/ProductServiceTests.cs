using APW.Architecture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PAW.Architecture.Factory;
using PAW.Data.Repository;
using PAW.Models;
using PAW.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAW.Services.Tests
{
    [TestClass]
    public class ProductServiceTests
    {
        private Mock<IRestProvider> _restProviderMock;
        private Mock<IProductFactory> _productFactoryMock;
        private Mock<IRepositoryBase<Product>> _productRepoMock;
        private ProductService _service;

        [TestInitialize]
        public void Setup()
        {
            _restProviderMock = new Mock<IRestProvider>();
            _productFactoryMock = new Mock<IProductFactory>();
            _productRepoMock = new Mock<IRepositoryBase<Product>>();

            _service = new ProductService(
                _restProviderMock.Object,
                _productFactoryMock.Object,
                _productRepoMock.Object
            );
        }

        [TestMethod]
        public async System.Threading.Tasks.Task GetAllProductsAsync_ShouldReturnDeserializedProducts()
        {
            
            var mockJson = "[{\"ProductName\":\"Mocked\",\"Description\":\"Test\"}]";
            _restProviderMock
                .Setup(p => p.GetAsync(It.IsAny<string>(), null))
                .ReturnsAsync(mockJson);

            
            var result = await _service.GetAllProductsAsync();

            
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Any());
            
        }

        [TestMethod]
        public void CreateFakeProduct_ShouldCallFactory()
        {
            
            var fake = new Product { ProductName = "FakeProduct" };
            _productFactoryMock.Setup(f => f.Create()).Returns(fake);

            
            var result = _service.CreateFakeProduct();
            
            Assert.AreEqual("FakeProduct", result.ProductName);
        }

        [TestMethod]
        public async System.Threading.Tasks.Task SaveFakeProductAsync_ShouldCallRepo()
        {
            var fake = new Product { ProductName = "ToSave" };
            _productFactoryMock.Setup(f => f.Create()).Returns(fake);
            _productRepoMock.Setup(r => r.CreateAsync(fake)).ReturnsAsync(true);

            var result = await _service.SaveFakeProductAsync();

            Assert.IsTrue(result);
        }

        [TestMethod]
        public async System.Threading.Tasks.Task CreateMultipleFakeProductsAsync_ShouldGenerateAndSaveList()
        {
            var fakes = new List<Product>
            {
                new Product { ProductName = "P1" },
                new Product { ProductName = "P2" }
            };

            _productFactoryMock.Setup(f => f.CreateMany(2)).Returns(fakes);
            _productRepoMock.Setup(r => r.CreateAsync(It.IsAny<Product>())).ReturnsAsync(true);

            var result = await _service.CreateMultipleFakeProductsAsync(2);

            Assert.AreEqual(2, result.Count);
        }
    }
}