using System;
using System.Collections.Generic;
using System.Text;

namespace Healthcare_Domain_Class_Concept
{
    class MedicalTest
    {
        public int TestId;
        public string TestName;
        public double TestCost;

        public MedicalTest(int id, string name, double cost)
        {
            TestId = id;
            TestName = name;
            TestCost = cost;
        }
    }

    class Assignment5
    {
        static void Main()
        {
            MedicalTest t1 = new MedicalTest(401, "Blood Test", 300);
            MedicalTest t2 = new MedicalTest(402, "X-Ray", 800);

            Console.WriteLine($"{t1.TestId} - {t1.TestName}, Cost: {t1.TestCost}");
            Console.WriteLine($"{t2.TestId} - {t2.TestName}, Cost: {t2.TestCost}");
        }
    }
}
