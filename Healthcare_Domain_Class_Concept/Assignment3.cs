using System;
using System.Collections.Generic;
using System.Text;

namespace Healthcare_Domain_Class_Concept
{
    class Hospital
    {
        public static string HospitalName;
        public static string HospitalAddress;
        public string PatientName;
    }

    class Assignment3
    {
        static void Main()
        {
            Hospital.HospitalName = "City Hospital";
            Hospital.HospitalAddress = "Main Road, Bangalore";

            Hospital p1 = new Hospital { PatientName = "Ravi" };
            Hospital p2 = new Hospital { PatientName = "Sita" };
            Hospital p3 = new Hospital { PatientName = "Kiran" };

            Console.WriteLine($"Hospital: {Hospital.HospitalName}, Address: {Hospital.HospitalAddress}");
            Console.WriteLine("Patient: " + p1.PatientName);
            Console.WriteLine("Patient: " + p2.PatientName);
            Console.WriteLine("Patient: " + p3.PatientName);
        }
    }

}
