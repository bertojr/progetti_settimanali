using Microsoft.AspNetCore.Mvc;
using _07232024_s6_progetto.Models;
using _07232024_s6_progetto.DAO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace _07232024_s6_progetto.Controllers
{
    public class ReservationsController : Controller
    {
        private readonly ReservationDao _reservationDao;
        private readonly GuestDao _guestDao;
        private readonly RoomDao _roomDao;
        private readonly ServiceReservationDao _serviceReservationDao;
        private readonly AdditionalServiceDao _additionalServiceDao;
        private readonly ILogger<ReservationsController> _logger;

        public ReservationsController(ReservationDao reservationDao,
            GuestDao guestDao, RoomDao roomDao, ILogger<ReservationsController> logger,
            ServiceReservationDao serviceReservationDao, AdditionalServiceDao additionalServiceDao)
        {
            _reservationDao = reservationDao;
            _guestDao = guestDao;
            _roomDao = roomDao;
            _logger = logger;
            _serviceReservationDao = serviceReservationDao;
            _additionalServiceDao = additionalServiceDao;
        }

        public IActionResult Index()
        {
            return View(_reservationDao.GetAll());
        }

        public IActionResult Create()
        {
            ViewBag.Guests = new SelectList(_guestDao.GetAll(), "CF", "CF");
            ViewBag.Rooms = new SelectList(_roomDao.GetAll(), "RoomID", "RoomID");
            return View(new Reservation
            {
                CheckinDate = DateOnly.FromDateTime(DateTime.Now),
                CheckoutDate = DateOnly.FromDateTime(DateTime.Now)
            });
        }

        [HttpPost]
        public IActionResult Create(Reservation reservation)
        {
            _reservationDao.Create(reservation);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _reservationDao.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Checkout(int id)
        {
            var reservation = _reservationDao.Read(id);
            if (reservation == null) return NotFound();

            return View(reservation);
        }

        public IActionResult AddService(int reservationId)
        {
            var additionalServices = _additionalServiceDao.GetAll();

            ViewBag.ReservationID = reservationId;
            ViewBag.AdditionalServices = new SelectList(additionalServices, "AdditionalServiceID", "Description");

            return View(new ServiceReservation { ReservationID = reservationId });
        }

        [HttpPost]
        public IActionResult AddService(ServiceReservation model)
        {
            var service = _additionalServiceDao.Read(model.AdditionalServiceID);
            model.TotalPrice = model.Quantity * service.Price;

            _serviceReservationDao.Create(model);
            return RedirectToAction("Checkout", new { id = model.ReservationID });
        }
    }
}


