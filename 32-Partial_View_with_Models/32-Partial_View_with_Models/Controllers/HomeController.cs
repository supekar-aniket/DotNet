using System.Diagnostics;
using _32_Partial_View_with_Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace _32_Partial_View_with_Models.Controllers
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

        public IActionResult Products()
        {
            List<Product> products = new List<Product>()
            {
                new Product() {Id = 101, Name = "Mobile", Description = "Best Mobile", Price = 10000.00, Image = "~/Images/mobile.jpg"},
                new Product() {Id = 102, Name = "Laptop", Description = "Best laptop", Price = 35500.00, Image = "~/Images/laptop.jpg"},
                new Product() {Id = 103, Name = "Drone", Description = "Best Drone", Price = 55050.00, Image = "~/Images/Drone.jpg"},
            };

            return View(products);
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
