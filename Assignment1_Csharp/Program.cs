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
        static void Main(string[] args)
        {
            Execise1();
        }
    }
}
