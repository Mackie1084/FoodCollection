using Microsoft.AspNetCore.Mvc;
using FoodCollection.Models;

namespace FoodCollection.Controllers
{
    public class DashboardController : Controller
    {
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
