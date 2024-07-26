using Microsoft.AspNetCore.Mvc;
using _07232024_s6_progetto.Models;
using _07232024_s6_progetto.DAO;

namespace _07232024_s6_progetto.Controllers
{
    public class GuestsController : Controller
    {
        private readonly GuestDao _guestDao;

        public GuestsController(GuestDao guestDao)
        {
            _guestDao = guestDao;
        }

        public IActionResult Index()
        {
            return View(_guestDao.GetAll());
        }

        public IActionResult Create()
        {
            return View(new Guest());
        }

        [HttpPost]
        public IActionResult Create(Guest guest)
        {
            if (ModelState.IsValid)
            {
                _guestDao.Create(guest);
                return RedirectToAction("Index");
            }
            return View(guest);
        }

        public IActionResult Delete(int id)
        {
            _guestDao.Delete(id);
            return RedirectToAction("Index");
        }
    }
}


