using _07192024_s5_progetto.Interface;
using _07192024_s5_progetto.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace _07192024_s5_progetto.Controllers
{
    public class VerbaleController : Controller
    {
        private readonly IVerbaleDAO _verbaleDAO;
        private readonly IAnagraficaDAO _anagraficaDAO;
        private readonly ITipoViolazioneDAO _tipoViolazioneDAO;
        public VerbaleController(IVerbaleDAO verbaleDAO, IAnagraficaDAO anagraficaDAO, ITipoViolazioneDAO tipoViolazioneDAO) 
        { 
            _verbaleDAO = verbaleDAO;
            _anagraficaDAO = anagraficaDAO;
            _tipoViolazioneDAO = tipoViolazioneDAO;
        }
        public IActionResult Create()
        {
            ViewBag.Anagrafica = new SelectList(_anagraficaDAO.GetAll(), "AnagraficaID", "Cognome");
            ViewBag.Violazioni = new SelectList(_tipoViolazioneDAO.GetAll(), "ViolazioneID", "Descrizione");
            return View(new Verbale());
        }

        [HttpGet]
        public IActionResult Verbali()
        {
            return View(_verbaleDAO.GetAll());
        }

        [HttpPost]
        public IActionResult Create(Verbale newVerbale)
        {
            _verbaleDAO.Create(newVerbale);
            return RedirectToAction("Verbali");
        }
    }
}
