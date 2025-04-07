using Bogus;
using PAW.Models;

namespace PAW.Architecture.Factory
{
    public class ProductFactory : IProductFactory
    {
        private readonly Faker<Product> _productFaker;

        public ProductFactory()
        {
            _productFaker = new Faker<Product>()
                .RuleFor(p => p.ProductName, f => f.Commerce.ProductName())
                .RuleFor(p => p.Description, f => f.Commerce.ProductDescription())
                .RuleFor(p => p.Rating, f => f.Random.Decimal(1, 5))
                .RuleFor(p => p.ModifiedBy, f => f.Internet.UserName())
                .RuleFor(p => p.LastModified, f => f.Date.Recent())
                .RuleFor(p => p.CategoryId, f => f.Random.Int(1, 5)); // asumimos que tenés categorías con IDs 1 a 5
        }

        public Product Create()
        {
            return _productFaker.Generate();
        }

        public List<Product> CreateMany(int count)
        {
            return _productFaker.Generate(count);
        }
    }
}
