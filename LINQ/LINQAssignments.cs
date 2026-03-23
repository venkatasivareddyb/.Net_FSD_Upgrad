using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    class Student
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
            public int Marks { get; set; }
        }

        class Employee
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Department { get; set; }
            public decimal Salary { get; set; }
            public DateTime JoiningDate { get; set; }
        }

        class Customer
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        class Order
        {
            public int Id { get; set; }
            public int CustomerId { get; set; }
            public decimal Amount { get; set; }
            public string CustomerName { get; set; }
            public DateTime OrderDate { get; set; }
            public decimal TotalAmount { get; set; }
        }

        class Product
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Category { get; set; }
            public decimal Price { get; set; }
            public int Stock { get; set; }
        }

        class LINQTasks
        {
            public void Assignment1()
            {
                var students = new List<Student>
            {
                new Student{Id=1, Name="Ravi", Age=20, Marks=80},
                new Student{Id=2, Name="Kiran", Age=22, Marks=70},
                new Student{Id=3, Name="Amit", Age=18, Marks=90}
            };

                var highMarks = students.Where(s => s.Marks > 75);
                var ageRange = students.Where(s => s.Age >= 18 && s.Age <= 25);
                var sorted = students.OrderByDescending(s => s.Marks);
                var nameMarks = students.Select(s => new { s.Name, s.Marks });

                Console.WriteLine("Assignment 1:");
                foreach (var s in highMarks) Console.WriteLine($"{s.Name} - {s.Marks}");
            }

            public void Assignment2()
            {
                var numbers = new List<int> { 5, 10, 15, 20, 25, 30 };
                var evens = numbers.Where(n => n % 2 == 0);
                var greater15 = numbers.Where(n => n > 15);
                var squares = numbers.Select(n => n * n);
                var divisibleBy5 = numbers.Count(n => n % 5 == 0);

                Console.WriteLine("Assignment 2:");
                Console.WriteLine("Squares: " + string.Join(", ", squares));
                Console.WriteLine("Divisible by 5 count: " + divisibleBy5);
            }

            public void Assignment3()
            {
                var names = new List<string> { "Ravi", "Kiran", "Amit", "Raj", "Anil" };
                var startsWithA = names.Where(n => n.StartsWith("A"));
                var sorted = names.OrderBy(n => n);
                var upper = names.Select(n => n.ToUpper());
                var lengthGreater4 = names.Where(n => n.Length > 4);

                Console.WriteLine("Assignment 3:");
                Console.WriteLine("Uppercase: " + string.Join(", ", upper));
            }

            public void Assignment4()
            {
                var employees = new List<Employee>
            {
                new Employee{Id=1, Name="Ravi", Department="IT", Salary=50000},
                new Employee{Id=2, Name="Kiran", Department="HR", Salary=40000},
                new Employee{Id=3, Name="Amit", Department="IT", Salary=60000}
            };

                var itEmployees = employees.Where(e => e.Department == "IT");
                var highestSalary = employees.OrderByDescending(e => e.Salary).First();
                var avgSalary = employees.Average(e => e.Salary);
                var grouped = employees.GroupBy(e => e.Department);
                var deptCount = employees.GroupBy(e => e.Department)
                                         .Select(g => new { g.Key, Count = g.Count() });

                Console.WriteLine("Assignment 4:");
                Console.WriteLine("Highest Salary: " + highestSalary.Name);
                Console.WriteLine("Average Salary: " + avgSalary);
            }

            public void Assignment6()
            {
                var numbers = new List<int> { 1, 2, 3, 2, 4, 5, 3, 6 };
                var distinct = numbers.Distinct();
                var duplicates = numbers.GroupBy(n => n).Where(g => g.Count() > 1).Select(g => g.Key);
                var occurrences = numbers.GroupBy(n => n).Select(g => new { Number = g.Key, Count = g.Count() });

                Console.WriteLine("Assignment 6:");
                Console.WriteLine("Distinct: " + string.Join(", ", distinct));
                Console.WriteLine("Duplicates: " + string.Join(", ", duplicates));
            }

            public void Assignment7()
            {
                var products = new List<Product>
            {
                new Product{Id=1, Name="Laptop", Category="Electronics", Price=80000, Stock=5},
                new Product{Id=2, Name="Phone", Category="Electronics", Price=60000, Stock=15},
                new Product{Id=3, Name="Table", Category="Furniture", Price=10000, Stock=2}
            };

                var lowStock = products.Where(p => p.Stock < 10);
                var top3Expensive = products.OrderByDescending(p => p.Price).Take(3);
                var grouped = products.GroupBy(p => p.Category);
                var stockPerCategory = products.GroupBy(p => p.Category)
                                               .Select(g => new { g.Key, TotalStock = g.Sum(p => p.Stock) });
                var anyOutOfStock = products.Any(p => p.Stock == 0);

                Console.WriteLine("Assignment 7:");
                Console.WriteLine("Any out of stock: " + anyOutOfStock);
            }

            public void Assignment10()
            {
                var employees = new List<Employee>
            {
                new Employee{Id=1, Name="Ravi", Department="IT", Salary=50000},
                new Employee{Id=2, Name="Kiran", Department="HR", Salary=40000},
                new Employee{Id=3, Name="Amit", Department="IT", Salary=60000}
            };

                var sorted = employees.OrderBy(e => e.Department).ThenByDescending(e => e.Salary);

                Console.WriteLine("Assignment 10:");
                foreach (var e in sorted) Console.WriteLine($"{e.Department} - {e.Name} - {e.Salary}");
            }

            public void Assignment15()
            {
                var employees = new List<Employee>
            {
                new Employee{Id=1, Name="Ravi", Department="IT", Salary=50000, JoiningDate=DateTime.Now.AddMonths(-2)},
                new Employee{Id=2, Name="Kiran", Department="HR", Salary=40000, JoiningDate=DateTime.Now.AddYears(-1)},
                new Employee{Id=3, Name="Amit", Department="IT", Salary=60000, JoiningDate=DateTime.Now.AddMonths(-4)}
            };

                var totalEmployees = employees.Count();
                var deptAvgSalary = employees.GroupBy(e => e.Department)
                                             .Select(g => new { g.Key, AvgSalary = g.Average(e => e.Salary) });
                var recentEmployees = employees.Where(e => e.JoiningDate >= DateTime.Now.AddMonths(-6));
                var highestPaidPerDept = employees.GroupBy(e => e.Department)
                                                  .Select(g => g.OrderByDescending(e => e.Salary).First());
                var salaryStats = new
                {
                    Min = employees.Min(e => e.Salary),
                    Max = employees.Max(e => e.Salary),
                    Avg = employees.Average(e => e.Salary)
                };

                Console.WriteLine("Assignment 15:");
                Console.WriteLine("Total Employees: " + totalEmployees);
                Console.WriteLine("Salary Distribution: Min=" + salaryStats.Min + ", Max=" + salaryStats.Max + ", Avg=" + salaryStats.Avg);
            }
        }

        class LINQAssignments
        {
            static void Main(string[] args)
            {
                var tasks = new LINQTasks();
                tasks.Assignment1();
                tasks.Assignment2();
                tasks.Assignment3();
                tasks.Assignment4();
                tasks.Assignment6();
                tasks.Assignment7();
                tasks.Assignment10();
                tasks.Assignment15();
            }
        }
}
