using System.Diagnostics;
using _13_strongly_typed_view.Models;
using Microsoft.AspNetCore.Mvc;

namespace _13_strongly_typed_view.Controllers
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
            //Employee employee = new Employee() { 
            //    EmpId = 1,
            //    EmpName = "Agastya",
            //    Designation = "Manager",
            //    Salary = 10000
            //};

            //return View(employee);

            List<Employee> employees = new List<Employee>() {
                new Employee {EmpId=101,EmpName="Agastya",Designation="Manager",Salary=220000},
                new Employee {EmpId=102,EmpName="Harshal",Designation="Operator",Salary=40000},
                new Employee {EmpId=103,EmpName="Arpita",Designation="Incharge",Salary=30000},
                new Employee {EmpId=104,EmpName="Akash",Designation="Developer",Salary=25000},
                new Employee {EmpId=105,EmpName="Anuja",Designation="Peun",Salary=2000},
            };

            return View(employees);
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
