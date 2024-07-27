using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using _07232024_s6_progetto.Models;
using _07232024_s6_progetto.DAO;
using System.Security.Claims;

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
        var user = HttpContext.User;
        ViewBag.Username = user.Identity.Name;
        ViewBag.Email = user.FindFirst(ClaimTypes.Email)?.Value;
        if (!user.Identity.IsAuthenticated)
        {
            return RedirectToAction("Login", "Account");
        }
        else
        {
            
            return View();
        }
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

