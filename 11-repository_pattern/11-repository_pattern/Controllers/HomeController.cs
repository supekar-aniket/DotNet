using System.Diagnostics;
using _11_repository_pattern.Models;
using _11_repository_pattern.Repository;
using Microsoft.AspNetCore.Mvc;

namespace _11_repository_pattern.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly StudentRepository studentRepository = null;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            studentRepository = new StudentRepository();
        }

        public IActionResult Index()
        {
            return View();
        }

        public List<Student> getAllStudents()
        {
            return studentRepository.getAllStudents();
        }

        public Student getStudentById(int id)
        {
            return studentRepository.getStudentById(id);
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
