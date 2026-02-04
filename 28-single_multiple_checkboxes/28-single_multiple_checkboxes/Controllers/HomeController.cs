using System.Diagnostics;
using _28_single_multiple_checkboxes.Models;
using Microsoft.AspNetCore.Mvc;

namespace _28_single_multiple_checkboxes.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //public IActionResult Index()
        //{
        //    //var model = new Checkboxes()
        //    //{
        //    //    IsBlogActive = false,
        //    //};

        //    var model = new Checkboxes() 
        //    {
        //        IsBlogActive = false,
        //        IsBlogActiveDescription = "I accept terms and conditions"
        //    };

        //    return View(model);
        //}

        //[HttpPost]
        //public IActionResult Index(Checkboxes data)
        //{
        //    var isBlogActive = data.IsBlogActive;

        //    return RedirectToAction(actionName:"Index");
        //}

        public IActionResult Index()
        {
            var model = new Checkbox
            {
                Checkboxes = new List<CheckboxOption>
                {
                    new CheckboxOption()
                    {
                        IsChecked = false,
                        Description = "Cricket",
                        Value = "Cricket"
                    },
                    new CheckboxOption()
                    {
                        IsChecked = false,
                        Description = "Football",
                        Value = "Football"
                    },
                    new CheckboxOption()
                    {
                        IsChecked = false,
                        Description = "Hockey",
                        Value = "Hockey"
                    }
                },
                Sports = new List<string>()
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Index(Checkbox data)
        {
            //data.Checkboxes = new List<CheckboxOption>
            //{
            //    new CheckboxOption { IsChecked = data.Sports?.Contains("Cricket") ?? false, Description = "Cricket", Value = "Cricket" },
            //    new CheckboxOption { IsChecked = data.Sports?.Contains("Football") ?? false, Description = "Football", Value = "Football" },
            //    new CheckboxOption { IsChecked = data.Sports?.Contains("Hockey") ?? false, Description = "Hockey", Value = "Hockey" }
            //};

            return RedirectToAction(actionName:"Index");
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
