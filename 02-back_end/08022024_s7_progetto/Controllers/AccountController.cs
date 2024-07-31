using System.Security.Claims;
using _08022024_s7_progetto.Interfaces;
using _08022024_s7_progetto.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace _08022024_s7_progetto.Controllers
{
    // definisce il controller per la gestione dell'account
    public class AccountController : Controller
    {
        private readonly IAuthService _authService;

        // inizializza il controller con il servizio di autenticazione
        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }

        // restituisce la vista di login
        public IActionResult Login()
        {
            return View();
        }


        // restituisce la vista di registrazione
        public IActionResult Register()
        {
            return View();
        }

        // Azione per visualizzare la pagina di accesso negato
        public IActionResult AccessDenied()
        {
            return View();
        }

        // gestiste la registrazione degli utenti
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(UserDto model)
        {
            // controlla se il modello è valido
            if (ModelState.IsValid)
            {
                // registra l'utente
                _authService.Register(model);
                // reindirizza alla pagina di login
                return RedirectToAction("Login");
            }

            // se il modello non è valido, restituisce la vista con il modello
            // per mostrare eventuali errori
            return View(model);
        }

        // gestisce il login degli utenti
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            // controlla se il modello è valido
            if (ModelState.IsValid)
            {
                // autentica l'utente
                var user = _authService.Login(model.Username, model.Password);
                if (user != null)
                {
                    // crea una lista di claims per l'utente
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.UserID.ToString()),
                        new Claim(ClaimTypes.Name, user.Username),
                    };

                    // aggiunge i ruoli dell'utente ai claims
                    foreach (var role in user.Roles)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, role.Name));
                    }

                    // crea un ClaimsIdenity con i claims dell'utente e lo schema
                    // di autenticazione dei cookie
                    var claimsIdentity = new ClaimsIdentity(claims,
                        CookieAuthenticationDefaults.AuthenticationScheme);

                    // definisce le propietà di autenticazione
                    var authProperty = new AuthenticationProperties
                    {
                        // se true, il cookie persisterà oltre la chiusura del browser
                        IsPersistent = true,
                        // Tempo di scadenza del cookie
                        ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30)
                    };

                    // firma l'utente e crea il cookie di autenticazione
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults
                        .AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperty);

                    // reindirizzo l'utente alla home page
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    // aggiunge un errore al modelstate se le credenziali sono errate
                    ModelState.AddModelError(string.Empty, "Username o password errati");
                }
            }

            // se il modello non è valido o le credenziali sono errate,
            // restituisce la vista con il modello per mostrare evetuali errori
            return View(model);
        }

        // gestisce il logout degli utenti
        public async Task<IActionResult> Logout()
        {
            // Firma l'utente fuori e rimuove il cookie di autenticazione
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            // reindirizza alla pagina di login
            return RedirectToAction("Index", "Home");
        }
    }
}

