using System.Diagnostics;
using _29_bind_multiple_models_with_single_view.Data;
using _29_bind_multiple_models_with_single_view.Models;
using Microsoft.AspNetCore.Mvc;

namespace _29_bind_multiple_models_with_single_view.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //// This is for single model class
        //public IActionResult Index()
        //{
        //    List<Student> students = new List<Student>
        //    {
        //        new Student { Id=1, Name="Aniket", Standard="11",Address="Karjat" },
        //        new Student { Id=2, Name="Arpita", Standard="12",Address="Chakan" },
        //        new Student { Id=3, Name="Anuja", Standard="10",Address="Baramati" },
        //        new Student { Id=4, Name="Akash", Standard="9",Address="Nashik" },
        //    };

        //    return View(students);
        //}

        //// In this way we can access multiple model classes in single view
        //public IActionResult Index()
        //{
        //    List<Student> students = new List<Student>
        //    {
        //        new Student { Id=1, Name="Aniket", Standard="11",Address="Karjat" },
        //        new Student { Id=2, Name="Arpita", Standard="12",Address="Chakan" },
        //        new Student { Id=3, Name="Anuja", Standard="10",Address="Baramati" },
        //        new Student { Id=4, Name="Akash", Standard="9",Address="Nashik" },
        //    };

        //    List<Teacher> teacher = new List<Teacher>
        //    {
        //        new Teacher { Id=1, Name="Harshal Sir", Department="Math", Salary=30000 },
        //        new Teacher { Id=2, Name="Sane Sir", Department="Computer", Salary=24000 },
        //        new Teacher { Id=3, Name="Rutuja Madam", Department="Statistics", Salary=50000 },
        //    };

        //    // Pass multiple model classes like this
        //    SchoolViewModel viewModel = new SchoolViewModel()
        //    {
        //        StudentList = students,
        //        TeacherList = teacher
        //    };

        //    return View(viewModel);
        //}

        //// You can do this as well
        public IActionResult Index()
        {
            // call StudentData method to get data store in students list
            List<Student> students = SampleData.StudentData();

            // call TeachersData method to get data store in teachers list
            List<Teacher> teachers = SampleData.TeachersData();

            // call EmployeeData method to get data and store in employee list
            List<Employee> employees = SampleData.EmployeeData();

            // Pass multiple model classes like this
            SchoolViewModel viewModel = new SchoolViewModel()
            {
                StudentList = students,
                TeacherList = teachers,
                EmployeeList = employees
            };

            return View(viewModel);
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
