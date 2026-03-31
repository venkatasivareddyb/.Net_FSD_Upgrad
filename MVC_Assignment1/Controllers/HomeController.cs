using Microsoft.AspNetCore.Mvc;
using MVC_Assignment1.Models;
using System.Diagnostics;

namespace MVC_Assignment1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Content("Welcome to ASP.NET Core MVC");
            ViewData["Title"] = "Home Page";
            return View();

        }

        public IActionResult About()
        {
            return Content("This is About Page");
        }
        public IActionResult Contact()
        {
            return Content("Contact us at support@test.com");
        }
        public IActionResult CurrentDate()
        {
            return View();
        }
        public IActionResult Eligibility()
        {
            ViewData["Age"] = 20;   // You can change this value
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
