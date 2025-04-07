using Microsoft.AspNetCore.Mvc;
using PAW.Business;
using PAW.Models;
using System.Collections.Generic;

namespace PAW.mvc.Controllers
{
    public abstract class MainController : Controller
    {
        protected readonly IProductManager _productManager;
        public MainController(IProductManager productManager)
        {
            _productManager = productManager;
        }

        public async Task<IEnumerable<Product>> GetAllMyProductAsync()
        {
            return await _productManager.GetAllAsync();
        }
    }
}
