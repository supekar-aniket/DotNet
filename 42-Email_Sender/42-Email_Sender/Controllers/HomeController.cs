using _42_Email_Sender.Helper;
using Microsoft.AspNetCore.Mvc;

namespace _42_email_sender.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly EmailHelper _emailHelper;

        public HomeController(ILogger<HomeController> logger, EmailHelper emailHelper)
        {
            _logger = logger;
            _emailHelper = emailHelper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SendEmail()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendEmail(string email, string subject, string message)
        {
            bool response = _emailHelper.SendEmail(email, subject, message);

            if (response)
                TempData["Message"] = "Email sent successfully!";
            else
                TempData["Message"] = "Failed to send email.";

            return RedirectToAction("Index");
        }
    }
}
