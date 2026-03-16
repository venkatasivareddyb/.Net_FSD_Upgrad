using System;
using System.Collections.Generic;
using System.Text;

namespace Healthcare_Domain_Class_Concept
{
    class Appointment
    {
        public int AppointmentId;
        public string PatientName;
        public string DoctorName;
        public DateTime AppointmentDate;

        public Appointment()
        {
            DoctorName = "General Physician";
            AppointmentDate = DateTime.Today;
        }
    }

    class Assignment4
    {
        static void Main()
        {
            Appointment a1 = new Appointment { AppointmentId = 301, PatientName = "Ramesh" };
            Console.WriteLine($"Appointment Id: {a1.AppointmentId}, Patient: {a1.PatientName}, Doctor: {a1.DoctorName}, Date: {a1.AppointmentDate.ToShortDateString()}");
        }
    }
}
