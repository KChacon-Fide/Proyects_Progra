using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PAW.Business;
using PAW.Models;
using PAW.Services;

namespace PAW.mvc.Controllers
{
    public class ProductController(IProductService productService) : Controller
    {
        public async Task<ActionResult> Index()
        {

         var products = await productService.GetAllProductsAsync();
            return View(products);
        }
        public ActionResult Details(int id)
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Edit(int id)
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Delete(int id)
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult CreateFake()
        {
            var fakeProduct = productService.CreateFakeProduct();
            return View("CreateFake", fakeProduct);
        }
        public async Task<ActionResult> CreateManyFake(int count = 5)
        {
            var fakeProducts = await productService.CreateMultipleFakeProductsAsync(count);
            return View("Index", fakeProducts); 
        }
        public async Task<IActionResult> GetCreatedProductsPartial(int count = 5)
        {
            var fakeProducts = await productService.CreateMultipleFakeProductsAsync(count);
            return PartialView("_CreatedProductsTable", fakeProducts);
        }
        public async Task<IActionResult> Playground()
        {
            var fakeProducts = await productService.CreateMultipleFakeProductsAsync(5);
            return View("Playground", fakeProducts);
        }
    }
}