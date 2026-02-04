using System.Diagnostics;
using _25_login_form_with_database_session_logout.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _25_login_form_with_database_session_logout.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly LoginFormWithDatabaseSessionLogoutContext dbContext;

        public HomeController(ILogger<HomeController> logger, LoginFormWithDatabaseSessionLogoutContext dbContext)
        {
            _logger = logger;
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            if(HttpContext.Session.GetString("UserSession") != null)
            {
                return RedirectToAction(actionName: "Dashboard");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(User user)
        {
            var myUser = await dbContext.Users.Where(x => x.Email == user.Email && x.Password == user.Password).FirstOrDefaultAsync();
            if (myUser != null)
            {
                HttpContext.Session.SetString("UserSession", myUser.Email);
                return RedirectToAction(actionName: "Dashboard");
            } 
            else
            {
                ViewBag.ErrorMessage = "Login Failed";
            }

            return View();
        }

        public IActionResult Dashboard()
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                ViewBag.MySession = HttpContext.Session.GetString("UserSession").ToString();
            }
            else
            {
                return RedirectToAction(actionName: "Login");
            }

            return View();
        }

        public IActionResult Logout()
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                HttpContext.Session.Remove("UserSession");
                return RedirectToAction(actionName:"Login");
            }
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {
            if (ModelState.IsValid)
            {
                await dbContext.Users.AddAsync(user);
                await dbContext.SaveChangesAsync();
                TempData["SuccesMessage"] = "Register Successfully!!!";
                return RedirectToAction(actionName:"Login");
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
