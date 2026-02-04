using Microsoft.AspNetCore.Mvc;

namespace _06_controllers_and_actions
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
