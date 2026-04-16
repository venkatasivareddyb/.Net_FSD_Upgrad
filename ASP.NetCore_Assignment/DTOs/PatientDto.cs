using System;
using System.ComponentModel.DataAnnotations;

namespace Asp.net_Core_Assignment_1.DTOs
{
    public class PatientDto
    {
        public int PatientId { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [Range(0, 120)]
        public int Age { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required, MaxLength(15)]
        public string ContactNumber { get; set; }

        public string Address { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
