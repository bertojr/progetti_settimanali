using Microsoft.AspNetCore.Mvc;
using _07232024_s6_progetto.Models;
using _07232024_s6_progetto.DAO;

namespace _07232024_s6_progetto.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserDao _userDao;

        public UsersController(UserDao userDao)
        {
            _userDao = userDao;
        }

        public IActionResult Index()
        {
            return View(_userDao.GetAll());
        }

        public IActionResult Create()
        {
            return View(new User());
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                _userDao.Create(user);
                return RedirectToAction("Index");
            }
            return View(user);
        }

        public IActionResult Delete(int id)
        {
            _userDao.Delete(id);
            return RedirectToAction("Index");
        }
    }
}


