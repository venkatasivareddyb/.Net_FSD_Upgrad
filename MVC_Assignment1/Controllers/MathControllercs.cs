using Microsoft.AspNetCore.Mvc;

namespace MVC_Assignment1.Controllers
{
    public class MathControllercs : Controller
    {
        public IActionResult Add(int a, int b)
        {
            return Content($"Sum: {a + b}");
        }

        public IActionResult Multiply(int a, int b)
        {
            return Content($"Product: {a * b}");
        }

    }
}
