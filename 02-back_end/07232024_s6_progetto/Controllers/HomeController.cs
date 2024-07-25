using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using _07232024_s6_progetto.Models;
using _07232024_s6_progetto.DAO;

namespace _07232024_s6_progetto.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly GuestDao _guestDao;

    public HomeController(ILogger<HomeController> logger, GuestDao guestDao)
    {
        _logger = logger;
        _guestDao = guestDao;
    }

    public IActionResult Index()
    {
        return View(new Guest());
    }

    [HttpPost]
    public IActionResult Create(Guest newGuest)
    {
        _guestDao.Create(newGuest);
        return RedirectToAction("Privacy");
    }

    public IActionResult Privacy()
    {
        return View(_guestDao.GetAll());
    }

    public IActionResult Delete(int id)
    {
        _guestDao.Delete(id);
        return RedirectToAction("Privacy");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

