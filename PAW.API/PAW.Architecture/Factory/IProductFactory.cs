using PAW.Models;
namespace PAW.Architecture.Factory
{
   public interface IProductFactory
    {
        Product Create();
        List<Product> CreateMany(int count);
    }
}
