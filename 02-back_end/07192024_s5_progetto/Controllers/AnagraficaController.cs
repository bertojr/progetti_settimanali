using _07192024_s5_progetto.Interface;
using _07192024_s5_progetto.Models;
using Microsoft.AspNetCore.Mvc;

namespace _07192024_s5_progetto.Controllers
{
    public class AnagraficaController : Controller
    {
        private IAnagraficaDAO _anagraficaDAO;
        public AnagraficaController(IAnagraficaDAO anagraficaDAO) 
        { 
            _anagraficaDAO = anagraficaDAO;
        }
        public IActionResult Create()
        {
            return View(new Anagrafica());
        }

        [HttpGet]
        public IActionResult Trasgressori()
        {
            return View(_anagraficaDAO.GetAll());
        }

        [HttpPost]
        public IActionResult Create(Anagrafica newTransgressor)
        {
            _anagraficaDAO.Create(newTransgressor);
            return RedirectToAction("Trasgressori");
        }
    }
}
