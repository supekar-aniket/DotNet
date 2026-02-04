using System.Diagnostics;
using _24_session.Models;
using Microsoft.AspNetCore.Mvc;

namespace _24_session.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            HttpContext.Session.SetString("MyKey", "Agastya");
            return View();
        }

        public IActionResult About()
        {
            // this for if we want to access session in action method
            //if (HttpContext.Session.GetString("MyKey") != null)
            //{
            //    ViewBag.Data = HttpContext.Session.GetString("MyKey");
            //}

            return View();
        }

        public IActionResult Details()
        {
            // this for if we want to access session in action methodS
            //if (HttpContext.Session.GetString("MyKey") != null)
            //{
            //    ViewBag.Data = HttpContext.Session.GetString("MyKey");
            //}

            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("MyKey");
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
