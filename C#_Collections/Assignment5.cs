using System;
using System.Collections.Generic;
using System.Text;

namespace C__Collections
{
    class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Disease { get; set; }
    }

    class Assignment5
    {
        static void Main()
        {
            Queue<Patient> q = new Queue<Patient>();
            q.Enqueue(new Patient { Id = 1, Name = "Ravi", Disease = "Flu" });
            q.Enqueue(new Patient { Id = 2, Name = "Priya", Disease = "Cold" });
            q.Enqueue(new Patient { Id = 3, Name = "Arjun", Disease = "Fever" });
            q.Enqueue(new Patient { Id = 4, Name = "Meena", Disease = "Asthma" });
            q.Enqueue(new Patient { Id = 5, Name = "Kiran", Disease = "Diabetes" });

            q.Dequeue();
            q.Dequeue();

            Console.WriteLine($"Next Patient: {q.Peek().Name}");

            Console.WriteLine("\nRemaining:");
            foreach (var p in q) Console.WriteLine(p.Name);
        }
    }

}
