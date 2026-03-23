using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace C__Collections
{
    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Marks { get; set; }
    }

    class Assignment2
    {
        static void Main()
        {
            Dictionary<int, Student> students = new Dictionary<int, Student> {
            {1,new Student{Id=1,Name="Ravi",Marks=80}},
            {2,new Student{Id=2,Name="Priya",Marks=70}},
            {3,new Student{Id=3,Name="Arjun",Marks=90}},
            {4,new Student{Id=4,Name="Meena",Marks=65}},
            {5,new Student{Id=5,Name="Kiran",Marks=85}}
        };

            var s = students[3];
            Console.WriteLine($"Retrieved: {s.Name}");

            Console.WriteLine(students.ContainsKey(2) ? "Exists" : "Not Found");

            students[2].Marks = 95;

            students.Remove(4);

            Console.WriteLine("\nAll Students:");
            foreach (var kv in students) Console.WriteLine($"{kv.Value.Name} {kv.Value.Marks}");

            var toppers = students.Values.Where(x => x.Marks > 75);
            Console.WriteLine("\nAbove 75:");
            foreach (var t in toppers) Console.WriteLine(t.Name);
        }
    }

}
