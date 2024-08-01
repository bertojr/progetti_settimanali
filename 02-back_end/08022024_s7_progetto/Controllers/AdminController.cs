using _08022024_s7_progetto.DataModels;
using _08022024_s7_progetto.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace _08022024_s7_progetto.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IProductService _productService;
        private readonly IIngredientService _ingredientService;
        private readonly IUserService _userService;

        public AdminController(IProductService productService,
            IIngredientService ingredientService, IUserService userService)
        {
            _productService = productService;
            _ingredientService = ingredientService;
            _userService = userService;
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

        public async Task<IActionResult> AllIngredients()
        {
            var ingredients = await _ingredientService.GetAll();
            return View(ingredients);
        }

        public async Task<IActionResult> AllUsers()
        {
            var users = await _userService.GetAll();
            return View(users);
        }

        public async Task<IActionResult> CreateProduct()
        {
            var ingredients = await _ingredientService.GetAll();
            ViewBag.Ingredients = new SelectList(ingredients, "IngredientID", "Name");
            return View(new Product
            {
                Name = "",
                DeliveryTimeInMinutes = 1,
            });
        }

        public IActionResult CreateIngredient()
        {
            return View();
        }

        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productService.Delete(id);
            return RedirectToAction("AllProducts");
        }

        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userService.Delete(id);
            return RedirectToAction("AllUsers");
        }

        public async Task<IActionResult> DeleteIngredient(int id)
        {
            await _ingredientService.Delete(id);
            return RedirectToAction("AllIngredients");
        }

        public async Task<IActionResult> EditProduct(int id)
        {
            var product = await _productService.GetById(id);
            return View(product);
        }

        public async Task<IActionResult> EditIngredient(int id)
        {
            var ingredient = await _ingredientService.GetById(id);
            return View(ingredient);
        }

        public async Task<IActionResult> EditUser(int id)
        {
            var user = await _userService.GetById(id);
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProduct(Product newProduct, int[] selectedIngredients)
        {
            if (ModelState.IsValid)
            {
                await _productService.Create(newProduct, selectedIngredients);

                return RedirectToAction("AllProducts");
            }

            return View(newProduct);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateIngredient(Ingredient newIngredient)
        {
            if (ModelState.IsValid)
            {
                await _ingredientService.Create(newIngredient);

                return RedirectToAction("AllIngredients");
            }

            return View(newIngredient);
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditIngredient(Ingredient updateIngredient)
        {
            if (ModelState.IsValid)
            {
                await _ingredientService.Update(updateIngredient.IngredientID, updateIngredient);
                return RedirectToAction("AllIngredients");
            }

            return View(updateIngredient);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUser(User updateUser)
        {
            if (ModelState.IsValid)
            {
                await _userService.Update(updateUser.UserID, updateUser);
                return RedirectToAction("AllUsers");
            }

            return View(updateUser);
        }
    }
}

