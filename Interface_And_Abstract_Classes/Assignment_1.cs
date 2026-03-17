namespace Interface_And_Abstract_Classes
{
    using System;

    public interface GovtRules
    {
        double EmployeePF(double basicSalary);
        string LeaveDetails();
        double GratuityAmount(float serviceCompleted, double basicSalary);
    }

    public class Employee
    {
        public int EmpId { get; }
        public string Name { get; }
        public string Dept { get; }
        public string Desg { get; }
        public double BasicSalary { get; }

        public Employee(int empId, string name, string dept, string desg, double basicSalary)
        {
            EmpId = empId;
            Name = name;
            Dept = dept;
            Desg = desg;
            BasicSalary = basicSalary;
        }

        public void Display()
        {
            Console.WriteLine($"ID: {EmpId}, Name: {Name}, Dept: {Dept}, Designation: {Desg}, Basic Salary: {BasicSalary}");
        }
    }

    public class TCS : Employee, GovtRules
    {
        public TCS(int empId, string name, string dept, string desg, double basicSalary)
            : base(empId, name, dept, desg, basicSalary) { }

        public double EmployeePF(double basicSalary)
        {
            double employeePF = 0.12 * basicSalary;
            double employerContribution = 0.0833 * basicSalary;
            double pensionFund = 0.0367 * basicSalary;
            Console.WriteLine($"Employee PF: {employeePF}, Employer PF: {employerContribution}, Pension Fund: {pensionFund}");
            return employeePF + employerContribution;
        }

        public string LeaveDetails()
        {
            return "Casual Leave: 1 per month\nSick Leave: 12 per year\nPrivilege Leave: 10 per year";
        }

        public double GratuityAmount(float serviceCompleted, double basicSalary)
        {
            if (serviceCompleted > 20) return 3 * basicSalary;
            else if (serviceCompleted > 10) return 2 * basicSalary;
            else if (serviceCompleted > 5) return basicSalary;
            else return 0;
        }
    }

    public class Accenture : Employee, GovtRules
    {
        public Accenture(int empId, string name, string dept, string desg, double basicSalary)
            : base(empId, name, dept, desg, basicSalary) { }

        public double EmployeePF(double basicSalary)
        {
            double employeePF = 0.12 * basicSalary;
            double employerContribution = 0.12 * basicSalary;
            Console.WriteLine($"Employee PF: {employeePF}, Employer PF: {employerContribution}");
            return employeePF + employerContribution;
        }

        public string LeaveDetails()
        {
            return "Casual Leave: 2 per month\nSick Leave: 5 per year\nPrivilege Leave: 5 per year";
        }

        public double GratuityAmount(float serviceCompleted, double basicSalary)
        {
            return 0; // Not applicable
        }
    }

    class Assignment_1
    {
        static void Main()
        {
            TCS tcsEmp = new TCS(101, "Ravi", "IT", "Developer", 30000);
            tcsEmp.Display();
            Console.WriteLine(tcsEmp.LeaveDetails());
            Console.WriteLine("Gratuity: " + tcsEmp.GratuityAmount(12, tcsEmp.BasicSalary));
            tcsEmp.EmployeePF(tcsEmp.BasicSalary);

            Console.WriteLine();

            Accenture accEmp = new Accenture(201, "Priya", "HR", "Manager", 40000);
            accEmp.Display();
            Console.WriteLine(accEmp.LeaveDetails());
            Console.WriteLine("Gratuity: " + accEmp.GratuityAmount(8, accEmp.BasicSalary));
            accEmp.EmployeePF(accEmp.BasicSalary);
        }
    }
}
