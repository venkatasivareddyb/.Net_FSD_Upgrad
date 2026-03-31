using Microsoft.AspNetCore.Mvc;
using MVC_Assignment1.Models;

namespace MVC_Assignment1.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return Content("Student Index Page");
        }
        public IActionResult Profile()
        {
            return Content("Student Profile Page");
        }
        public IActionResult Details()
        {
            ViewData["Name"] = "Alex";
            ViewData["Age"] = 21;
            return View();
        }
        // Passing a strongly-typed model to the view through object initialization
        public IActionResult Details()
        {
            var student = new Student
            {
                Name = "Alice",
                Age = 22
            };
            // Extra info using ViewData
            ViewData["ExtraInfo"] = "Student Management System";

            return View(student);  // Passing model to view
        }

        public IActionResult StudentList()
        {
            // Passing a list of students using ViewData
            ViewData["Students"] = new List<string> { "John", "Mary", "Steve", "Alice" };
            return View();
        }

    }

}
