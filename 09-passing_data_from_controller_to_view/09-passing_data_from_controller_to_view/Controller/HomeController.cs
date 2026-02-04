using Microsoft.AspNetCore.Mvc;

namespace _09_passing_data_from_controller_to_view
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["name"] = "Agstya";
            ViewData["age"] = 22;
            ViewData["datetime"] = DateTime.Now.ToLongDateString();

            string[] arr = {"BMW","Toyota","Tata"};
            ViewData["cars"] = arr;

            ViewData["games"] = new List<string>() {
                "Football","Cricket","Hockey"
            };

            return View();
        }

        public IActionResult ViewBagExample()
        {
            ViewBag.name = "Agastya";
            ViewBag.age = 22;
            ViewBag.datetime = DateTime.Now.ToLongDateString();

            string[] arr = {"BMW","Toyota","Tata"};

            ViewBag.cars = arr;

            ViewBag.games = new List<string>() { 
                "Cricket","Football","Hockey"
            };

            // we can define data as ViewBag and access via ViewData in view file
            ViewBag.color = "red";

            // we can define data as ViewData and access via ViewBag in view file
            ViewData["backgroundColor"] = "Black";

            return View();
        }

        public IActionResult TempDataExample()
        {
            ViewData["viewData"] = "View Data";
            ViewBag.viewBag = "View Bag";
            TempData["tempData"] = "Temp Data";
            TempData.Keep();
            return View();
        }
    }
}
