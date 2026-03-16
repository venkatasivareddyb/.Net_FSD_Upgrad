using System;
using System.Collections.Generic;
using System.Text;

namespace Healthcare_Domain_Class_Concept
{
    class PatientRecord
    {
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public int Age { get; set; }
        public string Disease { get; set; }
        public static string HospitalName;

        public PatientRecord(int id, string name, int age, string disease)
        {
            PatientId = id;
            PatientName = name;
            Age = age;
            Disease = disease;
        }

        public void DisplayPatientRecord()
        {
            Console.WriteLine($"Hospital: {HospitalName}");
            Console.WriteLine($"Patient Id: {PatientId}, Name: {PatientName}, Age: {Age}, Disease: {Disease}");
            Console.WriteLine();
        }
    }

    class Assignment8
    {
        static void Main()
        {
            PatientRecord.HospitalName = "Apollo Hospital";

            PatientRecord p1 = new PatientRecord(101, "Ravi", 40, "Fever");
            PatientRecord p2 = new PatientRecord(102, "Sita", 35, "Diabetes");
            PatientRecord p3 = new PatientRecord(103, "Kiran", 50, "Asthma");

            p1.DisplayPatientRecord();
            p2.DisplayPatientRecord();
            p3.DisplayPatientRecord();
        }
    }
}
