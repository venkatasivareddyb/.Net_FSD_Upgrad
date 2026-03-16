using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance_polymorphism
{
    class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public int Marks { get; set; }

        public Student(int id, string name, int marks)
        {
            StudentId = id;
            Name = name;
            Marks = marks;
        }

        public virtual string CalculateGrade()
        {
            return Marks > 50 ? "Pass" : "Fail";
        }
    }

    class SchoolStudent : Student
    {
        public SchoolStudent(int id, string name, int marks) : base(id, name, marks) { }
        public override string CalculateGrade() => Marks > 40 ? "Pass" : "Fail";
    }

    class CollegeStudent : Student
    {
        public CollegeStudent(int id, string name, int marks) : base(id, name, marks) { }
        public override string CalculateGrade() => Marks > 50 ? "Pass" : "Fail";
    }

    class OnlineStudent : Student
    {
        public OnlineStudent(int id, string name, int marks) : base(id, name, marks) { }
        public override string CalculateGrade() => Marks > 60 ? "Pass" : "Fail";
    }

    class Assignment5
    {
        static void Main()
        {
            Student[] students =
            {
            new SchoolStudent(1, "Ravi", 45),
            new CollegeStudent(2, "Sita", 55),
            new OnlineStudent(3, "Kiran", 65)
        };

            foreach (var s in students)
            {
                Console.WriteLine($"{s.Name} Grade: {s.CalculateGrade()}");
            }
        }
    }
}
