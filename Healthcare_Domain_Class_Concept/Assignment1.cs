namespace Healthcare_Domain_Class_Concept
{
    class Patient
    {
        public int PatientId;
        public string PatientName;
        public int Age;
        public string Disease;
    }

    class Assignment1
    {
        static void Main(string[] args)
        {
            Patient p1 = new Patient();
            p1.PatientId = 101;
            p1.PatientName = "Ravi Kumar";
            p1.Age = 45;
            p1.Disease = "Diabetes";

            Console.WriteLine("Patient Id: " + p1.PatientId);
            Console.WriteLine("Patient Name: " + p1.PatientName);
            Console.WriteLine("Age: " + p1.Age);
            Console.WriteLine("Disease: " + p1.Disease);
        }
    }

}
