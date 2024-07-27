using Microsoft.AspNetCore.Mvc;
using _07232024_s6_progetto.Models;
using _07232024_s6_progetto.DAO;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;

namespace _07232024_s6_progetto.Controllers
{
    public class RoomsController : Controller
    {
        private readonly RoomDao _roomDao;
        private readonly ILogger<RoomsController> _logger;

        public RoomsController(RoomDao roomDao, ILogger<RoomsController> logger)
        {
            _roomDao = roomDao;
            _logger = logger;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View(_roomDao.GetAll());
        }

        [Authorize]
        public IActionResult Create()
        {
            return View(new Room());
        }

        [HttpPost]
        public IActionResult Create(Room room)
        {
            if (ModelState.IsValid)
            {
                _roomDao.Create(room);
                return RedirectToAction("Index");
            }
            return View(room);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _roomDao.Delete(id);
            return RedirectToAction("Index");
        }
    }
}


