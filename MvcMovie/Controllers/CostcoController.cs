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
            string output = "";
            if (amount > 0) 
            {
                double totalAmount = amount * 0.02;
                output = totalAmount.ToString("C");
            }
            else
            {
                output = "N/A";
            }

            ViewData["amount"] = amount;
            ViewData["cashBackAmount"] = output;

            return View();
        }
    }
}
