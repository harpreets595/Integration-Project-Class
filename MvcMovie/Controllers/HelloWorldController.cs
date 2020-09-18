using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MvcMovie.Controllers
{
    public class HelloWorld : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        
        // GET: /HelloWorld/
        //public stridng Index()
        //{
        //    return "This is my default action...";
        //}

        // GET: /HelloWorld/Welcome/ 
        public string Welcome(string name, int numTimes = 1)
        {
            return $"hello {name} to this world, Num Times = {numTimes}";

        }
    }
}
