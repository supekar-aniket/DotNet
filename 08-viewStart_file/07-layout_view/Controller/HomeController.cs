using Microsoft.AspNetCore.Mvc;

namespace _07_layout_view
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult NoView()
        {
            return View();
        }
    }
}
