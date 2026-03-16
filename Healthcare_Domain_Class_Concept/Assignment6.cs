using System;
using System.Collections.Generic;
using System.Text;

namespace Healthcare_Domain_Class_Concept
{
    class Billing
    {
        public string PatientName;
        public double ConsultationFee;
        public double TestCharges;

        public double CalculateTotalBill()
        {
            return ConsultationFee + TestCharges;
        }
    }

    class Assignment6
    {
        static void Main()
        {
            Billing b1 = new Billing { PatientName = "Ramesh", ConsultationFee = 500, TestCharges = 1000 };
            Console.WriteLine($"Patient Name: {b1.PatientName}");
            Console.WriteLine($"Total Bill: {b1.CalculateTotalBill()}");
        }
    }
}
