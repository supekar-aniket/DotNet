using System.Diagnostics;
using _10_model_in_mvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace _10_model_in_mvc.Controllers
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
            var students = new List<StudentModel> {
                    new StudentModel { RollNo = 11, Name = "Agastya", Gender = "Female", Standard = 11 },
                    new StudentModel { RollNo = 12, Name = "Akash", Gender = "Male", Standard = 10 },
                    new StudentModel { RollNo = 13, Name = "Arpita", Gender = "Female", Standard = 12 }
            };

            ViewData["myStudents"] = students;

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
