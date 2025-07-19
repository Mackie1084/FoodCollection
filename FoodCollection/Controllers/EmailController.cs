using Microsoft.AspNetCore.Mvc;
using FoodCollection.Models;
using FoodCollection.Services;

namespace FoodCollection.Controllers
{
    public class EmailController : Controller
    {
        private readonly EmailService _emailService;

        public EmailController(EmailService emailService)
        {
            _emailService = emailService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(EmailModel model)
        {
            if (ModelState.IsValid)
            {
                await _emailService.SendEmailAsync(model);
                ViewBag.Message = "Email sent successfully!";
            }

            return View();
        }
    }
}
