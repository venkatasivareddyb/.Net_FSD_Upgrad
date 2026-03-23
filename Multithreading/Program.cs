using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Multithreading
{
    class Assignment1
    {
        private List<int> numbers;
        private List<int> partialSums;

        public Assignment1()
        {
            numbers = Enumerable.Range(1, 50).ToList();
            partialSums = new List<int>(new int[5]);
        }

        public void Run()
        {
            int partSize = numbers.Count / 5;
            Thread[] threads = new Thread[5];

            for (int i = 0; i < 5; i++)
            {
                int start = i * partSize;
                int end = (i + 1) * partSize;
                int threadIndex = i;

                threads[i] = new Thread(() =>
                {
                    var part = numbers.Skip(start).Take(partSize).ToList();
                    int sum = part.Sum();
                    partialSums[threadIndex] = sum;

                    Console.WriteLine($"Thread {threadIndex + 1} Numbers: {string.Join(", ", part)}");
                    Console.WriteLine($"Thread {threadIndex + 1} Sum: {sum}");
                });
            }

            foreach (var t in threads) t.Start();
            foreach (var t in threads) t.Join();

            int finalSum = partialSums.Sum();
            Console.WriteLine($"Final Sum: {finalSum}");
        }
    }

    class BankAccount
    {
        public int Balance { get; private set; }
        private object lockObj = new object();

        public BankAccount(int initialBalance)
        {
            Balance = initialBalance;
        }

        // Without synchronization
        public void WithdrawUnsafe(int amount)
        {
            if (Balance >= amount)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name} withdrawing {amount}");
                Balance -= amount;
                Console.WriteLine($"{Thread.CurrentThread.Name} new balance: {Balance}");
            }
            else
            {
                Console.WriteLine($"{Thread.CurrentThread.Name} insufficient funds!");
            }
        }

        // With synchronization
        public void WithdrawSafe(int amount)
        {
            lock (lockObj)
            {
                if (Balance >= amount)
                {
                    Console.WriteLine($"{Thread.CurrentThread.Name} withdrawing {amount}");
                    Balance -= amount;
                    Console.WriteLine($"{Thread.CurrentThread.Name} new balance: {Balance}");
                }
                else
                {
                    Console.WriteLine($"{Thread.CurrentThread.Name} insufficient funds!");
                }
            }
        }
    }

    class Assignment2
    {
        public void RunUnsafe()
        {
            var account = new BankAccount(100);
            Thread[] threads = new Thread[3];

            for (int i = 0; i < 3; i++)
            {
                threads[i] = new Thread(() => account.WithdrawUnsafe(50));
                threads[i].Name = $"User{i + 1}";
            }

            foreach (var t in threads) t.Start();
            foreach (var t in threads) t.Join();

            Console.WriteLine($"Final Balance (Unsafe): {account.Balance}");
        }

        public void RunSafe()
        {
            var account = new BankAccount(100);
            Thread[] threads = new Thread[3];

            for (int i = 0; i < 3; i++)
            {
                threads[i] = new Thread(() => account.WithdrawSafe(50));
                threads[i].Name = $"User{i + 1}";
            }

            foreach (var t in threads) t.Start();
            foreach (var t in threads) t.Join();

            Console.WriteLine($"Final Balance (Safe): {account.Balance}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Assignment 1: Parallel Number Processing ===");
            new Assignment1().Run();

            Console.WriteLine("\n=== Assignment 2: Bank Account (Unsafe) ===");
            new Assignment2().RunUnsafe();

            Console.WriteLine("\n=== Assignment 2: Bank Account (Safe with lock) ===");
            new Assignment2().RunSafe();
        }
    }
}
