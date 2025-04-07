using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PAW.Business;
using PAW.Models;
using PAW.Services;

namespace PAW.mvc.Controllers
{
    public class ProductController(IProductService productService) : Controller
    {

        // GET: ProductController
        public async Task<ActionResult> Index()
        {

         var products = await productService.GetAllProductsAsync();
            return View(products);
        }


        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
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

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductController/Edit/5
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

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductController/Delete/5
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


        // GET: ProductController/CreateFake
        public ActionResult CreateFake()
        {
            var fakeProduct = productService.CreateFakeProduct();
            return View("CreateFake", fakeProduct);
        }

        // GET: ProductController/CreateManyFake?count=5
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
