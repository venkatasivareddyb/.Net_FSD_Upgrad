using System.ComponentModel.DataAnnotations;

namespace Asp.net_Core_Assignment_1.Models
{
    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; }

        [Required]
        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        [Required]
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        [Required]
        public DateTime AppointmentDate { get; set; }

        [Required, MaxLength(20)]
        public string Status { get; set; } = "Booked";

        // One-to-One relationship
        public Prescription Prescription { get; set; }
    }
}
