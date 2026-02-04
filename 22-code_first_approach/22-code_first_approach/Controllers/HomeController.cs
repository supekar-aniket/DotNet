using System.Diagnostics;
using _22_code_first_approach.Data;
using _22_code_first_approach.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _22_code_first_approach.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext applicationDbContext;

        public HomeController(ILogger<HomeController> logger,ApplicationDbContext applicationDbContext)
        {
            _logger = logger;
            this.applicationDbContext = applicationDbContext;
        }

        //public HomeController(ApplicationDbContext applicationDbContext)
        //{
        //    this.applicationDbContext = applicationDbContext;
        //}

        public async Task<IActionResult> Index()
        {
            var studData = await applicationDbContext.Students.ToListAsync();
            return View(studData);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Student student)
        {
            if (ModelState.IsValid)
            {
                await applicationDbContext.Students.AddAsync(student);
                await applicationDbContext.SaveChangesAsync();
                TempData["insert"] = "Record Inserted!!!";
                return RedirectToAction("Index","Home");
            }
            return View();
        }

        public async Task<IActionResult> Details(int? id)
        {
            if(id==null || applicationDbContext.Students == null)
            {
                return NotFound();
            }

            var studData = await applicationDbContext.Students.FirstOrDefaultAsync(x => x.Id == id);
            
            if (studData == null)
            {
                return NotFound();
            }

            return View(studData);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            var studData = await applicationDbContext.Students.FindAsync(id);
            return View(studData);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id,Student student)
        {
            if(id != student.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                applicationDbContext.Students.Update(student);
                await applicationDbContext.SaveChangesAsync();
                TempData["update"] = "Record Updated!!!";
                return RedirectToAction("Index", "Home");
            }
            return View(student);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || applicationDbContext.Students == null)
            {
                return NotFound();
            }

            var studData = await applicationDbContext.Students.FirstOrDefaultAsync(x => x.Id == id);

            if (studData == null)
            {
                return NotFound();
            }
            return View(studData);
        }

        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(int? id)
        {
            var studData = await applicationDbContext.Students.FindAsync(id);
            if (studData != null)
            {
                applicationDbContext.Students.Remove(studData);
            }
            await applicationDbContext.SaveChangesAsync();
            TempData["delete"] = "Record Deleted!!!";
            return RedirectToAction("Index", "Home");
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
