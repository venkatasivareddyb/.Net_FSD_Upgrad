using System;
using System.Collections.Generic;
using System.Text;

namespace Healthcare_Domain_Class_Concept
{
    class Nurse
    {
        public int NurseId { get; set; }
        public string NurseName { get; set; }
        public string Department { get; set; }
    }

    class Assignment7
    {
        static void Main()
        {
            Nurse n1 = new Nurse { NurseId = 501, NurseName = "Anita", Department = "Pediatrics" };
            Console.WriteLine($"Nurse Id: {n1.NurseId}, Name: {n1.NurseName}, Department: {n1.Department}");
        }
    }
}
