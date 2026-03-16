using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance_polymorphism
{
    class Account
    {
        public int AccountNumber { get; set; }
        public double Balance { get; set; }

        public Account(int accNo, double balance)
        {
            AccountNumber = accNo;
            Balance = balance;
        }

        public void CalculateInterest()
        {
            Console.WriteLine("Base account interest calculation");
        }
    }

    class SavingsAccount : Account
    {
        public SavingsAccount(int accNo, double balance) : base(accNo, balance) { }

        public new void CalculateInterest()
        {
            Console.WriteLine("Savings account interest calculation");
        }
    }

    class CurrentAccount : Account
    {
        public CurrentAccount(int accNo, double balance) : base(accNo, balance) { }

        public new void CalculateInterest()
        {
            Console.WriteLine("Current account interest calculation");
        }
    }

    class Assignment2
    {
        static void Main()
        {
            Account acc = new SavingsAccount(101, 5000);
            acc.CalculateInterest(); // Calls base method due to method hiding
        }
    }
}
