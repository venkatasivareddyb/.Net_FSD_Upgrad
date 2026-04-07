using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using MVC_Assignment3.Models;
using MVC_Assignment3.ViewModels;

namespace MVC_Assigment3.Controllers
{
    public class UserController : Controller
    {
        // GET: Register
        public IActionResult Register() => View();

        // POST: Register
        [HttpPost]
        public IActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                // Save user to DB (mock for now)
                TempData["Message"] = "Registration successful!";
                return RedirectToAction("Login");
            }
            return View(user);
        }

        // GET: Login
        public IActionResult Login() => View();

        // POST: Login
        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            // Mock validation
            if (email == "test@example.com" && password == "password")
            {
                HttpContext.Session.SetString("UserEmail", email);
                return RedirectToAction("Profile");
            }
            ViewBag.Error = "Invalid credentials";
            return View();
        }

        // GET: Profile
        public IActionResult Profile()
        {
            var email = HttpContext.Session.GetString("UserEmail");
            if (email == null) return RedirectToAction("Login");

            var vm = new UserViewModel { Name = "Test User", Email = email };
            return View(vm);
        }

        // GET: Edit Profile
        public IActionResult Edit() => View();

        // POST: Edit Profile
        [HttpPost]
        public IActionResult Edit(UserViewModel vm)
        {
            if (ModelState.IsValid)
            {
                TempData["Message"] = "Profile updated!";
                return RedirectToAction("Profile");
            }
            return View(vm);
        }

        // Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
