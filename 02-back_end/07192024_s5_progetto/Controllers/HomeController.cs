using _07192024_s5_progetto.Interface;
using _07192024_s5_progetto.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _07192024_s5_progetto.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IVerbaleDAO _verbaleDAO;

        public HomeController(ILogger<HomeController> logger, IVerbaleDAO verbaleDAO)
        {
            _logger = logger;
            _verbaleDAO = verbaleDAO;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetTotalPointsDeductedGroupeByTransgressor()
        {
            return View(_verbaleDAO.GetTotalPointsDeductedGroupeByTransgressor());
        }

        [HttpGet]
        public IActionResult GetTotalViolationsGroupeByTransgressor()
        {
            return View(_verbaleDAO.GetTotalViolationsGroupeByTransgressor());
        }

        [HttpGet]
        public IActionResult GetViolationsWithAmountGreaterThan400()
        {
            return View(_verbaleDAO.GetViolationsWithAmountGreaterThan400());
        }

        [HttpGet]
        public IActionResult GetViolationsWithPointsGreaterThan10()
        {
            return View(_verbaleDAO.GetViolationsWithPointsGreaterThan10());
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
