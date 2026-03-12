using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment1_Csharp
{
    internal class remaining
    {
        public static void Execise6()
        {
          Console.WriteLine("Enter side of a square:");
          int side = Convert.ToInt32(Console.ReadLine());
          Console.WriteLine("Area of Square:" + side * side);
          Console.WriteLine("Enter length of a rectangle:");
          int length = Convert.ToInt32(Console.ReadLine());
          Console.WriteLine("Enter breadth of a rectangle:");
          int breadth = Convert.ToInt32(Console.ReadLine());
          Console.WriteLine("Area of Rectangle:" + length * breadth);
        }
        public static void Exercise7()
        {
            Console.WriteLine("Enter a distance:");
            int distance = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Speed:");
            int speed =Convert.ToInt32(Console.ReadLine());
            int time = distance / speed;
            Console.WriteLine("Time taken:" + time);

        }
        public static void Execise8()
        {
            Console.WriteLine("Enter a string:");
            string str = Console.ReadLine();

            if (str.Length < 3)
            {
                Console.WriteLine("Length of the string is less than 3");
            }
            else
            {
                char c = str[2];
                c = char.ToLower(c);
                if (c == 'a' || c =='e' || c == 'i' || c == 'o' || c == 'u')
                {
                    Console.WriteLine("The third character is a vowel");
                }
                Console.WriteLine("The third character is not a vowel");

            }
        }

  
        public static void Main(string[] args)
        {
            Execise6();
            Exercise7();
            Execise8();
        }
    }
}
