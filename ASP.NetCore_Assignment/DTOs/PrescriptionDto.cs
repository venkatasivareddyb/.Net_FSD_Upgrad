using System.ComponentModel.DataAnnotations;

namespace Asp.net_Core_Assignment_1.DTOs
{
    public class PrescriptionDto
    {
        public int PrescriptionId { get; set; }

        [Required]
        public int AppointmentId { get; set; }

        [Required, MaxLength(200)]
        public string Diagnosis { get; set; }

        [Required, MaxLength(500)]
        public string Medicines { get; set; }

        public string Notes { get; set; }
    }
}
