using System;
using System.Collections.Generic;
using System.Text;

namespace Healthcare_Domain_Class_Concept
{
    class Doctor
    {
        public int DoctorId { get; set; }
        public string DoctorName { get; set; } = string.Empty;
        public string Specialization { get; set; } = string.Empty;
        public double ConsultationFee { get; set; }
    }



    class Assignment2
    {
        static void Main(string[] args)
        {
            Doctor d1 = new Doctor { DoctorId = 201, DoctorName = "Dr. Meena", Specialization = "Cardiology", ConsultationFee = 500 };
            Doctor d2 = new Doctor { DoctorId = 202, DoctorName = "Dr. Arjun", Specialization = "Orthopedics", ConsultationFee = 700 };

            Console.WriteLine($"{d1.DoctorId} - {d1.DoctorName}, {d1.Specialization}, Fee: {d1.ConsultationFee}");
            Console.WriteLine($"{d2.DoctorId} - {d2.DoctorName}, {d2.Specialization}, Fee: {d2.ConsultationFee}");
        }
    }
}
