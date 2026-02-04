using System.Diagnostics;
using _21_validation_tag_helpers.Models;
using Microsoft.AspNetCore.Mvc;

namespace _21_validation_tag_helpers.Controllers
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
            return View();
        }

        [HttpPost]
        public IActionResult Index(Student student)
        {
            //if (ModelState.IsValid)
            //{
            //    return $"Name is:{student.Name}";
            //} else 
            //{
            //    return "Data is not valid";
            //}

            if (ModelState.IsValid)
            {
                ModelState.Clear();
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
