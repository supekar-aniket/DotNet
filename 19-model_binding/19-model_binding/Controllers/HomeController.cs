using System.Diagnostics;
using _19_model_binding.Models;
using Microsoft.AspNetCore.Mvc;

namespace _19_model_binding.Controllers
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
        public string Index(Employee e)
        {
            return $"Name:{e.Name} Gender:{e.Gender} Age:{e.Age} Designation:{e.Designation} Salary:{e.Salary} Married:{e.Married} Description:{e.Description}";
        }

        public string Edit(int id,string name)
        {
            /*
             *  When we enter this request - https://localhost:7013/Home/Edit/3
             *      - then it return - Id is: 3 Name is: 
             *  
             *  When we enter this request - https://localhost:7013/Home/Edit/3?name=Anket
             *      - then it return - Id is: 3 Name is: Anket
             *      
             *      - after id(3) is a query string
             *  
             *  When we enter this request - https://localhost:7013/Home/Edit/3?name=Anket&id=5
             *      - then it return - Id is: 3 Name is: Anket
             *      
             *      - because it follow order FIFO
             *      
             *  When we enter this request - https://localhost:7013/Home/Edit?name=Anket&id=5
             *      - then it return - Id is: 5 Name is: Anket
             *      
             */
            return $"Id is: {id} Name is: {name}";
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
