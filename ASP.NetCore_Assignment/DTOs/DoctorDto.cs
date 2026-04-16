using System.ComponentModel.DataAnnotations;

namespace Asp.net_Core_Assignment_1.DTOs
{
    public class DoctorDto
    {
        public int DoctorId { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public string Specialization { get; set; }

        [Range(0, 50)]
        public int Experience { get; set; }

        [Range(0, 10000)]
        public decimal ConsultationFee { get; set; }
    }
}
