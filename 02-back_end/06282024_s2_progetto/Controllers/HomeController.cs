using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using _06282024_s2_progetto.Models;

namespace _06282024_s2_progetto.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
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

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

