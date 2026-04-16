using System.ComponentModel.DataAnnotations;

namespace Asp.net_Core_Assignment_1.Models
{
    public class Prescription
    {
        [Key]
        public int PrescriptionId { get; set; }

        [Required]
        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; }

        [Required, MaxLength(200)]
        public string Diagnosis { get; set; }

        [Required, MaxLength(500)]
        public string Medicines { get; set; }

        [MaxLength(500)]
        public string Notes { get; set; }
    }
}
