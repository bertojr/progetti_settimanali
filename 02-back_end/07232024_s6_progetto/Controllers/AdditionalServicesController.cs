using _07232024_s6_progetto.DAO;
using _07232024_s6_progetto.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _07232024_s6_progetto.Controllers
{
    public class AdditionalServicesController : Controller
    {
        private readonly AdditionalServiceDao _additionalServiceDao;

        public AdditionalServicesController(AdditionalServiceDao additionalServiceDao)
        {
            _additionalServiceDao = additionalServiceDao;
        }

        public IActionResult Index()
        {
            return View(_additionalServiceDao.GetAll());
        }

        public IActionResult Create()
        {
            return View(new AdditionalService());
        }

        [HttpPost]
        public IActionResult Create(AdditionalService service)
        {
            if (ModelState.IsValid)
            {
                _additionalServiceDao.Create(service);
                return RedirectToAction("Index");
            }
            return View(service);
        }

        public IActionResult Delete(int id)
        {
            _additionalServiceDao.Delete(id);
            return RedirectToAction("Index");
        }
    }
}

