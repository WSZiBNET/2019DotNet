using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CarRent.Models;

namespace CarRent.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Website created to rent a car";
            return View();
        }

        public IActionResult Cars()
        {
            ViewData["Message"] = "Find your car";

            return View();
        }

        public IActionResult ByBrand()
        {
            ViewData["Message"] = "Find your car by Brand";



            return View();
        }

        public IActionResult ByType()
        {
            ViewData["Message"] = "Find your car by Type";

            return View();
        }

        public IActionResult ByProductionDate()
        {
            ViewData["Message"] = "Find your car by Production Date";

            return View();
        }

        public IActionResult ByEquipment()
        {
            ViewData["Message"] = "Find your car by ByEquipment";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
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
