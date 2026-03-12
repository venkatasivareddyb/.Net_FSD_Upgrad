using System.Transactions;

namespace Assignment1_Csharp
{
    internal class Program
    {
        static void Execise1()
        {
            Console.WriteLine("Enter NUmber 1:");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter NUmber 2:");
            int num2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Quotient:{ num2 / num1}");
        }
        static void Execise2()
        { 
        Console.WriteLine("Enter Kilometers:");
        int km = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine($"Meters:{ km * 1000}m");
        }
        public static void Execise3()
        {
            int sum = 0;
            double average;
            Console.WriteLine("Enter 5 Numbers:");
            for (int i=0;i<5; i++)
            {
                Console.WriteLine("Number" +i+":");
                int num = Convert.ToInt32(Console.ReadLine());
                
                sum += num;
            }
            Console.WriteLine($"Sum:{sum}");
            Console.WriteLine($"Average:{sum / 5}");

        }
        public static void Execise4()
        {
            Console.WriteLine("Enter a Number:");
            int num = Convert.ToInt32(Console.ReadLine());
            if (num % 2 == 0)
            {
                Console.WriteLine("Even");
            }
            else
            {
                Console.WriteLine("Odd");
            }
        }
        public static void Execise5()
        {
            Console.WriteLine("Enter Number 1:");
            int num1 =Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Number 2:");
            int num2 = int.Parse(Console.ReadLine());
            if (num1> num2)
            {
                Console.WriteLine($"Greater Number is:{num1}");
            }
            else if (num2 > num1)
            {
                Console.WriteLine($"Greater Number is:{num2}");
            }
            else
            {
                Console.WriteLine("Both numbers are equal");
            }

        }

        static void Main(string[] args)
        {
            Execise1();
            Execise2();
            Execise3();
            Execise4();
            Execise5();
        }
    }
}
