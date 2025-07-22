using Microsoft.AspNetCore.Mvc;
using FoodCollection.Models;
using Twilio.Types;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
            //var report = GenerateMockMonthlyPayments();
            //return View(report);
            var dvm = new DashboardVM();
            dvm.payments = GenerateMockMonthlyPayments();
            dvm.fooditems = GetFoodItemCount();
            return View(dvm);
        }


        public List<FoodItemVM> GetFoodItemCount()
        {
            var lstBookPickupDetails = new List<BookPickupDetail>();

            lstBookPickupDetails.Add(new BookPickupDetail
            {
                BookPickupDetailId = 1,
                QuantityLeft = 3,
                ExpiryDate = DateOnly.Parse("2025-01-01"),
                BookPickupId=1,
                FoodItemId = 1,

            });
            lstBookPickupDetails.Add(new BookPickupDetail
            {
                BookPickupDetailId = 2,
                QuantityLeft = 3,
                ExpiryDate = DateOnly.Parse("2025-01-01"),
                BookPickupId = 2,
                FoodItemId = 2,

            });
            lstBookPickupDetails.Add(new BookPickupDetail
            {
                BookPickupDetailId = 3,
                QuantityLeft = 3,
                ExpiryDate = DateOnly.Parse("2025-01-01"),
                BookPickupId = 3,
                FoodItemId = 2,

            });
            lstBookPickupDetails.Add(new BookPickupDetail
            {
                BookPickupDetailId = 4,
                QuantityLeft = 3,
                ExpiryDate = DateOnly.Parse("2025-01-01"),
                BookPickupId = 4,
                FoodItemId = 3,

            });
            lstBookPickupDetails.Add(new BookPickupDetail
            {
                BookPickupDetailId =5,
                QuantityLeft = 3,
                ExpiryDate = DateOnly.Parse("2025-01-01"),
                BookPickupId = 5,
                FoodItemId = 3,

            });
            lstBookPickupDetails.Add(new BookPickupDetail
            {
                BookPickupDetailId = 6,
                QuantityLeft = 3,
                ExpiryDate = DateOnly.Parse("2025-01-01"),
                BookPickupId = 6,
                FoodItemId = 3,

            });
            lstBookPickupDetails.Add(new BookPickupDetail
            {
                BookPickupDetailId = 7,
                QuantityLeft = 3,
                ExpiryDate = DateOnly.Parse("2025-01-01"),
                BookPickupId = 7,
                FoodItemId = 3,

            });
            var count = lstBookPickupDetails.GroupBy(mp => mp.FoodItemId)
                        .Select(g => new
                        {
                            FoodItemId = g.Key,
                            Count = g.Count()
                        });
            var fooditemvm = new List<FoodItemVM>();
            foreach(var item in count)
            {
                fooditemvm.Add(new FoodItemVM
                {
                    FoodItemId = item.FoodItemId,
                    countofFoodItems = item.Count
                });
            }
            return fooditemvm.OrderByDescending(fd => fd.countofFoodItems).ToList();
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
