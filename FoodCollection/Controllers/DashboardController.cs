using Microsoft.AspNetCore.Mvc;
using FoodCollection.Models;
using Twilio.Types;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace FoodCollection.Controllers
{
    public class DashboardController : Controller
    {

        public IActionResult TestingTwilio()
        {
            var accountSid = "ACe455f162e0ca4f29dde0ae566d39e6e7";
            var authToken = "bf430cb04e11d29eb306df123482cc67";
            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                body: "Hello from Twilio!",
                from: new Twilio.Types.PhoneNumber("+13159037147"), // Twilio number
                to: new Twilio.Types.PhoneNumber("+6586577651")     // Recipient number
            );

            return View();
        }
        public IActionResult Index()
        {
            var report = GenerateMockMonthlyPayments();
            return View(report);
        }


        public List<Payment> GenerateMockMonthlyPayments()
        {
            var monthlyPayments = new List<Payment>();

            monthlyPayments.Add(new Payment
            {
                PaymentId = 1,
                PaymentMethod = "Cash",
                Amount = 1000,
                Date = DateOnly.Parse("2025-01-01"),
                BookPickupId = 1

            });

            monthlyPayments.Add(new Payment
            {
                PaymentId = 2,
                PaymentMethod = "Credit",
                Amount = 1500,
                Date = DateOnly.Parse("2025-02-02"),
                BookPickupId = 3

            });

            monthlyPayments.Add(new Payment
            {
                PaymentId = 3,
                PaymentMethod = "Cash",
                Amount = 1000,
                Date = DateOnly.Parse("2025-03-03"),
                BookPickupId = 2

            });

            monthlyPayments.Add(new Payment
            {
                PaymentId = 4,
                PaymentMethod = "Cash",
                Amount = 3000,
                Date = DateOnly.Parse("2025-04-04"),
                BookPickupId = 4

            });

            monthlyPayments.Add(new Payment
            {
                PaymentId = 5,
                PaymentMethod = "Credit",
                Amount = 2000,
                Date = DateOnly.Parse("2025-04-04"),
                BookPickupId = 5

            });

            monthlyPayments.Add(new Payment
            {
                PaymentId = 6,
                PaymentMethod = "Cash",
                Amount = 1000,
                Date = DateOnly.Parse("2025-06-06"),
                BookPickupId = 6

            });

            monthlyPayments.Add(new Payment
            {
                PaymentId = 7,
                PaymentMethod = "Cash",
                Amount = 5000,
                Date = DateOnly.Parse("2025-07-07"),
                BookPickupId = 7

            });

            return monthlyPayments.OrderBy(mp=>mp.Date).ToList();
        }

    }
}
