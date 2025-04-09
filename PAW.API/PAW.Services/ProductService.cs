using APW.Architecture;
using PAW.Architecture.Factory;
using PAW.Architecture.Providers;
using PAW.Data.Repository;
using PAW.Models;

namespace PAW.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Product CreateFakeProduct();
        Task<bool> SaveFakeProductAsync();
        Task<List<Product>> CreateMultipleFakeProductsAsync(int count);
    }
    public class ProductService : IProductService
    {
        private readonly IRestProvider _restProvider;
        private readonly IProductFactory _productFactory;
        private readonly IRepositoryBase<Product> _productRepo;
        public ProductService(
            IRestProvider restProvider,
            IProductFactory productFactory,
            IRepositoryBase<Product> productRepo)
        {
            _restProvider = restProvider;
            _productFactory = productFactory;
            _productRepo = productRepo;
        }
        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            var data = await _restProvider.GetAsync($"http://localhost:5238/ProductApi/all", null);
            var products = JsonProvider.DeserializeSimple<IEnumerable<Product>>(data);
            return products;
        }
        public Product CreateFakeProduct()
        {
            return _productFactory.Create();
        }
        public async Task<bool> SaveFakeProductAsync()
        {
            var fakeProduct = CreateFakeProduct();
            return await _productRepo.CreateAsync(fakeProduct);
        }
        public async Task<List<Product>> CreateMultipleFakeProductsAsync(int count)
        {
            var fakeList = _productFactory.CreateMany(count);
            foreach (var product in fakeList)
            {
                await _productRepo.CreateAsync(product);
            }
            return fakeList;
        }
    }
}