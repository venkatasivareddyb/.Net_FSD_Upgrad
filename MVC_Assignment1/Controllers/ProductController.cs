using Microsoft.AspNetCore.Mvc;

namespace MVC_Assignment1.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult GetProduct(int id)
        {
            return Content($"Product Id is: {id}");
        }
    }

}
