using AssementCoreApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AssementCoreApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CalculateOrder(OrderModel orderModel)
        {
            if (orderModel == null)
            {
                return View("Index");
            }
            if (orderModel.OrderAmount < 0)
            {
                ModelState.AddModelError("OrderAmount", "Order Amount Can not be negative");
                return View("Index");
            }
            if (orderModel.OrderAmount >= 100 && orderModel.Customertype == "Loyal")
            {
                orderModel.DiscountAmount = orderModel.OrderAmount * 0.10m;

            }
            else {
                orderModel.DiscountAmount = 0;
            }
            orderModel.TotalAmount = orderModel.OrderAmount - orderModel.DiscountAmount;
            return View("CalculateOrder",orderModel);

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
