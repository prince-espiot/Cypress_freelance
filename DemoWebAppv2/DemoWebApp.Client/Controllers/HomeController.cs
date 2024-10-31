using System.Diagnostics;
using DemoWebApp.Api;
using DemoWebApp.Client.Models;
using DemoWebApp.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace DemoWebApp.Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PseudoDbContext _pseudoDbContext;

        public HomeController(ILogger<HomeController> logger, PseudoDbContext pseudoDbContext)
        {
            _logger = logger;
            _pseudoDbContext = pseudoDbContext;
        }

        public IActionResult Index()
        {
            if (User.Identity?.IsAuthenticated != true)
                return RedirectToAction("Login", "");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> LoginAsync(LoginViewModel model)
        {
            if (model.Username == null || model.Password == null)
            {
                ModelState.AddModelError("EmptyValues", "You must provide a username and a password.");
                return View(model);
            }

            var identityProvider = new IdentityProvider(_pseudoDbContext);
            var credentials = new AppUserCredentials(model.Username, HashHelper.CreateHash(model.Password));
            var principal = identityProvider.Authenticate(credentials, CookieAuthenticationDefaults.AuthenticationScheme);
            if (principal == null)
            {
                ModelState.AddModelError("NoUser", "Incorrect username or password.");
                return View(model);
            }

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                principal,
                new AuthenticationProperties() { AllowRefresh = true, IsPersistent = true });

            return RedirectToAction("", "");
        }

        public async Task<IActionResult> LogoutAsync()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("", "");
        }
    }
}
