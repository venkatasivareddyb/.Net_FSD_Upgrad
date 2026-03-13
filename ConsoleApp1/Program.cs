using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
namespace ConsoleApp1
{
    internal class Program
    {
        public static void WelcomeMessage()
        {
            Console.WriteLine("Welcome to the world of C#");
        }

        // 2. Greet user from command line
        public static void GreetUser(string[] args)
        {
            if (args.Length > 0)
            {
                Console.WriteLine($"Hi! {args[0]}");
                Console.WriteLine("Welcome to the world of C#");
            }
            else
            {
                Console.WriteLine("Please provide your name as a command line argument.");
            }
        }

        // 3. Numbers between two arguments
        public static void NumbersBetween(string[] args)
        {
            int start = int.Parse(args[0]);
            int end = int.Parse(args[1]);
            for (int i = start; i <= end; i++) Console.WriteLine(i);
        }

        // 4. Odd or Even
        public static void OddOrEven()
        {
            Console.Write("Enter a number: ");
            int num = int.Parse(Console.ReadLine());
            Console.WriteLine(num % 2 == 0 ? "Even" : "Odd");
        }

        // 5. Count odd/even
        public static void CountOddEven()
        {
            int even = 0, odd = 0;
            Console.WriteLine("Enter numbers (type 'end' to stop):");
            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                int n = int.Parse(input);
                if (n % 2 == 0) even++; else odd++;
            }
            Console.WriteLine($"Even: {even}, Odd: {odd}");
        }

        // 6. Fahrenheit to Celsius
        public static void TempConversion()
        {
            Console.Write("Enter Fahrenheit: ");
            double f = double.Parse(Console.ReadLine());
            double c = (f - 32) * 5 / 9;
            Console.WriteLine($"Celsius: {c}");
        }

        // 7. Shopkeeper total
        public static void Shopkeeper()
        {
            double[] prices = { 22.5, 44.5, 9.98 };
            double total = 0;
            Console.WriteLine("Enter product number and quantity (end to stop):");
            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                var parts = input.Split(' ');
                int product = int.Parse(parts[0]);
                int qty = int.Parse(parts[1]);
                total += prices[product - 1] * qty;
            }
            Console.WriteLine($"Total price: {total}");
        }

        // 8. Series of squares
        public static void SquareSeries()
        {
            for (int i = 0; i <= 25; i++) Console.Write(i * i + " ");
        }

        // 9. Factorial
        public static void Factorial()
        {
            Console.Write("Enter number: ");
            int n = int.Parse(Console.ReadLine());
            long fact = 1;
            for (int i = 1; i <= n; i++) fact *= i;
            Console.WriteLine($"Factorial = {fact}");
        }

        // 10. Fibonacci till 40
        public static void Fibonacci()
        {
            int a = 0, b = 1;
            Console.Write($"{a} {b} ");
            while (true)
            {
                int next = a + b;
                if (next > 40) break;
                Console.Write(next + " ");
                a = b; b = next;
            }
        }

        // 11. Multiplication table
        public static void MultiplicationTable()
        {
            Console.Write("Enter number: ");
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= 20; i++) Console.WriteLine($"{n} x {i} = {n * i}");
        }

        // 12. Divisible by 7
        public static void DivisibleBy7()
        {
            for (int i = 200; i <= 300; i++) if (i % 7 == 0) Console.WriteLine(i);
        }

        // 13. Largest of three
        public static void LargestOfThree()
        {
            Console.WriteLine("Enter three numbers:");
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            Console.WriteLine($"Largest = {Math.Max(a, Math.Max(b, c))}");
        }

        // 14. Smallest of five
        public static void SmallestOfFive()
        {
            Console.WriteLine("Enter five numbers:");
            int smallest = int.Parse(Console.ReadLine());
            for (int i = 1; i < 5; i++)
            {
                int n = int.Parse(Console.ReadLine());
                if (n < smallest) smallest = n;
            }
            Console.WriteLine($"Smallest = {smallest}");
        }

        // 15. Marks analysis
        public static void MarksAnalysis()
        {
            int[] marks = new int[10];
            Console.WriteLine("Enter 10 marks:");
            for (int i = 0; i < 10; i++) marks[i] = int.Parse(Console.ReadLine());
            Console.WriteLine($"Total = {marks.Sum()}");
            Console.WriteLine($"Average = {marks.Average()}");
            Console.WriteLine($"Min = {marks.Min()}");
            Console.WriteLine($"Max = {marks.Max()}");
            Console.WriteLine("Ascending: " + string.Join(", ", marks.OrderBy(m => m)));
            Console.WriteLine("Descending: " + string.Join(", ", marks.OrderByDescending(m => m)));
        }

        // 16. Word length
        public static void WordLength()
        {
            Console.Write("Enter word: ");
            string w = Console.ReadLine();
            Console.WriteLine($"Length = {w.Length}");
        }

        // 17. Reverse word
        public static void ReverseWord()
        {
            Console.Write("Enter word: ");
            string w = Console.ReadLine();
            char[] arr = w.ToCharArray();
            Array.Reverse(arr);
            Console.WriteLine("Reverse = " + new string(arr));
        }

        // 18. Compare words
        public static void CompareWords()
        {
            Console.WriteLine("Enter two words:");
            string w1 = Console.ReadLine();
            string w2 = Console.ReadLine();
            Console.WriteLine(w1.Equals(w2, StringComparison.OrdinalIgnoreCase) ? "Same" : "Different");
        }

        // 19. Palindrome
        public static void Palindrome()
        {
            Console.Write("Enter word: ");
            string w = Console.ReadLine();
            string rev = new string(w.Reverse().ToArray());
            Console.WriteLine(w.Equals(rev, StringComparison.OrdinalIgnoreCase) ? "Palindrome" : "Not Palindrome");
        }

        public static void Main(string[] args)
        { 
            WelcomeMessage();
            string[] nameArgs = { "venkata" };
            GreetUser(nameArgs);
            string[] numArgs = { "5", "10" };
            NumbersBetween(numArgs);
            OddOrEven();
            CountOddEven();
            TempConversion();
            Shopkeeper();
            SquareSeries();
            Console.WriteLine();
            Factorial();
            Fibonacci();
            Console.WriteLine();
            MultiplicationTable();
            DivisibleBy7();
            LargestOfThree();
            SmallestOfFive();
            MarksAnalysis();
            WordLength();
            ReverseWord();
            CompareWords();
            Palindrome();


        }

    }
}
