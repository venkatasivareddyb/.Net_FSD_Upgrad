using System.ComponentModel.DataAnnotations;

namespace MVC_Assignment3.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required, EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email { get; set; }

        [Required, MinLength(6, ErrorMessage = "Password must be at least 6 characters")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Passwords must match")]
        public string ConfirmPassword { get; set; }
    }
}
