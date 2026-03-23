
namespace C__Collections
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Category { get; set; }
    }

    class Assignment1
    {
        static void Main()
        {
            List<Product> products = new List<Product> {
            new Product{Id=1,Name="Laptop",Price=55000,Category="Electronics"},
            new Product{Id=2,Name="Phone",Price=25000,Category="Electronics"},
            new Product{Id=3,Name="Shoes",Price=1500,Category="Fashion"},
            new Product{Id=4,Name="Watch",Price=1200,Category="Fashion"},
            new Product{Id=5,Name="TV",Price=40000,Category="Electronics"},
            new Product{Id=6,Name="Bag",Price=800,Category="Fashion"},
            new Product{Id=7,Name="Headphones",Price=2000,Category="Electronics"},
            new Product{Id=8,Name="Book",Price=500,Category="Stationery"},
            new Product{Id=9,Name="Tablet",Price=18000,Category="Electronics"},
            new Product{Id=10,Name="Pen",Price=100,Category="Stationery"}
        };

            foreach (var p in products) Console.WriteLine($"{p.Id} {p.Name} {p.Price} {p.Category}");

            var expensive = products.Where(p => p.Price > 1000);
            Console.WriteLine("\nPrice > 1000:");
            foreach (var p in expensive) Console.WriteLine(p.Name);

            var asc = products.OrderBy(p => p.Price);
            var desc = products.OrderByDescending(p => p.Price);

            Console.WriteLine("\nSorted Asc:");
            foreach (var p in asc) Console.WriteLine($"{p.Name} {p.Price}");

            Console.WriteLine("\nSorted Desc:");
            foreach (var p in desc) Console.WriteLine($"{p.Name} {p.Price}");

            products.RemoveAll(p => p.Id == 3);

            Console.WriteLine("\nAfter Removing Id=3:");
            foreach (var p in products) Console.WriteLine(p.Name);

            var fashion = products.Where(p => p.Category == "Fashion");
            Console.WriteLine("\nFashion Products:");
            foreach (var p in fashion) Console.WriteLine(p.Name);
        }
    }
}
