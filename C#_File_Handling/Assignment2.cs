using System;
using System.Collections.Generic;
using System.Text;
using System;
using System.IO;
namespace C__File_Handling
{
    class Assignment2
    {

        static void AddReport()
        {
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Roll Number: ");
            string roll = Console.ReadLine();

            int[] marks = new int[3];
            for (int i = 0; i < 3; i++)
            {
                Console.Write($"Marks {i + 1}: ");
                marks[i] = int.Parse(Console.ReadLine());
            }

            int total = marks[0] + marks[1] + marks[2];
            double avg = total / 3.0;
            string grade = avg >= 75 ? "A" : avg >= 60 ? "B" : avg >= 40 ? "C" : "Fail";

            string content = $"Student Name: {name}\nRoll Number: {roll}\nMarks: {string.Join(",", marks)}\nTotal: {total}\nAverage: {avg:F2}\nGrade: {grade}";

            File.WriteAllText($"{roll}.txt", content);
            Console.WriteLine("Report saved.");
        }

        static void ViewReport()
        {
            Console.Write("Enter Roll Number: ");
            string roll = Console.ReadLine();
            string path = $"{roll}.txt";
            if (File.Exists(path))
            {
                Console.WriteLine(File.ReadAllText(path));
            }
            else
            {
                Console.WriteLine("Report not found.");
            }
        }
        static void Main()
        {
            while (true)
            {
                Console.WriteLine("1. Add Student Report");
                Console.WriteLine("2. View Student Report");
                Console.WriteLine("3. Exit");
                Console.Write("Choice: ");
                int choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    AddReport();
                }
                else if (choice == 2) ViewReport();
                else break;
            }
        }

    }
}
