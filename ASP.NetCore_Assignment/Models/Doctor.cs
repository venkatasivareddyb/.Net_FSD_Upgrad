using System.ComponentModel.DataAnnotations;

namespace Asp.net_Core_Assignment_1.Models
{
    public class Doctor
    {
        [Key]
        public int DoctorId { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [Required, MaxLength(100)]
        public string Specialization { get; set; }

        [Range(0, 50)]
        public int Experience { get; set; }

        [Range(0, 10000)]
        public decimal ConsultationFee { get; set; }

        // Relationships
        public ICollection<Appointment> Appointments { get; set; }
    }
}
