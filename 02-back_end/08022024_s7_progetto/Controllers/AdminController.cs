using _08022024_s7_progetto.DataModels;
using _08022024_s7_progetto.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace _08022024_s7_progetto.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IProductService _productService;

        public AdminController(IProductService productService)
        {
            _productService = productService;
        }


        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> AllProducts()
        {
            var products = await _productService.GetAll();
            return View(products);
        }

        public IActionResult CreateProduct()
        {
            return View(new Product
            {
                Name = "",
                DeliveryTimeInMinutes = 1
            });
        }

        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productService.Delete(id);
            return RedirectToAction("AllProducts");
        }

        public async Task<IActionResult> EditProduct(int id)
        {
            var product = await _productService.GetById(id);
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProduct(Product newProduct)
        {
            if (ModelState.IsValid)
            {
                await _productService.Create(newProduct);

                return RedirectToAction("AllProducts");
            }

            return View(newProduct);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProduct(Product updateProduct)
        {
            if (ModelState.IsValid)
            {
                await _productService.Update(updateProduct.ProductID, updateProduct);
                return RedirectToAction("AllProducts");
            }

            return View(updateProduct);
        }

    }
}

