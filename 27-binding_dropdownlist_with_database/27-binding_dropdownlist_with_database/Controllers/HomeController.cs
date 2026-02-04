using System.Diagnostics;
using _27_binding_dropdownlist_with_database.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace _27_binding_dropdownlist_with_database.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BindingDropdownlistWithDatabaseContext context;

        public HomeController(ILogger<HomeController> logger, BindingDropdownlistWithDatabaseContext context)
        {
            _logger = logger;
            this.context = context;
        }

        public IActionResult Index()
        {
            List<Payment> paymentMethods = context.Payments.ToList();

            ViewBag.PaymentMethods = new SelectList(paymentMethods, "Id", "PaymentMethod");

            return View();
        }

        [HttpPost]
        public IActionResult Index(Payment payment)
        {
            // Store the selected PaymentMethod ID
            ViewBag.CurrentPaymentMethod = payment.PaymentMethod;

            // Repopulate the dropdown list to prevent losing data after post
            ViewBag.PaymentMethods = new SelectList(context.Payments.ToList(), "Id", "PaymentMethod");

            return View(payment);
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
