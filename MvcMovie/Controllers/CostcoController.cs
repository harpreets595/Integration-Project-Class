using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MvcMovie.Controllers
{
    public class CostcoController : Controller
    {
        public IActionResult Index(double amount = 0)
        {

            double totalAmount = amount * 0.02;

            ViewData["cashBackAmount"] = totalAmount;

            return View();
        }


    }
}
