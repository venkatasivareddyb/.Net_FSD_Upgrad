using System;
namespace Inheritance_polymorphism
{
    class Staff
    {
        public int StaffId { get; set; }
        public string Name { get; set; }
        public double BaseSalary { get; set; }

        public Staff(int id, string name, double baseSalary)
        {
            StaffId = id;
            Name = name;
            BaseSalary = baseSalary;
        }

        public virtual double CalculateSalary()
        {
            return BaseSalary;
        }
    }

    class Doctor : Staff
    {
        public double ConsultationFee { get; set; }

        public Doctor(int id, string name, double baseSalary, double fee)
            : base(id, name, baseSalary)
        {
            ConsultationFee = fee;
        }

        public override double CalculateSalary()
        {
            return BaseSalary + ConsultationFee;
        }
    }

    class Nurse : Staff
    {
        public double NightShiftAllowance { get; set; }

        public Nurse(int id, string name, double baseSalary, double allowance)
            : base(id, name, baseSalary)
        {
            NightShiftAllowance = allowance;
        }

        public override double CalculateSalary()
        {
            return BaseSalary + NightShiftAllowance;
        }
    }

    class LabTechnician : Staff
    {
        public double EquipmentAllowance { get; set; }

        public LabTechnician(int id, string name, double baseSalary, double allowance)
            : base(id, name, baseSalary)
        {
            EquipmentAllowance = allowance;
        }

        public override double CalculateSalary()
        {
            return BaseSalary + EquipmentAllowance;
        }
    }

    class Assignment1
    {
        static void Main()
        {
            Staff[] staffMembers =
            {
            new Doctor(1, "Dr. Meena", 50000, 10000),
            new Nurse(2, "Nurse Anita", 30000, 5000),
            new LabTechnician(3, "Tech Ravi", 25000, 3000)
        };

            foreach (var staff in staffMembers)
            {
                Console.WriteLine($"{staff.Name} Salary: {staff.CalculateSalary()}");
            }
        }
    }
}
