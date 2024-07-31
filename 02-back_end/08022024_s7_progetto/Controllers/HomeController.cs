using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using _08022024_s7_progetto.Models;
using _08022024_s7_progetto.DataModels;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace _08022024_s7_progetto.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _dbContext;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    public async Task<IActionResult> Index()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        var user = await _dbContext.Users
                .FirstOrDefaultAsync(u => u.UserID.ToString() == userId);
        return View(user);

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

