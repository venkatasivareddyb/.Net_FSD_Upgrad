using Microsoft.AspNetCore.Mvc;

namespace MVC_Assignment1.Controllers
{
    public class TeacherController : Controller
    {
        public IActionResult Index()
        {
            return Content("Teacher Index Page");
        }
        public IActionResult Details()
        {
            return Content("Teacher Profile Page");
        }
    }
}
