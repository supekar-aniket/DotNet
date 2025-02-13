using System.Diagnostics;
using _12_passing_modeldata_from_controller_to_view.Models;
using Microsoft.AspNetCore.Mvc;

namespace _12_passing_modeldata_from_controller_to_view.Controllers
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
            /*
             * its for single employee data
             */
            //Employee employee = new Employee()
            //{
            //    EmpId = 1,
            //    EmpName = "Agastya",
            //    Designation = "Manager",
            //    Salary = 10000
            //};

            ////ViewData["empData"] = employee;
            ////ViewBag.empData = employee;
            //TempData["empData"] = employee;

            /*
             * its for multiple employee data
             */

            List<Employee> employees = new List<Employee>() { 
                new Employee{EmpId=101,EmpName="Agastya",Designation="Operator",Salary=20000},
                new Employee{EmpId=102,EmpName="Harshal",Designation="Manager",Salary=30000},
                new Employee{EmpId=103,EmpName="Arpita",Designation="Cashier",Salary=24000},
                new Employee{EmpId=104,EmpName="Akash",Designation="Clirk",Salary=40000},
                new Employee{EmpId=105,EmpName="Anuja",Designation="Developer",Salary=25000},
            };

            //ViewData["empsData"] = employees;
            //ViewBag.empsData = employees;

            TempData["empsData"] = employees;

            return View();
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
