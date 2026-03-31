using Microsoft.AspNetCore.Mvc;

namespace MVC_Assignment1.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Details(string name, int age)
        {
            return Content($"Name: {name}, Age: {age}");
            ViewData["Name"] = name;
            ViewData["Age"] = age;
            return View();
        }

    }
}
