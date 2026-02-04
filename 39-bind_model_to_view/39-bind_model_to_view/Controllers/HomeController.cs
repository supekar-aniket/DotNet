using System.Diagnostics;
using _39_bind_model_to_view.Models;
using Microsoft.AspNetCore.Mvc;

namespace _39_bind_model_to_view.Controllers
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
        public Calculation Calculate(float num1, float num2)
        {
            Calculation calculation = new Calculation();

            calculation.Add = num1 + num2;
            calculation.Subtract = num1 - num2;
            calculation.Multiply = num1 * num2;
            calculation.Division = (float)num1 / num2;

            return calculation;
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
