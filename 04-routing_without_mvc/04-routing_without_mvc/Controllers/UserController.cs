using Microsoft.AspNetCore.Mvc;

namespace _04_routing_without_mvc.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
