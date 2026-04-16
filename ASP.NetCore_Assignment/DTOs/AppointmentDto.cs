using System;
using System.ComponentModel.DataAnnotations;

namespace Asp.net_Core_Assignment_1.DTOs
{
    public class AppointmentDto
    {
        public int AppointmentId { get; set; }

        [Required]
        public int PatientId { get; set; }

        [Required]
        public int DoctorId { get; set; }

        [Required]
        public DateTime AppointmentDate { get; set; }

        [Required]
        public string Status { get; set; }
    }
}
