using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

namespace _04_routing_without_mvc.Controllers
{
    //[Route("home")]
    //public class HomeController : Controller
    //{
    //    [Route("/")]
    //    [Route("index")]
    //    public IActionResult Index()
    //    {
    //        return View();
    //    }

    //    [Route("about")]
    //    public IActionResult About()
    //    {
    //        return View();
    //    }

    //    [Route("details/{id?}")]
    //    public int Details(int id)
    //    {
    //        return id;
    //    }
    //}

    //[Route("[controller]")] // [controller] replaced by HomeController
    //public class HomeController : Controller
    //{
    //    [Route("~/")]
    //    [Route("[action]")] // [action] replaced by Index() name
    //    public IActionResult Index()
    //    {
    //        return View();
    //    }

    //    [Route("[action]")] // [action] replaced by About() name
    //    public IActionResult About()
    //    {
    //        return View();
    //    }

    //    [Route("[action]/{id?}")] // [action] replaced by Details() name
    //    public int Details(int? id) // ? for check value is Nullable
    //    {
    //        return id ?? 1; // ?? if value is empty then output is 1
    //    }
    //}

    [Route("[controller]/[action]")] // [controller] replaced by HomeController and [action] replaced by method() names
    public class HomeController : Controller
    {
        [Route("~/")]
        [Route("~/home")]
        public IActionResult Index()
        {
            return View();
        }

        
        public IActionResult About()
        {
            return View();
        }

        [Route("{id?}")] // [action] replaced by Details() name
        public int Details(int? id) // ? for check value is Nullable
        {
            return id ?? 1; // ?? if value is empty then output is 1
        }
    }
}
