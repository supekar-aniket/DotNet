using _15_viewImports_file.Models;
using Microsoft.AspNetCore.Mvc;

namespace _15_viewImports_file
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            List<Student> students = new List<Student>() {
                new Student {Id=101,Name="Agastya"},
                new Student {Id=102,Name="Akash"},
                new Student {Id=103,Name="Anuja"},
                new Student {Id=104,Name="Arpita"},
            };

            return View(students);
        }

        public IActionResult About()
        {
            List<Student> students = new List<Student>() {
                new Student {Id=101,Name="Agastya"},
                new Student {Id=102,Name="Akash"},
                new Student {Id=103,Name="Anuja"},
                new Student {Id=104,Name="Arpita"},
            };

            return View(students);
        }

        public IActionResult Contact()
        {
            List<Student> students = new List<Student>() {
                new Student {Id=101,Name="Agastya"},
                new Student {Id=102,Name="Akash"},
                new Student {Id=103,Name="Anuja"},
                new Student {Id=104,Name="Arpita"},
            };

            return View(students);
        }
    }
}
