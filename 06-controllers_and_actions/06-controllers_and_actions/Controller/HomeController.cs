using Microsoft.AspNetCore.Mvc;

namespace _06_controllers_and_actions
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public string Display()
        {
            return "Namastar !!!";
        }

        public int DisplayId(int id)
        {
            return id;
        }
    }
}
