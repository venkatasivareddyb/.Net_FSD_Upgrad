using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace Asp.net_Core_Assignment_1.Models
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [Range(0, 120)]
        public int Age { get; set; }

        [Required, MaxLength(10)]
        public string Gender { get; set; }

        [Required, MaxLength(15)]
        public string ContactNumber { get; set; }

        [MaxLength(200)]
        public string Address { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        // Relationships
        public ICollection<Appointment> Appointments { get; set; }
    }
}
