using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using _06282024_s2_progetto.Models;

namespace _06282024_s2_progetto.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public HomeController(ILogger<HomeController> logger, IWebHostEnvironment webHostEnvironment)
    {
        _logger = logger;
        _webHostEnvironment = webHostEnvironment;
    }

    public IActionResult Index()
    {
        var products = ProductRepository.GetAllProducts();
        return View(products);
    }

    public IActionResult Details(int id)
    {
        var product = ProductRepository.GetProductById(id);
        if (product == null)
        {
            return NotFound();
        }
        return View(product);
    }

    public IActionResult Privacy()
    {
        return View();
    }
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Product newProduct)
    {
        if (ModelState.IsValid)
        {
            // NON SONO RIUSCITO A FAR FUNZIONARE L'UPLOAD DELL'IMMAGINE
            /* 
            if(newProduct.CoverImageFile != null)
            {
                string uniqueFileName = await UploadedFile(newProduct.CoverImageFile);
                newProduct.CoverImage = uniqueFileName;
            }*/
            ProductRepository.AddProduct(newProduct);
            return RedirectToAction(nameof(Index));
        }
        return View(newProduct);
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {
        ProductRepository.Delete(id);
        return RedirectToAction(nameof(Index));
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    /*
    private async Task<string> UploadedFile(IFormFile file)
    {
        string uniqueFileName = null;

        if(file != null)
        {
            string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
            uniqueFileName = Guid.NewGuid().ToString() + "-" + file.FileName;
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);
            _logger.LogInformation($"Saving file to {filePath}");

            try
            {
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
                _logger.LogInformation("File saved successfully");
            }
            catch(Exception ex)
            {
                _logger.LogError($"Error saving file: {ex.Message}");
            }
            
        }

        return uniqueFileName;
    }*/
}

