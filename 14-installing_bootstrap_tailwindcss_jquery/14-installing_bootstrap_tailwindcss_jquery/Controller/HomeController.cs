using Microsoft.AspNetCore.Mvc;

namespace _14_installing_bootstrap_tailwindcss_jquery
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
